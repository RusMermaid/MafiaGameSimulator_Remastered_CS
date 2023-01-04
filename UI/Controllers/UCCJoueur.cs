using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UI.UccJoueurRef;

namespace UI.Controllers
{
    public sealed class UCCJoueur
    {
        private static volatile GestionJoueurClient instance;
        private static object syncRoot = new Object();

        private UCCJoueur() { }

        public static GestionJoueurClient Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new GestionJoueurClient();
                    }
                }

                return instance;
            }
        }
    }
}