using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class AdversaireModel
    {
        public AdversaireModel()
        {
            Cartes = new List<CarteDto>();
            Des = new List<DeDto>();
        }

        public string Pseudo { get; set; }

        public List<CarteDto> Cartes { get; set; }

        public List<DeDto> Des { get; set; }

    }
}