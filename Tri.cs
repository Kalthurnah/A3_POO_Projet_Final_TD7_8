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

        static public List<Don> TriRefuseParDate()
        {
            List<Don> donsRefusesParDate = new List<Don>();
            donsRefusesParDate = Recherche.RechercheDonParStatutType<Materiel>("refusé");
            donsRefusesParDate.Sort((x, y) => x.DateReception.CompareTo(y.DateReception));
            return donsRefusesParDate;
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
        
        public static void AfficherPrincipalesCategoriesEnStock()
        {

            foreach (KeyValuePair<string, int> element in Don.ObtenirTypesStockesParFrequence())
            {
                Console.WriteLine($"{element.Key} : {element.Value} stockés");
            }
            
        }
    }
}
