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
            EnAttente,
            Accepte,
            Refuse,
            Stocke
        }

        static List<Don> donsTraites = new List<Don>();
        static List<Don> donsArchives = new List<Don>();
        static Queue<Don> donsEnAttenteTraitement = new Queue<Don>();

        public static int Count
        {
            get { return (donsArchives.Count + donsTraites.Count + donsEnAttenteTraitement.Count); }
        }

        private static int dernierIdDonne = 0;

        //TODO constructeur, LIST DONS / OBJETS LEGUES DS OBJETS LEUGES , ETC PR TRACABILITE
        private int idDon;
        private string descriptionComplementaire;
        private DateTime dateReception;
        private string nomDonateur;
        private string numeroTelDonateur;
        private string adresseDonateur;
        private Type typeObjet;
        private Materiel objet;
        private StatutDon statut;
        private Adherent adherentTraitantDossier;
        private LieuStockage lieuStockageDon;


        public int Identifiant { get => idDon; }
        public string DescriptionComplementaire { get => descriptionComplementaire; }
        public DateTime DateReception { get => dateReception; }
        public Type TypeObjet { get => typeObjet; }
        public Materiel Objet { get => objet; }
        public string NomDonateur { get => nomDonateur; }
        public string NumeroTelDonateur { get => numeroTelDonateur; }
        public string AdresseDonateur { get => adresseDonateur; }
        public StatutDon Statut { get => statut; }
        public Adherent AdherentTraitantDossier { get => adherentTraitantDossier; }
        public LieuStockage LieuStockageDon { get => lieuStockageDon; }

        public Don(Materiel materielDonne, Donateur donateur, DateTime dateReception, string descriptionComplémentaire = "")
        {
            dernierIdDonne++;
            idDon = dernierIdDonne;
            this.dateReception = dateReception;
            this.descriptionComplementaire = descriptionComplémentaire;

            this.objet = materielDonne;
            this.typeObjet = Objet.GetType();

            this.nomDonateur = donateur.Nom;
            this.numeroTelDonateur = donateur.NumeroTel;
            this.adresseDonateur = donateur.Adresse;

            //Lorsqu'on ajoute un don, il est en attente jusqu'à ce qu'un adhérent l'accepte (ou pas)
            this.statut = StatutDon.EnAttente;
            this.adherentTraitantDossier = null;
            this.lieuStockageDon = null;

            //On l'ajoute à la file d'attente des dons non traités.
            donsEnAttenteTraitement.Enqueue(this);
        }
        
        //Pas encore commit les fonctions pr mettre en attente / traiter/ acrchiver - TODO !    

    }

}