using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD7_8
{
    public class Recherche
    {

        /// <summary>
        /// Fonction de recherche retournant les résultats de recherche selon une entrée donnée
        /// <typeparam name="T">Type d'objet.</typeparam>
        /// <param name="comparaison">Paramètre de recherche : valeur que le predicat recherchera dans une des informations de l'objet.</param>
        /// <returns>Liste de résultats</returns>
        public delegate List<T> FonctionRecherche<T>(string comparaison);

        #region Dons

        //TODO REMOVE !! Inutile ! Mais garder le format de delegate pr les tris avec des IComparer ?
        //Todo jeter un oeil au "multi-delegate"
        public static FonctionRecherche<Don> RechercheParMoisDon = delegate (string moisDuDon)
         {
             int mois = 0;
             try
             {
                 mois = Convert.ToInt32(moisDuDon);
             }
             catch
             {
                 return new List<Don>();
             }

             return Don.TrouverDon(don => don.DateReception.Month == mois);
         };


        public static FonctionRecherche<Don> RechercheDonStatut = delegate (string statut)
        {
            Don.StatutDon statutCherche;
            switch (statut.ToLower())
            {
                case "accepte":
                    statutCherche = Don.StatutDon.Accepte;
                    break;
                case "refuse":
                    statutCherche = Don.StatutDon.Refuse;
                    break;
                case "stocke":
                    statutCherche = Don.StatutDon.Stocke;
                    break;
                default:
                    statutCherche = Don.StatutDon.EnAttente;
                    break;
            }

            return Don.TrouverDon(don => don.Statut == statutCherche);
        };

        #endregion

        //Delegate définies anonymement, lambda à l'intérieur, delegate définies pas anonymement ci dessous... On a fait le tour :P !!

        #region Personnes

        /// <summary>
        /// Trouve une personne par type et par nom
        /// </summary>
        /// <typeparam name="T">Type de personnes : Adhérents, donateurs, bénéficiares...</typeparam>
        /// <param name="nomCherche">nom recherché</param>
        /// <returns>Liste de résultats</returns>
        public static List<T> RechercheParNomPersonneTypee<T>(string nomCherche) where T : Personne
        {
            return Personne.TrouverInstance<T>(objet => objet.Nom.Contains(nomCherche));
        }

        /// <summary>
        /// Trouve une personne par type et par numéro de téléphone
        /// </summary>
        /// <typeparam name="T">Type de personnes : Adhérents, donateurs, bénéficiares...</typeparam>
        /// <param name="nomCherche">nom recherché</param>
        /// <returns>Liste de résultats</returns>
        public static List<T> RechercheParNumTelPersonneTypee<T>(string numTelCherche) where T : Personne
        {
            return Personne.TrouverInstance<T>(objet => objet.NumeroTel == numTelCherche);
        }

        #endregion

        #region Lieux de Stockage

        /// <summary>
        /// Trouve une personne par type et par nom
        /// </summary>
        /// <typeparam name="T">Type de personnes : Adhérents, donateurs, bénéficiares...</typeparam>
        /// <param name="nomCherche">nom recherché</param>
        /// <returns>Liste de résultats</returns>
        public static List<T> RechercheParNomLieuStockageType<T>(string nomCherche) where T : LieuStockage
        {
            return LieuStockage.TrouverInstance<T>(objet => objet.Nom.Contains(nomCherche));
        }

        #endregion


    }
}
