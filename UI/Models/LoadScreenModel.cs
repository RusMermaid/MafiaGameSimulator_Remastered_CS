using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class LoadScreenModel
    {
        public PartieDto Partie { get; set; }
        public List<JoueurPartieDto> Participants { get; set; }

    }
}