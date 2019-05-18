using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD7_8
{
    public class Menu
    {
        //TODO COMS 


        public delegate void sousMenu();
        public delegate double fonctionMoyenne();
        public static sousMenu Rien = () => { };
        public static void MenuRecherchePersonne()
        {
            int typeChoisi = InteractionUtilisateur.DemanderChoixInt("Choisir le type de personne à chercher :",
                new string[] { "Adhérent", "Bénéficiaire", "Donateur", "Personne (Recherche globale)" });

            //Pas réussi à récupérer une méthode typée directement comme delegate.. TODO psk flemme de switch.. Surtout avec les dons
            switch (typeChoisi)
            {
                case 0:
                    MenuRecherchePersonneMode<Adherent>(false);
                    break;
                case 1:
                    MenuRecherchePersonneMode<Beneficiaire>(false);
                    break;
                case 2:
                    MenuRecherchePersonneMode<Donateur>(false);
                    break;
                case 3:
                    MenuRecherchePersonneMode<Personne>(false);
                    break;
            }
        }

        public static void MenuPersonne()
        {
            sousMenu menuChoisi = InteractionUtilisateur.DemanderChoixObjet<sousMenu>("Menu Personnes :",
                 new sousMenu[] { MenuImportation, MenuRecherchePersonne, , Rien },
                 new string[] { "Importation d'autres bénéficiaires ou adhérents", "Ajout manuel de personnes","Recherche de personnes", "Modification de Personnes", "Retour" });
            menuChoisi();
        }

        public static Don MenuRechercheDon(bool demanderChoix)
        {
            int typeChoisi = InteractionUtilisateur.DemanderChoixInt("Choisir le type d'objet du don à chercher :",
                new string[] { "Matériel (Recherche globale)", "Armoire", "Assiette", "Chaise", "Chevet" });
            //Todo ajouter les autres types ci dessus

            switch (typeChoisi)
            {
                case 0:
                default:
                    return MenuRechercheDonMode<Materiel>(demanderChoix);
                case 1:
                    return MenuRechercheDonMode<Armoire>(demanderChoix);
                case 2:
                    return MenuRechercheDonMode<Assiette>(demanderChoix);
                case 3:
                    return MenuRechercheDonMode<Chaise>(demanderChoix);
                case 4:
                    return MenuRechercheDonMode<Chevet>(demanderChoix);
                case 5:
                    return MenuRechercheDonMode<Couvert>(demanderChoix);
                case 6:
                    return MenuRechercheDonMode<Cuisiniere>(demanderChoix);
                case 7:
                    return MenuRechercheDonMode<ElectroMenager>(demanderChoix);
                case 8:
                    return MenuRechercheDonMode<LaveLinge>(demanderChoix);
                case 9:
                    return MenuRechercheDonMode<Matelas>(demanderChoix);
                case 10:
                    return MenuRechercheDonMode<MobilierChambre>(demanderChoix);
                case 11:
                    return MenuRechercheDonMode<MobilierSalleCuisine>(demanderChoix);
                case 12:
                    return MenuRechercheDonMode<Refrigerateur>(demanderChoix);
                case 13:
                    return MenuRechercheDonMode<Table>(demanderChoix);
                case 14:
                    return MenuRechercheDonMode<Vaisselle>(demanderChoix);
            }
        }
        public static Don MenuRechercheDonMode<T>(bool demanderChoix) where T : Materiel
        {
            Recherche.FonctionRecherche<Don> modeDeRechercheChoisi = InteractionUtilisateur.DemanderChoixObjet<Recherche.FonctionRecherche<Don>>("Choisir le mode de recherche :",
                new Recherche.FonctionRecherche<Don>[] {
                    Recherche.RechercheDonParStatutType<T>,
                    Recherche.RechercheDonParMoisType<T>,
                },
                new string[] { $"Recherche par statut des dons de {typeof(T).Name}", $"Recherche par mois des dons de {typeof(T).Name}" }
                );
            //on obtient la fonction de recherche correspondant au choix utilisateur


            return InteractionUtilisateur.RechercherUnElement<Don>(modeDeRechercheChoisi, demanderChoix);
        }

        public static void MenuStatistiques()
        {
            sousMenu afficherStatistiqueChoisie = InteractionUtilisateur.DemanderChoixObjet<sousMenu>("Menu :",
                 new sousMenu[] { () => Console.WriteLine(LieuStockage.MoyenneDureeStockageGenerale()),
                     () => Console.WriteLine(DepotVente.MoyennePrixGenerale()),
                     () => Console.WriteLine(Beneficiaire.MoyenneAge()),
                     () => Console.WriteLine(Beneficiaire.Count),
                     () => Console.WriteLine(Donateur.Count),
                     () => Console.WriteLine(Adherent.Count),
                     () => Console.WriteLine(Don.CountTraites<Materiel>()),
                     () => Console.WriteLine(Recherche.RechercheDonParStatutType<Materiel>("accepte").Count),
                     () => Console.WriteLine(Don.CountTraites<ObjetVolumineux>(true,new Don.StatutDon[]{Don.StatutDon.Accepte, Don.StatutDon.Stocke})/Don.CountTraites<ObjetVolumineux>(true)),
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
                         "Retour" });

            //On lance la fonction d'affichage de statistique choisie (vive les delegate parce qu'on a pas a faire un gros switch tout moche c'est formidable)
            afficherStatistiqueChoisie();
        }

        public static T MenuRecherchePersonneMode<T>(bool demanderChoix) where T : Personne
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

        public static void MenuDons()
        {
            //TODO
            sousMenu menuChoisi = InteractionUtilisateur.DemanderChoixObjet<sousMenu>("Menu :",
                 new sousMenu[] { Don.InterfaceValidationDons, () => Don.InterfaceCreation(), ()=>Menu.MenuRechercheDon(false), Menu., Rien },
                     new string[] { "Valider ou stocker un don en attente","Créer un don (celui-ci sera mis en attente de validation)", "Rechercher un don","Léguer un don à un créateur.","Quitter" });
            menuChoisi();
            //TODO : Le menu de recherche de don ce serait pas un joli p'tit bonus ca ;P ? C'etait pas demandé uwu.
        }


        public static void MenuImportation()
        {
            string nomFichier = InteractionUtilisateur.DemanderString("Chemin/Nom du fichier à importer ? (n'oubliez pas l'extension .txt)");
            sousMenu menuChoisi = InteractionUtilisateur.DemanderChoixObjet<sousMenu>("Qu'allez-vous importer ?",
                 new sousMenu[] { () => Personne.ImporterCSV<Beneficiaire>(nomFichier), () => Personne.ImporterCSV<Adherent>(nomFichier), Rien },
                     new string[] { "Des bénéficiaires", "Des adhérents", "Retour" });
            menuChoisi();
        }
    }
}
