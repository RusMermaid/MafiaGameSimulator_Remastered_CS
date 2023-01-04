using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class ModelPlateau
    {
        public ModelPlateau()
        {
            DesCourant = new List<DeDto>();
            Adversaires = new List<AdversaireModel>();
            MesCartes = new List<CarteDto>();
            MesDes = new List<DeDto>();
        }
        public string passeTour { get; set; }
        public string monNom { get; set; }
        public JoueurDto JoueurCourant { get; set; }

        public List<DeDto> DesCourant { get; set; }

        public List<AdversaireModel> Adversaires { get; set; }

        public List<CarteDto> MesCartes { get; set; }

        public List<DeDto> MesDes { get; set; }

        public ETAT_PARTIE Etat { get; set; }

        public CarteDto DerniereCarteJouee { get; set; }

        public string Client { get; set; }

        public string Vainqueur { get; set; }

    }

}