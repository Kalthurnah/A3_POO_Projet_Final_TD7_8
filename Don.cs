using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    /// <summary>
    /// Don effectué à l'association
    /// </summary>
    public class Don : IIdentifiable
    {
        public enum StatutDon
        {
            Accepte,
            Refuse,
            Stocke
        }

        static List<Don> dons = new List<Don>();
        private static int dernierIdDonne = 0;

        //TODO constructeur, LIST DONS / OBJETS LEGUES DS OBJETS LEUGES , ETC PR TRACABILITE
        private int idDon;
        private string descriptionComplémentaire;
        private DateTime dateReception;
        private string nomDonateur;
        private string numeroTelDonateur;
        private string adresseDonateur;
        private Type typeObjet;
        private Materiel refObjet;
        private StatutDon statut;
        private Adherent adherentTraitantDossier;
        private LieuStockage lieuStockageDon;


        public int Identifiant { get => idDon; }
        public string DescriptionComplémentaire { get => descriptionComplémentaire; }
        public DateTime DateReception { get => dateReception; }
        public Type TypeObjet { get => typeObjet; }
        public Materiel RefObjet { get => refObjet; }
        public string NomDonateur { get => nomDonateur; }
        public string NumeroTelDonateur { get => numeroTelDonateur; }
        public string AdresseDonateur { get => adresseDonateur; }
        public StatutDon Statut { get => statut; }
        public Adherent AdherentTraitantDossier { get => adherentTraitantDossier; }
        public LieuStockage LieuStockageDon { get => lieuStockageDon; }

        public Don(string descriptionComplémentaire, DateTime dateReception, string nomDonateur, string numeroTelDonateur, string adresseDonateur, Materiel refObjet, StatutDon statut, Adherent adherentTraitantDossier, LieuStockage lieuStockageDon)
        {
            dernierIdDonne++;
            idDon = dernierIdDonne;
            this.descriptionComplémentaire = descriptionComplémentaire;
            this.dateReception = dateReception;
            this.nomDonateur = nomDonateur;
            this.numeroTelDonateur = numeroTelDonateur;
            this.adresseDonateur = adresseDonateur;
            this.refObjet = refObjet;
            this.typeObjet = refObjet.GetType();
            this.statut = statut;
            this.adherentTraitantDossier = adherentTraitantDossier;
            this.lieuStockageDon = lieuStockageDon;
        }


    }

}