using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD7_8
{
    /// <summary>
    /// Classe stockant nos delegues de fonctions de recherche pour un appel rapide
    /// </summary>
    public class Recherche
    {

        /// <summary>
        /// Fonction de recherche retournant les résultats de recherche selon une entrée fournie.
        /// <typeparam name="T">Type d'objet.</typeparam>
        /// <param name="comparaison">Paramètre de recherche : valeur que le predicat recherchera dans une des informations de l'objet.</param>
        /// <returns>Liste de résultats</returns>
        public delegate List<T> FonctionRecherche<T>(string comparaison);

        #region Dons


        public static List<Don> RechercheDonParStatutType<T>(string statutCherche) where T : Materiel
        {
            Don.StatutDon statutDonCherche;
            // TODO Annoncer lors de la demandes les choix possibles avant ? (par le biais de nomArgumentRecherche par ex ds la func de recherche)
            switch (statutCherche.ToLower())
            {
                case "accepte":
                case "accepté":
                    statutDonCherche = Don.StatutDon.Accepte;
                    break;
                case "refuse":
                case "refusé":
                    statutDonCherche = Don.StatutDon.Refuse;
                    break;
                case "stocke":
                case "stocké":
                    statutDonCherche = Don.StatutDon.Stocke;
                    break;
                default:
                    statutDonCherche = Don.StatutDon.EnAttente;
                    break;
            }
            return Don.TrouverDon<T>(don => don.Statut == statutDonCherche);
        }

        public static List<Don> RechercheDonParMoisType<T>(string moisDuDon) where T : Materiel
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

            return Don.TrouverDon<T>(don => don.DateReception.Month == mois);
        }

        #endregion

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
