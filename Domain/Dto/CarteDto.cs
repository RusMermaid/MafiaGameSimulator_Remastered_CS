using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Domain.Dto
{
    [DataContract]
    public class CarteDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int CodeEffet { get; set; }
        [DataMember]
        public int Cout { get; set; }
        [DataMember]
        public string Effet{get; set;}
        [DataMember]
        public string EffetComplet{get; set;}
    }
}