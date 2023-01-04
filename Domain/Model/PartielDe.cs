using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Model
{
    public partial class De
    {
        static Random random = new Random(1);
        public De()
        {
            this.Valeur = "M";
        }

        public void LancerDe()
        {
            int rand = random.Next(1, 6)+1;
            if (rand <= 3)
                this.Valeur = "M";
            else if (rand <= 5)
                this.Valeur = "P";
            else this.Valeur = "D";
        }

    }
}