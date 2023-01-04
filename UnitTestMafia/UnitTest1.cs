using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Model;
using Domain;
using System.Security.Cryptography;
using System.Text;

namespace UnitTestMafia
{
    [TestClass]
    public class UnitTest1
    {
        ServiceReference1.GestionJoueurClient joueurClient = new ServiceReference1.GestionJoueurClient();
        string joueur1 = "gio";
        string joueur2 = "gary";
        string mdp = "ee";
        string partie = "love";
        private static ModelContainer dbcontext = new ModelContainer();
        [TestInitialize]
        public void MyTestInitialize()
        {
            dbcontext = new ModelContainer();
            joueurClient = new ServiceReference1.GestionJoueurClient();
            joueur1 = "gio";
            joueur2 = "gary";
            mdp = "ee";
            partie = "love";
            joueurClient.InscriptionJoueur(joueur1, mdp);
            joueurClient.InscriptionJoueur(joueur2, mdp);


        }
        private string EncryptPassword(string password)
        {
            SHA512 shaM = new SHA512Managed();
            byte[] data = Encoding.ASCII.GetBytes(password);
            return Encoding.ASCII.GetString(shaM.ComputeHash(data));
        }
        //Pas de test Inscription car return bool (j'avais l'idée de retourner un joueurDto) je suis peut etre fatigué

        //test ok
        [TestMethod]
        public void TestConnexion1()
        {

            JoueurDto joueurTest = joueurClient.ConnexionJoueur(joueur1, mdp);
            Assert.AreEqual(joueurTest.Pseudo, joueur1);
            mdp = EncryptPassword(mdp);
            Assert.AreEqual(joueurTest.Mdp, mdp);
        }
       
        //test mauvais Pseudo
        [TestMethod]
        public void TestConnexion2()
        {
            joueurClient.InscriptionJoueur(joueur1, mdp);
            JoueurDto joueurTest = joueurClient.ConnexionJoueur("zarbi", mdp);
            Assert.IsNull(joueurTest);
        }
        //test mauvais Mdp
        [TestMethod]
        public void TestConnexion3()
        {
            joueurClient.InscriptionJoueur(joueur1, mdp);
            JoueurDto joueurTest = joueurClient.ConnexionJoueur(joueur1, "zarbi");
            Assert.IsNull(joueurTest);
        }
    }
}
