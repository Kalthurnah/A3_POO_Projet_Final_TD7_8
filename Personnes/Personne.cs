using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TD7_8
{
    public abstract class Personne : IIdentifiable, IComparable<Personne>
    {
        protected static List<Personne> personnes = new List<Personne>();//Stocke les personne créees de facon statique dans la classe Personne.
        static int dernierIdDonne = 0;// Le dernier id donné n'est pas forcément le nombre de personnes, dans le cas ou on en supprime par exemple.
        public static int Count { get => personnes.Count(); }//Compteur de personne, qu'on remplace dans les classes filles avec new

        //Attributs d'instance v .

        private int identifiant;
        protected string nom;
        protected string prenom;
        protected string adresse;
        protected string numeroTel;

        public int Identifiant { get => identifiant; }
        /// <summary>
        /// "Les différentes informations peuvent être modifiables", selon l'énoncé. Ci dessous get et set permettant la modification, au besoin.
        /// </summary>
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string NumeroTel { get => numeroTel; set => numeroTel = value; }



        /// <summary>
        /// Crée une instance de la classe Personne.
        /// </summary>
        /// <param name="nom">Nom de la personne</param>
        /// <param name="prenom">Prenom de la personne</param>
        /// <param name="adresse">Adresse de la personne</param>
        /// <param name="numeroTel">Numéro de téléphone de la personne</param>
        public Personne(string nom, string prenom, string adresse, string numeroTel)
        {
            dernierIdDonne++;
            identifiant = dernierIdDonne;
            this.nom = nom;
            this.prenom = prenom;
            this.adresse = adresse;
            this.numeroTel = numeroTel;
            personnes.Add(this);
        }

        /// <summary>
        /// Permet d'importer les fichiers CSV ou TXT dont les données sont séparés par des ";".
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nomFichier"></param>
        public static void ImporterCSV<T>(string nomFichier) where T : Personne
        {
            StreamReader fichLect = new StreamReader(nomFichier);
            char[] sep = new char[1] { ';' };
            string ligne;
            string[] datas;
            DateTime date;
            string nom;
            string prenom;
            string adresse;
            string tel;
            Adherent.Fonction statut;
            while (fichLect.Peek() > 0)
            {
                ligne = fichLect.ReadLine();
                if (ligne != "")
                {
                    Console.WriteLine($"Ajout du {typeof(T).Name} : " + ligne);
                    datas = ligne.Split(sep);
                    nom = datas[1];
                    prenom = datas[4];
                    adresse = datas[2];
                    tel = datas[3];
                    if (typeof(T) == typeof(Beneficiaire))
                    {
                        date = DateTime.ParseExact(datas[5], "dd/MM/yyyy", null);
                        new Beneficiaire(date, nom, prenom, adresse, tel);
                    }
                    else
                    {
                        switch (datas[5])
                        {
                            case "membre":
                                statut = Adherent.Fonction.Membre;
                                break;
                            case "tresorier":
                                statut = Adherent.Fonction.Tresorier;
                                break;
                            case "president":
                                statut = Adherent.Fonction.President;
                                break;
                            default:
                                statut = Adherent.Fonction.Membre;
                                break;
                        }
                        new Adherent(statut, nom, prenom, adresse, tel);
                    }
                }
            }
            Console.WriteLine("Importation terminée.");
        }

        /// <summary>
        /// Permet de trouver toutes les instances de type T héritant de Personne répondant à la condition passée en argument.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static List<T> TrouverInstance<T>(Predicate<T> predicate) where T : Personne
        {
            List<T> personnesTypees = personnes.OfType<T>().ToList();
            return personnesTypees.FindAll(predicate);
        }

        /// <summary>
        /// Méthode supprimant une personne de la liste des personnes.
        /// </summary>
        public void Supprimer()
        {
            personnes.Remove(this);
        }

        public int CompareTo(Personne other)
        {
            return nom.CompareTo(other.Nom);
        }

        /// <summary>
        /// Permet d'encapsuler la méthode de création d'une personne.
        /// </summary>
        /// <returns></returns>
        delegate Personne CreateurPersonne();
        /// <summary>
        /// On créé une personne en demandant les informations nécessaire à l'utilisateur, notamment le type de personne à créer.
        /// </summary>
        /// <returns></returns>
        public static Personne InterfaceCreation()
        {
            CreateurPersonne createurChoisi = InteractionUtilisateur.DemanderChoixObjet<CreateurPersonne>("Quel est le type de personnes à créer ?",
                new CreateurPersonne[] { Adherent.InterfaceCreation,
                    Donateur.InterfaceCreation,
                    Beneficiaire.InterfaceCreation},
             new string[] { "Adhérent",
                 "Donateur",
                 "Bénéficiaire"}
             );
            Personne personneCree = createurChoisi();//Lance l'interface de création pour le type de personne choisi.
            return personneCree;
        }

        public override string ToString()
        {
            return $"{Nom} {Prenom}, id : {identifiant}, joignable au {numeroTel} au {adresse}";//+ type et détails supp' (dans les classes héritantes)
        }

    }
}
