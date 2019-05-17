using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD7_8
{
    public class Menu
    {

        public delegate void sousMenu();
        public delegate double fonctionMoyenne();
        public static sousMenu Rien = () => { };
        public static void MenuRecherchePersonne()
        {
            int typeChoisi = InteractionUtilisateur.DemanderChoixInt("Choisir le type de personne à chercher :",
                new string[] { "Adhérent", "Bénéficiaire", "Donateur", "Personne (Recherche globale)" });

            switch (typeChoisi)
            {
                case 0:
                    MenuRecherchePersonneMode<Adherent>();
                    break;
                case 1:
                    MenuRecherchePersonneMode<Beneficiaire>();
                    break;
                case 2:
                    MenuRecherchePersonneMode<Donateur>();
                    break;
                case 3 :
                    MenuRecherchePersonneMode<Personne>();
                    break;
            }
        }

        public static void MenuStatistiques()
        {
            sousMenu moyChoisie = InteractionUtilisateur.DemanderChoixObjet<sousMenu>("Menu :",
                 new sousMenu[] { () => Console.WriteLine(LieuStockage.MoyenneDureeStockageGenerale()),
                     () => Console.WriteLine(DepotVente.MoyennePrixGenerale()),
                     () => Console.WriteLine(Beneficiaire.MoyenneAge()),
                     () => Console.WriteLine(Beneficiaire.Count),
                     () => Console.WriteLine(Donateur.Count),
                     () => Console.WriteLine(Adherent.Count),
                     () => Console.WriteLine(Don.Count),
                     () => Console.WriteLine(Recherche.RechercheDonStatut("accepte").Count),
                     () => Console.WriteLine(Recherche.RechercheDonStatutVolumineux("accepte").Count/Don.TrouverDon<ObjetVolumineux>(x => true).Count),
                     Rien },
                     new string[] { "Obtenir la moyenne de temps entre la reception et le retrait des dons",
                         "Obtenir la moyenne de prix dans les dépot-ventes",
                         "Obtenir la moyenne d'âge des bénéficiaires",
                         "Obtenir le nombre de bénéficiaires",
                         "Obtenir le nombre de donateur",
                         "Obtenir le nombre d'adhérents",
                         "Obtenir le nombre de propositions de dons",
                         "Obtenir le nombre de dons acceptés",
                         "Obtenir le ratio de propositions d'objets volumineux acceptées par rapport aux reçues",
                         "Quitter" });
            moyChoisie();
        }

        public static T MenuRecherchePersonneMode<T>(bool demanderChoix = false) where T : Personne
        {
            Recherche.FonctionRecherche<T> modeDeRechercheChoisi = InteractionUtilisateur.DemanderChoixObjet<Recherche.FonctionRecherche<T>>("Choisir le mode de recherche :",
                new Recherche.FonctionRecherche<T>[] {
                    Recherche.RechercheParNomPersonneTypee<T>,
                    Recherche.RechercheParNumTelPersonneTypee<T>
                },
                new string[] { "Recherche par nom", "Recherche par numéro de téléphone" }
                );
            //on obtient la fonction de recherche correspondant au choix utilisateur


            return InteractionUtilisateur.RechercherUnElement<T>(modeDeRechercheChoisi);
        }
        
        public static void MenuDon()
        {
            //TODO

            sousMenu menuChoisi = InteractionUtilisateur.DemanderChoixObjet<sousMenu>("Menu :",
                 new sousMenu[] { Don.InterfaceValidationDons, Rien },
                     new string[] { "Valider les dons en attente", "Quitter" });
            menuChoisi();
        }

        public static void MenuImporter()
        {
            Console.WriteLine("Donnez le nom du fichier à importer : ");
            string nomFichier = Console.ReadLine();
            sousMenu menuChoisi = InteractionUtilisateur.DemanderChoixObjet<sousMenu>("Qu'allez-vous importer ?",
                 new sousMenu[] {()=> Personne.ImporterCSV<Beneficiaire>(nomFichier), () => Personne.ImporterCSV<Adherent>(nomFichier), Rien },
                     new string[] { "Des bénéficiaires","Des adhérents", "Quitter" });
            menuChoisi();
        }
    }
}
