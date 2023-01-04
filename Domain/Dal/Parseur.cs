using Domain.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Xml;
using System.Xml.Linq;

namespace Domain.Dal
{
    public class Parseur
    {
        //Load xml
        private XDocument xdoc = XDocument.Load(HostingEnvironment.ApplicationPhysicalPath + "Xml/wazabi.xml");


        public Dictionary<string, int> loadInfos()
        {
            Dictionary<string, int> dico = new Dictionary<string, int>();
            XElement cartes = (from xml2 in xdoc.Elements("wazabi")
                              select xml2).FirstOrDefault();
            dico.Add(cartes.Attribute("nbCartesParJoueur").Name.ToString(),int.Parse(cartes.Attribute("nbCartesParJoueur").Value));
            dico.Add(cartes.Attribute("nbCartesTotal").Name.ToString(), int.Parse(cartes.Attribute("nbCartesTotal").Value));
            dico.Add(cartes.Attribute("minJoueurs").Name.ToString(), int.Parse(cartes.Attribute("minJoueurs").Value));
            dico.Add(cartes.Attribute("maxJoueurs").Name.ToString(), int.Parse(cartes.Attribute("maxJoueurs").Value));

            XElement des = (from xml2 in xdoc.Descendants("de")
                            select xml2).FirstOrDefault();
            
                dico.Add(des.Attribute("nbParJoueur").Name.ToString(), int.Parse(des.Attribute("nbParJoueur").Value));
                dico.Add(des.Attribute("nbTotalDes").Name.ToString(), int.Parse(des.Attribute("nbTotalDes").Value));

            IEnumerable<XElement> faces = from face in xdoc.Descendants("face") select face;
            foreach(var face in faces)
            {
                dico.Add(face.Attribute("figure").Value, int.Parse(face.Attribute("nbFaces").Value));
            }

            return dico;
        }
        public List<Carte> loadCarte()
        {

            List<Carte> list = new List<Carte>();

            IEnumerable<XElement> cartes = from carte in xdoc.Descendants("carte") select carte;
            // Read cartes
            foreach (var carte in cartes)
            {
                int nombreCarte = int.Parse(carte.Attribute("nb").Value);

                for (int i = 0; i < nombreCarte; i++)
                {
                    list.Add(new Carte(int.Parse(carte.Attribute("codeEffet").Value), int.Parse(carte.Attribute("cout").Value), carte.Attribute("effet").Value, carte.Value));
                }

            }
            return list;
        }
        public List<int> loadInfoCartes()
        {
            XElement cartes = (from xml2 in xdoc.Elements("wazabi")
                               select xml2).FirstOrDefault();

            List<int> list = new List<int>();

            list.Add(int.Parse(cartes.Attribute("nbCartesParJoueur").Value));
            list.Add(int.Parse(cartes.Attribute("nbCartesTotal").Value));
            list.Add(int.Parse(cartes.Attribute("minJoueurs").Value));
            list.Add(int.Parse(cartes.Attribute("maxJoueurs").Value));
            return list;
        }

        public List<int> loadInfosDes()
        {
            List<int> list = new List<int>();
            XElement des = (from xml in xdoc.Elements("de")
                            select xml).FirstOrDefault();
            list.Add(int.Parse(des.Attribute("nbParJoueur").Value));
            list.Add(int.Parse(des.Attribute("nbTotalDes").Value));
            return list;
        }


    }
}