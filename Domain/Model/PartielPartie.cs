using Domain.Dal;
using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Domain.Model
{

    public partial class Partie
    {

        public ETAT_PARTIE etat { get; set; }
        public int nbCartesParJoueur
        {
            get; set;
        }
        private int nbCartesTotal
        {
            get; set;
        }
        public int minJoueurs
        {
            get; set;
        }
        public int maxJoueur
        {
            get; set;
        }
        public int nbParJoueur { get; set; }

        public int nbTotalDes { get; set; }
        private Parseur parseur = new Parseur();

        private static Random rng = new Random();
        //ajout du parametre String nom
        public Partie(String nom)
        {
            // ligne du contructeur généré

            this.JoueursParticipants = new HashSet<JoueurPartie>();
            this.CartesPoubelle = new List<Carte>();
            this.CartesPioche = new List<Carte>();
            this.Nom = nom;
            this.Sens = true;
            this.DateHeureCreation = DateTime.Now;
            Dictionary<string, int> dico = parseur.loadInfos();

            nbCartesParJoueur = dico["nbCartesParJoueur"];
            nbCartesTotal = dico["nbCartesTotal"];
            minJoueurs = dico["minJoueurs"];
            maxJoueur = dico["maxJoueurs"];
            nbParJoueur = dico["nbParJoueur"];
            nbTotalDes = dico["nbTotalDes"];

            List<Carte> listeTypeCarte = parseur.loadCarte();
            Shuffle(listeTypeCarte);

            this.CartesPioche = listeTypeCarte;

        }

        public bool CommencerPartie()
        {
            return true;
        }


        public void Shuffle<Carte>(List<Carte> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Carte value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }


    }

}