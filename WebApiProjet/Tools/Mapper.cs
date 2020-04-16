using DalDbProjet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiProjet.Models;

namespace WebApiProjet.Tools
{
    public static class Mapper
    {
        public static AccueilAPI GetAccueilAPI(this Accueil accueilDal)
        {
            AccueilAPI accueilAPI = new AccueilAPI();
            accueilAPI.brasserieId = accueilDal.brasserieId;
            accueilAPI.brasseriePresentation = accueilDal.brasseriePresentation;
            accueilAPI.heureFermeture = accueilDal.heureFermeture;
            accueilAPI.heureOuverture = accueilDal.heureOuverture;
            accueilAPI.horraireDateDebut = accueilDal.horraireDateDebut;
            accueilAPI.horraireDateFin = accueilDal.horraireDateFin;
            accueilAPI.nomBrasserie = accueilDal.nomBrasserie;
            return accueilAPI;
        }
        public static Accueil GetAccueilDal(this AccueilAPI accueilAPI)
        {
            Accueil accueilDal = new Accueil();
            accueilDal.brasserieId = accueilAPI.brasserieId;
            accueilDal.brasseriePresentation = accueilAPI.brasseriePresentation;
            accueilDal.heureFermeture = accueilAPI.heureFermeture;
            accueilDal.heureOuverture = accueilAPI.heureOuverture;
            accueilDal.horraireDateDebut = accueilAPI.horraireDateDebut;
            accueilDal.horraireDateFin = accueilAPI.horraireDateFin;
            accueilDal.nomBrasserie = accueilAPI.nomBrasserie;
            return accueilDal;
        }
        public static BiereAPI GetBiereAPI (this BiereDal biereDal)
        {
            BiereAPI biereAPI = new BiereAPI();
            biereAPI.biereId = biereDal.biereId;
            biereAPI.biereDescription = biereDal.biereDescription;
            biereAPI.biereImage = biereDal.biereImage;
            biereAPI.biereNom = biereDal.biereNom;
            biereAPI.bierePrix = biereDal.bierePrix;
            biereAPI.biereRobe = biereDal.biereRobe;
            biereAPI.nomBrasserie = biereDal.nomBrasserie;
            biereAPI.pourcentageAlcool = biereDal.pourcentageAlcool;
            biereAPI.typeBiereNom = biereDal.typeBiereNom;
            return biereAPI;
        }
        public static BiereDal GetBiereDal(this BiereAPI biereAPI)
        {
            BiereDal biereDal = new BiereDal();
            biereDal.biereDescription = biereAPI.biereDescription;
            biereDal.biereId = biereAPI.biereId;
            biereDal.biereImage = biereAPI.biereImage;
            biereDal.biereNom = biereAPI.biereNom;
            biereDal.bierePrix = biereAPI.bierePrix;
            biereDal.biereRobe = biereAPI.biereRobe;
            biereDal.nomBrasserie = biereAPI.nomBrasserie;
            biereDal.pourcentageAlcool = biereAPI.pourcentageAlcool;
            biereDal.typeBiereNom = biereAPI.typeBiereNom;
            return biereDal;
        }
        public static ClientAPI GetClientAPI(this ClientDal clientDal)
        {
            ClientAPI clientAPI = new ClientAPI();
            clientAPI.clientId = clientDal.clientId;
            clientAPI.clientLogin = clientDal.clientLogin;
            clientAPI.clientNom = clientDal.clientNom;
            clientAPI.clientPrenom = clientDal.clientPrenom;
            clientAPI.clienDateNaissance = clientDal.clienDateNaissance;
           // clientAPI.clientPwd = clientDal.clientPwd;
            return clientAPI;
        }
        public static ClientDal GetClientDal (this ClientAPI clientAPI)
        {
            ClientDal clientDal = new ClientDal();
            clientDal.clienDateNaissance = clientAPI.clienDateNaissance;
            clientDal.clientId = clientAPI.clientId;
            clientDal.clientLogin = clientAPI.clientLogin;
            clientDal.clientNom = clientAPI.clientNom;
            clientDal.clientPrenom = clientAPI.clientPrenom;
            clientDal.clientPwd = clientAPI.clientPwd;
            return clientDal;
        }
        public static CommandeAPI GetCommandeAPI(this CommandeDal commandeDal)
        {
            CommandeAPI commandeAPI = new CommandeAPI();
            commandeAPI.biereNom = commandeDal.biereNom;
            commandeAPI.bierePrix = commandeDal.bierePrix;
            commandeAPI.clientLogin = commandeDal.clientLogin;
            commandeAPI.commandeDate = commandeDal.commandeDate;
            commandeAPI.commandeId = commandeDal.commandeId;
            commandeAPI.commandeQuantite = commandeDal.commandeQuantite;
            return commandeAPI;
        }
        public static CommandeDal GetCommandeDal(this CommandeAPI commandeAPI)
        {
            CommandeDal commandeDal = new CommandeDal();
            commandeDal.biereNom = commandeAPI.biereNom;
            commandeDal.bierePrix = commandeAPI.bierePrix;
            commandeDal.clientLogin = commandeAPI.clientLogin;
            commandeDal.commandeDate = commandeAPI.commandeDate;
            commandeDal.commandeId = commandeAPI.commandeId;
            commandeDal.commandeQuantite = commandeAPI.commandeQuantite;
            return commandeDal;
        }
        public static ContactAPI GetContactAPI (this ContactDal contactDal)
        {
            ContactAPI contactAPI = new ContactAPI();
            contactAPI.adCodePostal = contactDal.adCodePostal;
            contactAPI.adNumero = contactDal.adNumero;
            contactAPI.adRue = contactDal.adRue;
            contactAPI.adVille = contactDal.adVille;
            contactAPI.contactId = contactDal.contactId;
            contactAPI.mailInfon = contactDal.mailInfon;
            contactAPI.nomBrasserie = contactDal.nomBrasserie;
            contactAPI.telephone = contactDal.telephone;
            return contactAPI;
        }
        public static ContactDal GetContactDal(this ContactAPI contactAPI)
        {
            ContactDal contactDal = new ContactDal();
            contactDal.adCodePostal = contactAPI.adCodePostal;
            contactDal.adNumero = contactAPI.adNumero;
            contactDal.adRue = contactAPI.adRue;
            contactDal.adVille = contactAPI.adVille;
            contactDal.contactId = contactAPI.contactId;
            contactDal.mailInfon = contactAPI.mailInfon;
            contactDal.nomBrasserie = contactAPI.nomBrasserie;
            contactDal.telephone = contactAPI.telephone;
            return contactDal;
        }
        public static EvenementAPI GetEvenementAPI(this EvenementDal evenementDal)
        {
            EvenementAPI evenementAPI = new EvenementAPI();
            evenementAPI.brasserieId = evenementDal.brasserieId;
            evenementAPI.eventDateDebut = evenementDal.eventDateDebut;
            evenementAPI.eventDateFin = evenementDal.eventDateFin;
            evenementAPI.eventDescription = evenementDal.eventDescription;
            evenementAPI.eventId = evenementDal.eventId;
            return evenementAPI;
        }
        public static EvenementDal GetEvenementDal(this EvenementAPI evenementAPI)
        {
            EvenementDal evenementDal = new EvenementDal();
            evenementDal.brasserieId = evenementAPI.brasserieId;
            evenementDal.eventDateDebut = evenementAPI.eventDateDebut;
            evenementDal.eventDateFin = evenementAPI.eventDateFin;
            evenementDal.eventDescription = evenementAPI.eventDescription;
            evenementDal.eventId = evenementAPI.eventId;
            return evenementDal;

        }
        public static MessageAPI GetMessageAPI (this MessageDal messageDal)
        {
            MessageAPI messageAPI = new MessageAPI();
            messageAPI.messageAlertId = messageDal.messageAlertId;
            messageAPI.messageContenu = messageDal.messageContenu;
            messageAPI.messageDateDebut = messageDal.messageDateDebut;
            messageAPI.messageDateFin = messageDal.messageDateFin;
            messageAPI.nomBrasserie = messageDal.nomBrasserie;
            return messageAPI;
        }
        public static MessageDal GetMessageDal(this MessageAPI messageAPI)
        {
            MessageDal messageDal = new MessageDal();
            messageDal.messageAlertId = messageAPI.messageAlertId;
            messageDal.messageContenu = messageAPI.messageContenu;
            messageDal.messageDateDebut = messageAPI.messageDateDebut;
            messageDal.messageDateFin = messageAPI.messageDateFin;
            messageDal.nomBrasserie = messageAPI.nomBrasserie;
            return messageDal;
        }
        public static OffreEmploiAPI GetEmploiAPI(this OffreEmploiDal offreEmploiDal)
        {
            OffreEmploiAPI offreEmploiAPI = new OffreEmploiAPI();
            offreEmploiAPI.diplomeMin = offreEmploiDal.diplomeMin;
            offreEmploiAPI.experienceMin = offreEmploiDal.experienceMin;
            offreEmploiAPI.fonction = offreEmploiDal.fonction;
            offreEmploiAPI.jobDescription = offreEmploiDal.jobDescription;
            offreEmploiAPI.mailRecrutement = offreEmploiDal.mailRecrutement;
            offreEmploiAPI.nomBrasserie = offreEmploiDal.nomBrasserie;
            offreEmploiAPI.offreEmploiId = offreEmploiDal.offreEmploiId;
            return offreEmploiAPI;
        }
        public static OffreEmploiDal GetEmploiDal(this OffreEmploiAPI offreEmploiAPI)
        {
            OffreEmploiDal offreEmploiDal = new OffreEmploiDal();
            offreEmploiDal.diplomeMin = offreEmploiAPI.diplomeMin;
            offreEmploiDal.experienceMin = offreEmploiAPI.experienceMin;
            offreEmploiDal.fonction = offreEmploiAPI.fonction;
            offreEmploiDal.jobDescription = offreEmploiAPI.jobDescription;
            offreEmploiDal.mailRecrutement = offreEmploiAPI.mailRecrutement;
            offreEmploiDal.nomBrasserie = offreEmploiAPI.nomBrasserie;
            offreEmploiDal.offreEmploiId = offreEmploiAPI.offreEmploiId;
            return offreEmploiDal;
        }
        public static RecompenseAPI GetRecompenseAPI(this RecompenseDal dal)
        {
            RecompenseAPI api = new RecompenseAPI();
            api.recompenseId = dal.recompenseId;
            api.recompenseNom = dal.recompenseNom;
            api.biereId = dal.biereId;
            return api;
        }
        public static RecompenseDal GetRecompenseDal(this RecompenseAPI api)
        {
            RecompenseDal dal = new RecompenseDal();
            dal.biereId = api.biereId;
            dal.recompenseId = api.recompenseId;
            dal.recompenseNom = api.recompenseNom;
            return dal;
        }
    }
}