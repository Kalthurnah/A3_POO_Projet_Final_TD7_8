using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    /// <summary>
    /// Don effectué à l'association
    /// </summary>
    public class Don
    {
        public enum StatutDon
        {
            Accepte,
            Refuse,
            Stocke
        }
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

        public int IdDon { get => idDon; }
        public string DescriptionComplémentaire { get => descriptionComplémentaire; }
        public DateTime DateReception { get => dateReception; }
        public Type TypeObjet { get => typeObjet; }
        public Materiel RefObjet { get => refObjet; }
        public string NomDonateur { get => nomDonateur; }
        public string NumeroTelDonateur { get => numeroTelDonateur; }
        public string AdresseDonateur { get => adresseDonateur; }
        public StatutDon Statut { get => statut; }
        public Adherent AdherentTraitantDossier { get => adherentTraitantDossier; }
        internal LieuStockage LieuStockageDon { get => lieuStockageDon; }



    }

}