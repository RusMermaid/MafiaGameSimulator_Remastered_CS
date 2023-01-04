using Domain.Model;
using Domain.Util;
using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Domain
{
    public class GestionJoueurImpl : IGestionJoueur
    {

        private static ModelContainer dbcontext;
        public GestionJoueurImpl()
        {
            dbcontext = new ModelContainer();
        }
        private string EncryptPassword(string password)
        {
            SHA512 shaM = new SHA512Managed();
            byte[] data = Encoding.ASCII.GetBytes(password);
            return Encoding.ASCII.GetString(shaM.ComputeHash(data));
        }

        public bool InscriptionJoueur(string pseudo, string mdp)
        {
            Joueur joueur;
            mdp = EncryptPassword(mdp);
            Joueur temp = (from Joueur j in dbcontext.Joueurs
                           where j.Pseudo.Equals(pseudo)
                           select j).FirstOrDefault();
            if (temp == null)
            {
                joueur = new Joueur();
                joueur.Pseudo = pseudo;
                joueur.Mdp = mdp;
                dbcontext.Joueurs.Add(joueur);
                dbcontext.SaveChanges();
                return true;
            }
            return false;
        }
        public JoueurDto ConnexionJoueur(string pseudo, string mdp)
        {
            mdp = EncryptPassword(mdp);
            Joueur joueur = (from Joueur jo in dbcontext.Joueurs
                           where jo.Pseudo.Equals(pseudo)
                           select jo).FirstOrDefault();
            if (joueur == null)
            {              
                return null;
            }
            else
            {
                if (joueur.Mdp != mdp)
                    return null;
                return BizToDto.ToJoueurDto(joueur);
            }
        }
    }
}