using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Model
{
    public partial class Carte
    {
        public string Effet
        {
            get; set;
        }
        public string EffetComplet
        {
            get; set;
        }
        public Carte(int codeEffet,int cout,String effet,String effetComplet)
        {
            this.CodeEffet = codeEffet;
            this.Cout = cout;
            this.Effet = effet;
            this.EffetComplet = effetComplet;
        }

        public Carte()
        {

        }
        

        
    }
}