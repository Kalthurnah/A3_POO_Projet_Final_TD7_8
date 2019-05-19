using System;
using System.Collections.Generic;

namespace TD7_8
{
    class Tri
    {
        /// <summary>
        /// Fonction retournant pour un Don don une propriété de ce don sur laquelle on peut effectuer une comparaison.
        /// </summary>
        /// <typeparam name="T">Type de la propriété du don. Doit être comparable.</typeparam>
        /// <param name="don">don dont on veut obtenir une propriété</param>
        /// <returns>Propriété d'un don</returns>
        public delegate T FonctionObtentionProprieteDon<T>(Don don) where T : IComparable<T>;
        public delegate T FonctionObtentionProprieteDonLegue<T>(DonLegue donLegue) where T : IComparable<T>;

        /// <summary>
        /// Fonction retournant une liste de dons refusés, triés selon la propriété dont on a le get en argument
        /// </summary>
        /// <typeparam name="T">Type de l'élément à comparer</typeparam>
        /// <param name="fonctionObtentionPropriete">fonction donnant la propriété à comparer </param>
        /// <returns>liste triée de dons refusés</returns>
        public static List<Don> TriRefuse<T>(FonctionObtentionProprieteDon<T> fonctionObtentionPropriete) where T : IComparable<T>
        {
            List<Don> donsRefusesParDate = Don.TrouverDon(don => don.Statut == Don.StatutDon.Refuse);
            donsRefusesParDate.Sort((x, y) => fonctionObtentionPropriete(x).CompareTo(fonctionObtentionPropriete(y)));
            return donsRefusesParDate;
        }

        /// <summary>
        /// Fonction retournant une liste de dons acceptés ou stockés, triés selon la propriété dont on a le get en argument        
        /// </summary>
        /// <example>
        /// <code>
        /// TriAccepteStocke<int>(x => x.Identifiant);
        /// </code>
        /// </example>
        /// <typeparam name="T">Type de l'élément à comparer</typeparam>
        /// <param name="fonctionObtentionPropriete">fonction donnant la propriété à comparer </param>
        /// <returns>liste triée de dons acceptés ou stockés</returns>
        public static List<Don> TriAccepteStocke<T>(FonctionObtentionProprieteDon<T> fonctionObtentionPropriete) where T : IComparable<T>
        {
            List<Don> donsAccepteStocke = Don.TrouverDon(don => don.Statut == Don.StatutDon.Accepte || don.Statut == Don.StatutDon.Stocke);
            donsAccepteStocke.Sort((x, y) => fonctionObtentionPropriete(x).CompareTo(fonctionObtentionPropriete(y)));
            return donsAccepteStocke;
        }

        /// <summary>
        /// Fonction retournant une liste de dons légués, triés selon la propriété dont on a le get en argument
        /// </summary>
        /// <typeparam name="T">Type de l'élément à comparer</typeparam>
        /// <param name="fonctionObtentionPropriete">fonction donnant la propriété à comparer </param>
        /// <returns>liste triée de dons légués acceptés ou stockés</returns>
        public static List<DonLegue> TriVenduDonne<T>(FonctionObtentionProprieteDonLegue<T> fonctionObtentionPropriete) where T : IComparable<T>
        {
            List<DonLegue> donsVendusDonnes = new List<DonLegue>();
            donsVendusDonnes = DonLegue.DonsLegues;
            donsVendusDonnes.Sort((x, y) => fonctionObtentionPropriete(x).CompareTo(fonctionObtentionPropriete(y)));
            return donsVendusDonnes;
        }

        /// <summary>
        /// Fonction retournant une liste de dons stockés dont l'objet est de type M, triés selon la propriété dont on a le get en argument
        /// </summary>
        /// <typeparam name="T">Type de l'élément à comparer</typeparam>
        /// <typeparam name="M">Type de l'objet du don. Par exemple Materiel</typeparam>
        /// <param name="fonctionObtentionPropriete">fonction donnant la propriété à comparer </param>
        /// <param name="lieuStockage">Instance du lieu de stockage dans laquelle chercher</param>
        /// <returns>liste triée de dons stockés</returns>
        public static List<Don> TriLieuStockage<M, T>(LieuStockage lieuStockage, FonctionObtentionProprieteDon<T> fonctionObtentionPropriete) where T : IComparable<T> where M : Materiel
        {
            List<Don> donsStockes = lieuStockage.TrouverDon<M>(don => don.LieuStockageDon == lieuStockage);
            donsStockes.Sort((x, y) => fonctionObtentionPropriete(x).CompareTo(fonctionObtentionPropriete(y)));

            return donsStockes;
        }

        /// <summary>
        /// Fonction demandant à l'utilisateur de choisir une instance de lieu de stockage, puis retournant une liste de dons stockés dedans dont l'objet est de type M, triés selon la propriété dont on a le get en argument
        /// </summary>
        /// <typeparam name="T">Type de l'élément à comparer</typeparam>
        /// <typeparam name="M">Type de l'objet du don. Par exemple Materiel</typeparam>
        /// <param name="message">Message à afficher avant la liste d'objets</param>
        /// <param name="fonctionObtentionPropriete"></param>
        public static void sousMenuTriLieuStockage<M, T>(string message, FonctionObtentionProprieteDon<T> fonctionObtentionPropriete) where T : IComparable<T> where M : Materiel
        {

            LieuStockage lieuStockageDon = InteractionUtilisateur.RechercherUnElement(Recherche.RechercheParNomLieuStockageType<LieuStockage>, true, "nom (Ne rien entrer les affichera tous.)");
            InteractionUtilisateur.ListerObjets<Don>(message, TriLieuStockage<M, T>(lieuStockageDon, fonctionObtentionPropriete));

        }
        /// <summary>
        /// Fonction affichant dans l'ordre les catégories les plus fréquentes des objets stockés.
        /// </summary>
        public static void AfficherPrincipalesCategoriesEnStock()
        {

            foreach (KeyValuePair<string, int> element in Don.ObtenirTypesStockesParFrequence())
            {
                Console.WriteLine($"{element.Key} : {element.Value} en stock");
            }

        }
    }
}
