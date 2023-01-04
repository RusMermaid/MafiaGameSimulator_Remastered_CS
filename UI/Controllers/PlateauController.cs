using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Dto;
using System.Web.Services;
using UI.Models;
using Newtonsoft.Json;

namespace UI.Controllers
{
    public class PlateauController : Controller
    {
        ModelPlateau plateau;
        // GET: Plateau
        public ActionResult Index(string nomPartie = "Partie aléatoire")
        {

            //TODO ajouter système check partie invalide demandée

            //TODO ajouter checks sur l'état de la partie !!!

            JoueurDto jdt = (JoueurDto)Session["user"];
            int idPartie = (int)Session["partie"];

            List<JoueurPartieDto> participants = UCCPartie.Instance.getListJoueurParticipantsDto(idPartie).ToList();

            plateau = new ModelPlateau();
            plateau.Adversaires = new List<AdversaireModel>();

            PartieDto p = UCCPartie.Instance.getPartieDto(idPartie);

            plateau.Etat = p.Etat;
            plateau.JoueurCourant = p.JoueurCourant.Joueur;
            plateau.DerniereCarteJouee = UCCPartie.Instance.getLastCartePoubelle();

            foreach (JoueurPartieDto jp in participants)
            {
                AdversaireModel adv = new AdversaireModel();
                adv.Pseudo = jp.Joueur.Pseudo;
                adv.Des = UCCPartie.Instance.getListDesDto(jp.Id).ToList();
                adv.Cartes = UCCPartie.Instance.getListCartesDto(jp.Id).ToList();
                if (adv.Pseudo.Equals(jdt.Pseudo))
                {
                    Session["monNom"] = jdt.Pseudo;
                    plateau.MesDes = UCCPartie.Instance.getListDesDto(jp.Id).ToList();
                    plateau.DesCourant = UCCPartie.Instance.getListDesDto(jp.Id).ToList();
                    plateau.MesCartes = UCCPartie.Instance.getListCartesDto(jp.Id).ToList();
                }
                plateau.Adversaires.Add(adv);
                plateau.Client = jdt.Pseudo;
            }

            ViewData["partie"] = nomPartie;
            if (p.Vainqueur != null)
                ViewData["vainqueur"] = p.Vainqueur.Pseudo;
            return View(plateau);
        }


        public PartialViewResult RefreshPlateau(string nomPartie = "Partie aléatoire", string cible = "")
        {
            //TODO ajouter système check partie invalide demandée

            //TODO ajouter checks sur l'état de la partie !!!

            JoueurDto jdt = (JoueurDto)Session["user"];
            int idPartie = (int)Session["partie"];

            List<JoueurPartieDto> participants = UCCPartie.Instance.getListJoueurParticipantsDto(idPartie).ToList();

            plateau = new ModelPlateau();
            plateau.Adversaires = new List<AdversaireModel>();

            PartieDto p = UCCPartie.Instance.getPartieDto(idPartie);

            plateau.Etat = p.Etat;
            plateau.JoueurCourant = p.JoueurCourant.Joueur;
            plateau.DerniereCarteJouee = UCCPartie.Instance.getLastCartePoubelle();

            foreach (JoueurPartieDto jp in participants)
            {
                AdversaireModel adv = new AdversaireModel();
                adv.Pseudo = jp.Joueur.Pseudo;
                adv.Des = UCCPartie.Instance.getListDesDto(jp.Id).ToList();
                adv.Cartes = UCCPartie.Instance.getListCartesDto(jp.Id).ToList();
                if (adv.Pseudo.Equals(jdt.Pseudo))
                {
                    Session["monNom"] = jdt.Pseudo;
                    plateau.MesDes = UCCPartie.Instance.getListDesDto(jp.Id).ToList();
                    plateau.DesCourant = UCCPartie.Instance.getListDesDto(jp.Id).ToList();
                    plateau.MesCartes = UCCPartie.Instance.getListCartesDto(jp.Id).ToList();
                }
                plateau.Adversaires.Add(adv);
            }

            ViewData["partie"] = nomPartie;
            plateau.Client = jdt.Pseudo;
            if (p.Vainqueur != null)
                plateau.Vainqueur = p.Vainqueur.Pseudo;
            if (!cible.Equals(""))
            {
                plateau.passeTour = cible;
            }
            return PartialView(plateau);
        }

        public void LancerDes()
        {
            int idPartie = (int)Session["partie"];
            int joueurPartie = UCCPartie.Instance.getPartieDto(idPartie).JoueurCourant.Id;
            UCCPartie.Instance.lancerDes(joueurPartie);
            PiocherCarte();
        }

        public void PiocherCarte()
        {
            int idPartie = (int)Session["partie"];
            int joueurPartie = UCCPartie.Instance.getPartieDto(idPartie).JoueurCourant.Id;
            List<DeDto> list = UCCPartie.Instance.getListDesDto(joueurPartie).ToList();
            foreach (DeDto de in list)
            {
                if (de.Valeur.Equals("P"))
                    UCCPartie.Instance.piocherCarte(joueurPartie);
            }
            RefreshPlateau();
        }

        public void DonnerDe()
        {
            int idPartie = (int)Session["partie"];
            int joueurPartie = UCCPartie.Instance.getPartieDto(idPartie).JoueurCourant.Id;

            string cibleString = Request.QueryString["cible"];
            int cible = (UCCPartie.Instance.getJoueurPartie(cibleString, idPartie)).Id;
            UCCPartie.Instance.donnerDe(joueurPartie, cible);
            RefreshPlateau();

        }

