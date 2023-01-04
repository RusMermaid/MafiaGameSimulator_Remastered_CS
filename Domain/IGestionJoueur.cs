using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Domain
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IGestionJoueurImpl" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IGestionJoueur
    {
        [OperationContract]
        bool InscriptionJoueur(String pseudo, String mdp);
        [OperationContract]
        JoueurDto ConnexionJoueur(String pseudo, String mdp);
    }
}
