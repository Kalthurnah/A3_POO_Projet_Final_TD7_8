using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD7_8
{
    class Tri
    {
        //Todo : faire des delegate de comparison, ou les créer dans leurs classes respectives
        //https://docs.microsoft.com/en-us/dotnet/api/system.comparison-1?view=netframework-4.8
        //Ex : Comparer don par identifiant, comparer don par nom, etc... J'pense que dans leurs classes elle meme ce serait mieux qu'ici 🤔

        //TODO Com : en gros une fonction qui depuis un don retourne une propriété d'un don

        public delegate T ObtentionPropriete<T>(Don don) where T : IComparable;
        public delegate T ObtentionProprieteLegue<T>(DonLegue donLegue) where T : IComparable;
        
        public delegate T FonctionObtentionPropriete<T>(Don don) where T : IComparable;

        static public List<Don> TriRefuseParDate()
        {
            List<Don> donsRefusesParDate = Don.TrouverDon(don => don.Statut == Don.StatutDon.Refuse);
            donsRefusesParDate.Sort((x, y) => x.DateReception.CompareTo(y.DateReception));
            return donsRefusesParDate;
            //Todo la rendre generique pour qu'elle prenne une fonction d'obtention de propriete en param ? (comme celle de dessous)
        }

        static public List<Don> TriAccepteStockeNom()
        {
            List<Don> donsAccepteStocke = new List<Don>();
            donsAccepteStocke = Recherche.RechercheDonParStatutType<Materiel>("accepté");
            donsAccepteStocke.AddRange(Recherche.RechercheDonParStatutType<Materiel>("stocké"));
            donsAccepteStocke.Sort((x, y) => x.NomDonateur.CompareTo(y.NomDonateur));
            return donsAccepteStocke;
        }

        static public List<Don> TriAccepteStockeId()
        {
            List<Don> donsAccepteStocke = new List<Don>();
            donsAccepteStocke = Recherche.RechercheDonParStatutType<Materiel>("accepté");
            donsAccepteStocke.AddRange(Recherche.RechercheDonParStatutType<Materiel>("stocké"));
            donsAccepteStocke.Sort((x, y) => x.Identifiant.CompareTo(y.Identifiant));
            return donsAccepteStocke;
        }

        /// <summary>
        /// TODO COM
        /// </summary>
        /// <example>
        /// <code>
        /// TriAccepteStocke<int>(x => x.Identifiant);
        /// </code>
        /// </example>
        /// <typeparam name="T"></typeparam>
        /// <param name="fonctionObtentionPropriete"></param>
        /// <returns></returns>
        static public List<Don> TriAccepteStocke<T>(FonctionObtentionPropriete<T> fonctionObtentionPropriete) where T : IComparable
        {
            List<Don> donsAccepteStocke = Don.TrouverDon(don=>don.Statut== Don.StatutDon.Accepte || don.Statut==Don.StatutDon.Stocke);
            donsAccepteStocke.Sort((x, y) => fonctionObtentionPropriete(x).CompareTo(fonctionObtentionPropriete(y)));
            return donsAccepteStocke;
        }

        static public List<DonLegue> TriVenduDonne<T>(ObtentionProprieteLegue<T> fonctionObtentionPropriete) where T : IComparable
        {
            List<DonLegue> donsVendusDonnes = new List<DonLegue>();
            donsVendusDonnes = DonLegue.DonsLegues;
            donsVendusDonnes.Sort((x, y) => fonctionObtentionPropriete(x).CompareTo(fonctionObtentionPropriete(y)));
            return donsVendusDonnes;
        }

        public static void AfficherPrincipalesCategoriesEnStock()
        {

            foreach (KeyValuePair<string, int> element in Don.ObtenirTypesStockesParFrequence())
            {
                Console.WriteLine($"{element.Key} : {element.Value} stockés");
            }

        }
    }
}
