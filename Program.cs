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
            InitialisationValeurs();
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

        /// <summary>
        /// Insere des valeurs au pif pour tester
        /// </summary>
        public static void InitialisationValeurs()
        {
            //TODO Ajouter des lieux de stockage, dons, etc
            Don don0 = new Don(new Chaise(1, 1, 1, 5), new Donateur(Adherent.Fonction.Membre, "A", "a", "adresse1", "04090823"), DateTime.ParseExact("12/12/2012", "dd/MM/yyyy", null));
            Don don1 = new Don(new Cuisiniere(2, 2, 2, 2, 1, 500), new Donateur(Adherent.Fonction.President, "P", "p", "adresseP", "012424090823"), DateTime.ParseExact("12/11/2008", "dd/MM/yyyy", null));
            Don don2 = new Don(new Matelas(3, 3, 3, 50), new Donateur(Adherent.Fonction.Tresorier, "T", "t", "adresseT", "04424090823"), DateTime.ParseExact("12/10/2009", "dd/MM/yyyy", null));
            Don don3 = new Don(new Matelas(3, 3, 3, 50), new Donateur(Adherent.Fonction.Tresorier, "T", "t", "adresseT", "04424090823"), DateTime.ParseExact("12/10/2008", "dd/MM/yyyy", null));
            DepotVente b = new DepotVente("DepotB", "AdressuBBBuuh", "12732712");

            Don.TraiterDonEnAttente(new Adherent(Adherent.Fonction.Membre, "TR", "tr", "adressetr", "040456790823"), Don.StatutDon.Stocke, new DepotVente("DepotA", "Adressuuuh", "127712 :D"));
            Don.TraiterDonEnAttente(new Adherent(Adherent.Fonction.Membre, "TQEGSGR", "tSr", "adressetSQDFr", "040A2343456790823"), Don.StatutDon.Refuse);
            Don.TraiterDonEnAttente(new Adherent(Adherent.Fonction.Membre, "TRSGF", "trARGQSDFV", "adressetr", "040456790823"), Don.StatutDon.Stocke, b);
            Don.TraiterDonEnAttente(new Adherent(Adherent.Fonction.Membre, "TQSDFQSDFR", "trQDSF", "aQSDdressetr", "040423R23456790823"), Don.StatutDon.Accepte);
            don0.Leguer(new Beneficiaire(DateTime.ParseExact("12/10/1960", "dd/MM/yyyy", null), "FFZ", "aaa", "adressedsqfsd", "2643565432"), DateTime.ParseExact("12/10/2010", "dd/MM/yyyy", null));
            don3.Leguer(new Beneficiaire(DateTime.ParseExact("12/10/1950", "dd/MM/yyyy", null), "B", "b", "adresseB", "256643565432"), DateTime.Now);


            new Don(new Assiette(10, 0), new Donateur(Adherent.Fonction.Membre, "B", "b", "arbeiz", "065214535"), DateTime.ParseExact("17/03/2010", "dd/MM/yyyy", null));
            new Don(new Refrigerateur(100, 150, 200, 100), new Donateur(Adherent.Fonction.Membre, "d", "b", "grearbeiz", "065277535"), DateTime.ParseExact("15/03/2010", "dd/MM/yyyy", null));
        
            Don.TraiterDonEnAttente(new Adherent(Adherent.Fonction.Membre, "TRSGrfF", "trARGzfeQSDFV", "adzefressetr", "04045é136790823"), Don.StatutDon.Stocke, b);
        }
    }
}
