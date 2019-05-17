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

        static List<Don> donsDisponibles = new List<Don>();
        static List<Don> donsArchives = new List<Don>();
        static Queue<Don> donsEnAttenteTraitement = new Queue<Don>();

        public static int Count
        {
            get { return (donsArchives.Count + donsDisponibles.Count + donsEnAttenteTraitement.Count); }
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

        public static List<Don> TrouverDon(Predicate<Don> predicate)
        {
            List<Don> listeTrouverDon = donsDisponibles.FindAll(predicate);
            listeTrouverDon.AddRange(donsArchives.FindAll(predicate));
            return listeTrouverDon;
        }

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

        public Don(Materiel materielDonne, Donateur donateur, DateTime dateReception string descriptionComplementaire = "")
        {
            dernierIdDonne++;
            idDon = dernierIdDonne;
            this.descriptionComplementaire = descriptionComplementaire;

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
            this.dateReception = dateReception;
        }



        /// <summary>
        /// Interface de traitement de dons, qui affiche le dernier traitement en attente dans la file,
        /// demande les informations à l'utilisateur, puis traite le don en l'enlevant de la file d'attente des dons en attente
        /// </summary>
        public static void InterfaceValidationDons()
        {
            //Si il n'y a pas 
            if (donsEnAttenteTraitement.Count < 1)
            {
                Console.WriteLine("Pas de don en attente !");
                Console.WriteLine("Appuyer sur une pour continuer.");
                Console.ReadKey();
                return;
            }
            Don donEnTraitement = donsEnAttenteTraitement.Peek();
            Console.WriteLine("Le dernier don en attente est le suivant :");
            Console.WriteLine(donEnTraitement);//Affiche le ToString du don
            //TODO TOSTRING DON 
            Console.WriteLine("\n");
            //On demande les infos à l'utilisateur :
            StatutDon nouveauStatut = InteractionUtilisateur.DemanderChoixObjet<StatutDon>("Ce don est en attente. Faut-il :",
                new StatutDon[] { StatutDon.Accepte, StatutDon.Stocke, StatutDon.Refuse },
                new string[] { "L'accepter", "Le stocker", "Le refuser" });
            LieuStockage lieuStockageDon = null;
            if (nouveauStatut == StatutDon.Stocke)
            {
                lieuStockageDon = InteractionUtilisateur.RechercherUnElement<LieuStockage>(Recherche.RechercheParNomLieuStockageType<LieuStockage>, true, "nom");
            }

            Console.WriteLine("Pour valider le dossier, il nous faut votre identité. Qui êtes vous ?");
            Adherent adherentTraitantDossier = Menu.MenuRecherchePersonneMode<Adherent>(true);

            donEnTraitement.TraiterDonEnAttente(adherentTraitantDossier, nouveauStatut, lieuStockageDon);

            donsEnAttenteTraitement.Dequeue();

            Console.WriteLine($"Le don a été correctement traité. Il reste {donsEnAttenteTraitement.Count} dons en attente !");

            Console.WriteLine("Appuyer sur une touche pour continuer");
            Console.ReadKey();
        }


        //TODO ARCHIVER DONS

        private void TraiterDonEnAttente(Adherent adherentTraitantDossier, StatutDon nouveauStatut, LieuStockage lieuStockageDon = null)
        {
            if (statut != StatutDon.EnAttente) { throw new InvalidOperationException("Opération invalide : Le don n'est pas en attente"); }

            this.adherentTraitantDossier = adherentTraitantDossier;
            this.statut = nouveauStatut;

            switch (statut)
            {
                case StatutDon.Stocke:
                    this.lieuStockageDon = lieuStockageDon ?? throw new ArgumentNullException("lieuStockageDon", "le lieu de stockage du don est null");
                    // La syntaxe "a??b" s'apparente à un if(x!=null){a}else{b} - cf "null-coalescing operator"
                    lieuStockageDon.StockerDon(this);
                    goto case StatutDon.Accepte;//Une fois que le don est stocké, on fait la même chose qu'un don accepté.
                case StatutDon.Accepte:
                    donsDisponibles.Add(this);
                    break;
                case StatutDon.Refuse:
                    donsArchives.Add(this);
                    break;
            }
        }


        public static Don InterfaceCreationDon()
        {
            Don don=null;//todo rem
            Materiel materiel = Materiel.InterfaceCreationMateriel();//TODO
            //don = new Don(TODO);

            return don;

        }
    }

}