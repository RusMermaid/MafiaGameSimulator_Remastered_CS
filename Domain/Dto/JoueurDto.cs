using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Domain.Dto
{

    //TODO ID useless ?
    //TODO Etendre Biz au DTO ??

    [DataContract]
    public class JoueurDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Pseudo { get; set; }
    }


    [DataContract]
    public class JoueurStateDto
    {
        [DataMember]
        public string Pseudo { get; set; }
        [DataMember]
        public int NbCartes { get; set; }
        [DataMember]
        public int NbDes { get; set; }

    }

}