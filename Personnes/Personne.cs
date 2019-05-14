using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD7_8
{
    public abstract class Personne : IIdentifiable
    {
        static protected List<Personne> personnes = new List<Personne>();//Stocke les personne créees de facon statique dans la classe Personne.
        static int dernierIdDonne=0;// Le dernier id donné n'est pas forcément le nombre de personnes, dans le cas ou on en supprime par exemple.
        public static int Count { get => CompterPersonnesTypees<Personne>(); }//Compteur de personne, qu'on remplace dans les classes filles avec new

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
        /// Méthode statique protégée, permettant de compter les personnes d'un type donné.
        /// Elle est appelée par les propriétés individuelles des classes, commme Personne.Count ou Beneficiaire.Count
        /// </summary>
        /// <typeparam name="T">Type de personnes qu'on veut compter</typeparam>
        /// <returns></returns>
        protected static int CompterPersonnesTypees<T>() where T : Personne//Condition pour que cette méthode ne prenne que des types T héritant de Personne.
        {
            int compte = 0;
            foreach (T personneTypee in personnes.OfType<T>())
            {
                //Pour chaque personne du type demandé
                compte++;
            }
            return compte;
        }


    }
}
