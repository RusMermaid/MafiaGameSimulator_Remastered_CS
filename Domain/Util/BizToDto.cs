using Domain.Dto;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Util
{
    public class BizToDto
    {
        public static PartieDto ToPartieDto(Partie partie)
        {
            PartieDto partieDto = new PartieDto();
            partieDto.Id = partie.Id;
            partieDto.Nom = partie.Nom;
            partieDto.DateHeureCreation = partie.DateHeureCreation;
            partieDto.Sens = partie.Sens;
            partieDto.JoueurCourant = BizToDto.ToJoueurPartieDto(partie.JoueurCourant);
            // partieDto.CartesPioche = BizToDto.ToCarteDtoList(partie.CartesPioche.ToList());
            //  partieDto.JoueurCourant = BizToDto.ToJoueurPartieDto(partie.JoueurCourant);
            //  partieDto.JoueursParticipants = partie.JoueursParticipants;
            //  partieDto.Vainqueur = partie.Vainqueur.to
            return partieDto;
        }
        //Peut-etre dans Util?
        public static List<CarteDto> ToCarteDtoList(List<Carte> ListCarte)
        {
            List<CarteDto> listeDto = new List<CarteDto>();

            for (int i = 0; i < ListCarte.Count; i++)
            {
                CarteDto carteDto = BizToDto.ToCarteDto(ListCarte.ElementAt(i));
                listeDto.Add(carteDto);
            }

            return listeDto;
        }
        public static CarteDto ToCarteDto(Carte carte)
        {
            CarteDto carteDto = new CarteDto();
            carteDto.Id = carte.Id;
            carteDto.CodeEffet = carte.CodeEffet;
            carteDto.Cout = carte.Cout;
            carteDto.Effet = carte.Effet;
            carteDto.EffetComplet = carte.EffetComplet;


            return carteDto;
        }
        public static JoueurPartieDto ToJoueurPartieDto(JoueurPartie joueurPartie)
        {
            JoueurPartieDto joueurPartieDto = new JoueurPartieDto();
            joueurPartieDto.Id = joueurPartie.Id;
            joueurPartieDto.JoueurId = joueurPartie.JoueurId;
            joueurPartieDto.OrdreJoueur = joueurPartie.OrdreJoueur;
            joueurPartieDto.PartieId = joueurPartie.PartieId;
            joueurPartieDto.Joueur = ToJoueurDto(joueurPartie.Joueur);
            return joueurPartieDto;
        }

        public static JoueurDto ToJoueurDto(Joueur joueur)
        {
            JoueurDto joueurDto = new JoueurDto();
            joueurDto.Id = joueur.Id;
            joueurDto.Pseudo = joueur.Pseudo;

            return joueurDto;
        }

        public static DeDto ToDeDto(De de)
        {
            DeDto deDto = new DeDto();
            deDto.Id = de.Id;
            deDto.Valeur = de.Valeur;
            return deDto;
        }
    }
}