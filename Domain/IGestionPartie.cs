using Domain.Dto;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Domain
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IGestionPartieImpl" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IGestionPartie
    {
        [OperationContract]
        PartieDto CreerPartie(String nomPartie,String nomJoueur);
        [OperationContract]
        PartieDto RejoindrePartie(String pseudo);
        [OperationContract]
        bool CommencerPartie();
        [OperationContract]
        string GetPartieDebug();

        [OperationContract]
        List<PartieDto> VoirPartie(string pseudo);

        [OperationContract]
        PartieDto LancerPartie();

        [OperationContract]
        CarteDto piocherCarte(int IdJoueurPartie);

        void initDe(int IdJoueurPartie);

        [OperationContract]
        JoueurPartieDto getJoueurParticipantDto(int IdJoueurPartie);
        [OperationContract]
        List<JoueurPartieDto> getListJoueurParticipantsDto(int IdPartie);
        [OperationContract]
        List<DeDto> getListDesDto(int IdJoueurPartie);
        [OperationContract]
        List<CarteDto> getListCartesDto(int IdJoueurPartie);
        [OperationContract]
        JoueurDto getJoueurDto(int IdJoueurPartie);

        [OperationContract]
        List<DeDto> lancerDes(int IdJoueurPartie);

        [OperationContract]
        bool autoriserCarte(int idJoueurPartie, int cout);

        [OperationContract]
        bool donnerDe(int IdJoueurPartie, int IdJoueurCible);

        [OperationContract]
        JoueurPartieDto next();

        [OperationContract]
        void supprimerUnDe(int IdJoueurPartie);

        [OperationContract]
        void supprimerDeuxDes(int IdJoueurPartie);

        [OperationContract]
        void donnerDeAGaucheOuDroite(bool sens);

        [OperationContract]
        void rejouerEtChangementDeSens(int IdJoueurPartie);

        [OperationContract]
        void prendreUneCarteDUnJoueur(int IdJoueurPartie, int IdJoueurPartieCible);

        [OperationContract]
        void donnerUnDeAUnJoueur(int IdJoueurPartie, int IdJoueurPartieCible);

        [OperationContract]
        void ciblerJoueurQUUneCarte(int IdJoueurPartieCible);

        [OperationContract]
        List<CarteDto> piocheTroisCartes(int IdJoueurPartie);

        [OperationContract]
        void plusQueDeuxCartesPourLesAutres(int IdJoueurPartie);
        [OperationContract]
        CarteDto jeterCartePoubelle(int IdJoueurPartie,int IdCarte);

        [OperationContract]
        JoueurPartieDto quitterPartie(int IdJoueurPartie);

        [OperationContract]
        JoueurDto vainqueurParForfait();
        [OperationContract]
        JoueurDto vainqueur(int IdJoueurPartie);

        JoueurPartie getJoueurPartie(int IdJoueurPartie);

        [OperationContract]
        GameStateDto getGameState(string nomJoueur);
        [OperationContract]
        CarteDto getCarteDto(int IdCarte);
        [OperationContract]
        DeDto getDeDto(int IdDe);

        [OperationContract]
        void annuler(int IdPartie);

        [OperationContract]
        PartieDto getPartieDto(int IdPartie);

        [OperationContract]
        CarteDto getLastCartePoubelle();

        [OperationContract]
        JoueurPartieDto getJoueurPartie(string pseudo, int idPartie);

    }




}