        public ActionResult Next()
        {
            int idPartie = (int)Session["partie"];
            int joueurPartie = UCCPartie.Instance.getPartieDto(idPartie).JoueurCourant.Id;

            PartieDto p = UCCPartie.Instance.getPartieDto(idPartie);
            JoueurDto vainqueur = UCCPartie.Instance.vainqueur(joueurPartie);
            if (vainqueur != null)
            {
                ViewBag.vainqueur = p.Vainqueur.Pseudo;
            }
            else
            {
                UCCPartie.Instance.next();
            }
            return RedirectToAction("Index", new { controller = "Plateau" });

        }

        public ActionResult QuitterPartie()
        {
            int idPartie = (int)Session["partie"];
            int joueurPartie = UCCPartie.Instance.getPartieDto(idPartie).JoueurCourant.Id;
            UCCPartie.Instance.quitterPartie(joueurPartie);
            JoueurDto vainqueur = UCCPartie.Instance.vainqueurParForfait();
            if (vainqueur != null)
            {
                //on a un vainqueur
            }
            else
            {
                UCCPartie.Instance.next();
            }
            return RedirectToAction("Index", new { controller = "Partie" });
        }

        public void JouerCarte()
        {
            String json = Request.Params.Get("json");
            if (json == null)
            {
                RedirectToAction("Index", new { controller = "Index" });
            }

            //recup infos de json            
            Dictionary<string, string> dico = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            int typeCarte = Int32.Parse(dico["typeCarte"]);
            int idCarte = Int32.Parse(dico["carteChoisie"]);
            string sensDico = dico["sens"];

            string sens = "";
            if (sensDico != "")
            {
                sens = sensDico;
            }

            string cibleDico = dico["cible"];
            string cibleStr = "";
            int cible = 0;

            int idPartie = (int)Session["partie"];
            PartieDto p = UCCPartie.Instance.getPartieDto(idPartie);
            if (cibleDico != "")
            {
                cibleStr = dico["cible"];
                cible = UCCPartie.Instance.getJoueurPartie(cibleStr, idPartie).Id;
            }

            int joueurPartie = UCCPartie.Instance.getPartieDto(idPartie).JoueurCourant.Id;

            CarteDto carteDto = UCCPartie.Instance.getCarteDto(idCarte);

            switch (typeCarte)
            {
                case 1:
                    //Supprimer 1 des
                    UCCPartie.Instance.supprimerUnDe(joueurPartie);
                    UCCPartie.Instance.jeterCartePoubelle(joueurPartie, idCarte);
                    break;

                case 2:
                    //Donner des gauche ou droite
                    if (sens == "G")
                        UCCPartie.Instance.donnerDeAGaucheOuDroite(false);
                    else
                        UCCPartie.Instance.donnerDeAGaucheOuDroite(true);
                    UCCPartie.Instance.jeterCartePoubelle(joueurPartie, idCarte);
                    break;

                case 3:
                    //Supprimer 2 des
                    UCCPartie.Instance.supprimerDeuxDes(joueurPartie);
                    UCCPartie.Instance.jeterCartePoubelle(joueurPartie, idCarte);
                    break;


                case 4:
                    //Donner 1 dé
                    UCCPartie.Instance.donnerUnDeAUnJoueur(joueurPartie, cible);
                    UCCPartie.Instance.jeterCartePoubelle(joueurPartie, idCarte);
                    break;

                case 5:
                    //Prendre 1 carte au joueur de mon choix
                    UCCPartie.Instance.prendreUneCarteDUnJoueur(joueurPartie, cible);
                    UCCPartie.Instance.jeterCartePoubelle(joueurPartie, idCarte);
                    break;

                case 6:
                    //Joueur de mon choix n'a plus qu'une carte
                    UCCPartie.Instance.ciblerJoueurQUUneCarte(cible);
                    UCCPartie.Instance.jeterCartePoubelle(joueurPartie, idCarte);
                    break;

                case 7:
                    //Piocher 3 cartes
                    UCCPartie.Instance.piocheTroisCartes(joueurPartie);
                    UCCPartie.Instance.jeterCartePoubelle(joueurPartie, idCarte);
                    break;

                case 8:
                    //Tous les joueurs sauf moi n'ont plus que 2 cartes
                    UCCPartie.Instance.plusQueDeuxCartesPourLesAutres(joueurPartie);
                    UCCPartie.Instance.jeterCartePoubelle(joueurPartie, idCarte);
                    break;

                case 9:
                    //Joueur de mon choix passe son tour
                    passeTour(cibleStr);
                    UCCPartie.Instance.jeterCartePoubelle(joueurPartie, idCarte);
                    break;
                case 10:
                    //Rejouer et changer de tour
                    rejouer();
                    UCCPartie.Instance.jeterCartePoubelle(joueurPartie, idCarte);
                    break;

                default:
                    Response.StatusCode = 500;
                    Response.Write("Type de carte non pris en charge !");
                    break;
            }
        }
        public void rejouer()
        {
            int idPartie = (int)Session["partie"];
            int joueurPartie = UCCPartie.Instance.getPartieDto(idPartie).JoueurCourant.Id;
            PartieDto p = UCCPartie.Instance.getPartieDto(idPartie);
            int nbJoueurs = UCCPartie.Instance.getListJoueurParticipantsDto(idPartie).ToList().Count;
            for (int i = 0; i < nbJoueurs; i++)
                UCCPartie.Instance.next();
            UCCPartie.Instance.rejouerEtChangementDeSens(joueurPartie);
        }
        public void passeTour(string cible)
        {
            RefreshPlateau("", cible);
        }
    }
}
