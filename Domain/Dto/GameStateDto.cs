using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Domain.Dto
{
    [DataContract]
    public class GameStateDto
    {

        public GameStateDto()
        {
            Adversaires = new List<JoueurStateDto>();
            Cartes = new List<CarteDto>();
            Des = new List<DeDto>();

        }

        [DataMember]
        public string JoueurCourant;
        [DataMember]
        public List<JoueurStateDto> Adversaires;

        [DataMember]
        public List<CarteDto> Cartes;

        [DataMember]
        public List<DeDto> Des;
        
        [DataMember]
        public ETAT_PARTIE Etat;

    }

    


}