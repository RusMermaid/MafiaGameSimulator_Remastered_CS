using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Domain.Dto
{
    [DataContract]
    public class JoueurPartieDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int JoueurId { get; set; }
        [DataMember]
        public int OrdreJoueur { get; set; }
        [DataMember]
        public int PartieId { get; set; }
        [DataMember]
        public JoueurDto Joueur { get; set; }
        [DataMember]
        public PartieDto PartieCourante { get; set; }
       
    }
}