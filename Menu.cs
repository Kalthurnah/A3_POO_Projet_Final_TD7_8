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
                case 1:
                    MenuRecherchePersonneMode<Adherent>();
                    break;
                case 2:
                    MenuRecherchePersonneMode<Beneficiaire>();
                    break;
                case 3:
                    MenuRecherchePersonneMode<Donateur>();
                    break;
                case 4:
                    MenuRecherchePersonneMode<Personne>();
                    break;
            }
        }

        public static void MenuStatistiques()
        {
            sousMenu moyChoisie = InteractionUtilisateur.DemanderChoixObjet<sousMenu>("Menu :",
                 new sousMenu[] { () => Console.WriteLine(LieuStockage.MoyenneDureeStockageGenerale()), () => Console.WriteLine(DepotVente.MoyennePrixGenerale()),
                     () => Console.WriteLine(Beneficiaire.MoyenneAge()), () => Console.WriteLine(Beneficiaire.Count), () => Console.WriteLine(Adherent.Count),
                     () => Console.WriteLine(Don.Count), () => Console.WriteLine(Recherche.RechercheDonStatut("accepte").Count), Rien },
                     new string[] { "Obtenir la moyenne de temps entre la receptione et le retrait des dons",
                         "Obtenir la moyenne de prix dans les dépot-vente", "Obetnir la moyenne d'âge des bénéficiaire",
                         "Obtenir le nombre de bénéficiaires", "Obtenir le nombre d'adhérents", "Obtenir le nombre de propositions de dons",
                         "Afficher le nombre de dons acceptés", "Quitter" });
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
    }
}
