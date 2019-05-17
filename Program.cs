using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Amine AGOUSSAL, Cécile AMSALLEM
//Groupe TD A, A3

namespace TD7_8
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO Ajouter import menu
            Personne.ImporterCSV<Beneficiaire>("Beneficiaires.txt");
            Personne.ImporterCSV<Adherent>("Adherents.txt");

            Menu.sousMenu quitter = delegate () { Environment.Exit(0); };
            do
            {
                Menu.sousMenu menuChoisi = InteractionUtilisateur.DemanderChoixObjet<Menu.sousMenu>("Menu :",
                     new Menu.sousMenu[] { Menu.MenuImporter, Menu.MenuRecherchePersonne, Menu.MenuStatistiques, quitter },
                     new string[] { "Importation d'autres bénéficiaires ou adhérents","Recherche de personnes", "Statistiques", "Quitter" });
                menuChoisi();
            } while (true);
            
        }
    }
}
