using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Domain.Dto
{
    [DataContract]
    public class DeDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Valeur { get; set; }
      
    }
}