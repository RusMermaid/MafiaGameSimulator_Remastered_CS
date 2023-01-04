using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Domain.Dto
{
    [DataContract]
    public enum ETAT_PARTIE
    {
        [EnumMember]
        INSCRIPTION = 0,
        [EnumMember]
        EN_COURS = 1,
        [EnumMember]
        TERMINE = 2,
        [EnumMember]
        ANNULE = 3
    };

    [DataContract]
    public class PartieDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nom { get; set; }
        [DataMember]
        public DateTime DateHeureCreation { get; set; }
        [DataMember]
        public bool Sens { get; set; }
        [DataMember]
        public JoueurPartieDto JoueurCourant { get; set; }
        [DataMember]
        public JoueurDto Vainqueur { get; set; }
        [DataMember]
        public ETAT_PARTIE Etat { get; set; }

    }
}