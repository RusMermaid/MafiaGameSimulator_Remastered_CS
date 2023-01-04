using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UI.UccPartieRef;

namespace UI.Controllers
{
    public sealed class UCCPartie
    {
        private static volatile GestionPartieClient instance;
        private static object syncRoot = new Object();

        private UCCPartie() { }

        public static GestionPartieClient Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new GestionPartieClient();
                    }
                }

                return instance;
            }
        }
    }
}
