using System;
using System.Collections.Generic;
using System.Linq;

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


        private static int dernierIdDonne = 0;

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

        public Don(Materiel materielDonne, Donateur donateur, DateTime dateReception, string descriptionComplementaire = "")
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
            this.dateReception = dateReception;
            //On l'ajoute dc à la file d'attente des dons non traités.
            donsEnAttenteTraitement.Enqueue(this);
        }

        public static List<Don> TrouverDon(Predicate<Don> predicate)
        {
            List<Don> listeTrouverDon = donsDisponibles.FindAll(predicate);
            listeTrouverDon.AddRange(donsArchives.FindAll(predicate));
            return listeTrouverDon;
        }
        //Todo coms
        public static List<Don> TrouverDon<T>(Predicate<Don> predicate) where T : Materiel
        {
            List<Don> listeTrouverDon = new List<Don>(donsDisponibles);
            listeTrouverDon.AddRange(donsArchives);
            listeTrouverDon.FindAll(don => (predicate(don) && don.objet is T));
            return listeTrouverDon;
        }
        //TOdo com et mentionner que par defaut liste tous les statuts
        public static int CountTraites<T>(bool InclureArchive = false, StatutDon[] statutsACompter = null) where T : Materiel
        {
            int compteur = 0;
            if (statutsACompter == null)
            {
                statutsACompter = new StatutDon[] { StatutDon.EnAttente, StatutDon.Refuse, StatutDon.Stocke, StatutDon.Accepte };
            }
            foreach (Don don in donsDisponibles)
            {
                if (don.typeObjet is T && (statutsACompter == null || statutsACompter.Contains(don.Statut)))
                {
                    compteur++;
                }
            }
            if (InclureArchive)
            {
                foreach (Don don in donsArchives)
                {
                    if (don.typeObjet is T && (statutsACompter == null || statutsACompter.Contains(don.Statut)))
                    {
                        compteur++;
                    }
                }
            }
            return compteur;
        }

        public static Dictionary<string,int> ObtenirTypesStockesParFrequence()
        {
            Dictionary<string, int> qteMaterielStocke = new Dictionary<string, int>();
            foreach (Don don in donsDisponibles)
            {
                if (don.Statut == StatutDon.Stocke)
                {
                    if (qteMaterielStocke.ContainsKey(don.typeObjet.Name))
                    {
                        qteMaterielStocke[don.typeObjet.Name]++;
                    }
                    else
                    {
                        qteMaterielStocke.Add(don.typeObjet.Name, 1);
                    }
                }
            }
            //On a ici un dico non trié des types de matériel présents et de leur qté stockée.
            qteMaterielStocke.OrderByDescending(key => key.Value);
            return qteMaterielStocke;
        }

        public DonLegue Leguer(Beneficiaire beneficiaire, DateTime dateLeguee)
        {
            DonLegue donLegue = new DonLegue(this, beneficiaire, dateLeguee);
            donsDisponibles.Remove(this);
            donsArchives.Add(this);
            if (lieuStockageDon != null)
            {
                lieuStockageDon.LeguerDon(donLegue);//Le retire des dons stockés dans ce lieu de stockage
            }
            return donLegue;
        }

        /// <summary>
        /// Traite le premier don dans la file d'attente, l'en retire et l'ajoute dans la liste adaptée (dons disponibles ou archivés en cas de refus..
        /// </summary>
        public static void TraiterDonEnAttente(Adherent adherentTraitantDossier, StatutDon nouveauStatut, LieuStockage lieuStockageDon = null)
        {

            Don donEnTraitement = donsEnAttenteTraitement.Dequeue();
            if (donEnTraitement.statut != StatutDon.EnAttente) { throw new InvalidOperationException("Opération invalide : Le don n'est pas en attente"); }

            donEnTraitement.adherentTraitantDossier = adherentTraitantDossier;
            donEnTraitement.statut = nouveauStatut;

            switch (donEnTraitement.statut)
            {
                case StatutDon.Stocke:
                    donEnTraitement.lieuStockageDon = lieuStockageDon ?? throw new ArgumentNullException("lieuStockageDon", "le lieu de stockage du don est null");
                    // La syntaxe "a??b" s'apparente à un if(x!=null){a}else{b} - cf "null-coalescing operator"
                    lieuStockageDon.StockerDon(donEnTraitement);
                    goto case StatutDon.Accepte;//Une fois que le don est stocké, on fait la même chose qu'un don accepté.
                case StatutDon.Accepte:
                    donsDisponibles.Add(donEnTraitement);
                    break;
                case StatutDon.Refuse:
                    donsArchives.Add(donEnTraitement);
                    break;
            }

        }


        /// <summary>
        /// Interface de traitement de dons, qui affiche le dernier traitement en attente dans la file,
        /// demande les informations à l'utilisateur, puis traite le don en l'enlevant de la file d'attente des dons en attente
        /// </summary>
        public static void InterfaceValidationDons()
        {
            //Si il n'y a pas de dons en attente 
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
                                               //TODO TOSTRING DON, PERSONNE, etc
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

            TraiterDonEnAttente(adherentTraitantDossier, nouveauStatut, lieuStockageDon);

            Console.WriteLine($"Le don a été correctement traité. Il reste {donsEnAttenteTraitement.Count} dons en attente !");

            Console.WriteLine("Appuyer sur une touche pour continuer");
            Console.ReadKey();
        }


        //Todo com
        public static Don InterfaceCreation()
        {
            Materiel materiel = Materiel.InterfaceCreation();
            Donateur donateur = Menu.MenuRecherchePersonneMode<Donateur>(demanderChoix: true);
            DateTime dateReception = InteractionUtilisateur.DemanderDateTime("Entrez la date de reception.");

            string description = InteractionUtilisateur.DemanderString("Entrez une description. (Ou laissez la vide)");
            Don don = new Don(materiel, donateur, dateReception, description);
            return don;
        }
    }

}