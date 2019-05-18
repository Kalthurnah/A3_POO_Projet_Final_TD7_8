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
                menuChoisi();
                Console.WriteLine("Appuyer sur une touche pour continuer");
                Console.ReadKey();
            } while (true);
        }

        private void InitialisationValeurs()
        {
            //TODO Ajouter des lieux de stockage, dons, etc
            new Don(new Chaise(1, 1, 1, 5), new Donateur(Adherent.Fonction.Membre, "A", "a", "adresse1", "04090823"), DateTime.ParseExact("12/12/2012", "dd/MM/yyyy", null));
            new Don(new Cuisiniere(2, 2, 2, 2, 1, 500), new Donateur(Adherent.Fonction.President, "P", "p", "adresseP", "012424090823"), DateTime.ParseExact("12/12/2012", "dd/MM/yyyy", null));
            new Don(new Matelas(3, 3, 3, 50), new Donateur(Adherent.Fonction.Tresorier, "T", "t", "adresseT", "04424090823"), DateTime.ParseExact("12/12/2012", "dd/MM/yyyy", null));



        }
    }
}
