using System;
using System.Collections.Generic;

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




        //TODO ARCHIVER DONS

        private void TraiterDonEnAttente(Adherent adherentTraitantDossier, StatutDon nouveauStatut, LieuStockage lieuStockageDon = null)
        {
            if (statut != StatutDon.EnAttente) { throw new InvalidOperationException("Opération invalide : Le don n'est pas en attente"); }

            this.adherentTraitantDossier = adherentTraitantDossier;
            this.statut = nouveauStatut;

            if (statut == StatutDon.Stocke)
            {
                if (lieuStockageDon == null) { throw new ArgumentNullException("lieuStockageDon", "le lieu de stockage du don est null"); }

                //TODO AJOUTER LE DON AU LIEU DE STOCKAGE

                this.lieuStockageDon = lieuStockageDon;
            }

            donsTraites.Add(this);
        }

        /// <summary>
        /// Interface de traitement de dons, qui affiche le dernier traitement en attente dans la file,
        /// demande les informations à l'utilisateur, puis traite le don en l'enlevant de la file d'attente des dons en attente
        /// </summary>
        public static void InterfaceTraitementDons()
        {
            //TODO AFFICHER LE DERNIER ELEMENT DE LA QUEUE SI IL EXISTE
            Don donEnTraitement = donsEnAttenteTraitement.Peek();//OBTENIR LES INFOS
            Console.WriteLine("Le dernier don en attente est le suivant :");
            Console.WriteLine(donEnTraitement);//Affiche le ToString du don
            //TODO TOSTRING DON 
            Console.WriteLine("\n ");
            //TODO DEMANDER INFOS A UTILISATEUR : 

            //
            StatutDon nouveauStatut = StatutDon.EnAttente;//TODO : selon la valeur rentrée par l'utilisateur, avec des if itout

            //TODO FONCTION RECHERCHE
            Adherent adherentTraitantDossier = null;//TODO : selon la valeur rentrée par l'utilisateur, avec des if itout suite à une recherche pour trouver le bon adhérent

            //TODO If selon le statut choisi
            LieuStockage lieuStockageDon = null;//Changer selon la valeur rentrée par l'utilisateur SI don stocké

            //TODO SI LES INFOS SONT VALIDES :
            donEnTraitement.TraiterDonEnAttente(adherentTraitantDossier, nouveauStatut, lieuStockageDon);
            //Todo finir cette fonction ^.
            donsEnAttenteTraitement.Dequeue();//TODO SEULEMENT UNE FOIS QU'IL A ETE TRAITE, ON LE RETIRE DE LA FILE
            //TODO ON CONFIRME A L'UTILISATEUR QUE DON TRAITE

            //THE END.
        }

    }

}