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
            Console.WriteLine("Importation initiale des données de Beneficiaires.txt et Adherents.txt");
            Personne.ImporterCSV<Beneficiaire>("Beneficiaires.txt");
            Console.WriteLine();
            Personne.ImporterCSV<Adherent>("Adherents.txt");
            Console.WriteLine("\nAppuyer sur une touche pour continuer;");

            Console.ReadKey();

            do
            {
                Console.Clear();
                Menu.sousMenu menuChoisi = InteractionUtilisateur.DemanderChoixObjet<Menu.sousMenu>("Menu principal :",
                     new Menu.sousMenu[] { Menu.MenuPersonne, Menu.MenuDons, Menu.MenuStatistiques, Menu.MenuTris, () => Environment.Exit(0) },
                     new string[] { "Personnes & Importation", "Dons & Traitement", "Statistiques & Comptes", "Listes et Tris", "Quitter" });
                //TODO : Dans les autres menus, l'intitulé de la fonction "rien" doit etre appelée Retour et non Quitter
                menuChoisi();
                Console.WriteLine("Appuyer sur une touche pour continuer");
                Console.ReadKey();
            } while (true);
        }

        private void InitialisationValeurs()
        {
            //TODO Ajouter des lieux de stockage, dons, etc
        }
    }
}
