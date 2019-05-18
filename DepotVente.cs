using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    public class DepotVente : LieuStockage
    {
        double solde;

        /// <summary>
        /// A la création du dépot vente, son solde est de 1000€
        /// </summary>
        public DepotVente(string nom, string prenom, string adresse, string numeroTel) : base(nom, prenom, adresse, numeroTel)
        {
            solde = 1000;
        }

        public double Solde { get => solde; }
        //Todo override Add element dans le dépot vente pour incrémenter le solde en plus de rajouter l'élém ds la liste
        //Idem pr Delete

        public static int Count { get => lieuxStockage.OfType<DepotVente>().Count<DepotVente>(); }

        /// <summary>
        /// Permet de calculer la moyenne du prix des objets stockés dans tous les dépots-ventes.
        /// </summary>
        /// <returns></returns>
        public static double MoyennePrixGenerale()
        {
            double moyenne = 0;
            foreach (DepotVente depotVente in lieuxStockage.OfType<DepotVente>())
            {
                moyenne = moyenne + depotVente.MoyennePrix();
            }
            if (Count != 0)
            {
                moyenne = moyenne / Count;
            }
            return moyenne;
        }

        /// <summary>
        /// Permet de calculer la moyenne du prix des objets stockés dans un dépot-vente.
        /// </summary>
        /// <returns></returns>
        public double MoyennePrix()
        {

            double moy = 0;// On initialise la moyenne à zéro
            int nb = donsStockes.Count();// On stocke la taille de notre liste de matériel
                                         // Pour chaque don dans cette liste on ajoute la valeur de l'objet à la moyenne
            foreach (Don don in donsStockes.Values)
            {
                moy += don.Objet.Prix;
            }
            // Si le nombre n'est pas nul (donc s'il y a des objets stockés) on divise la moyenne par le nombre d'objet.
            // Dans le cas où nb=0, la moyenne est toujours nulle puisque l'on est pas rentré dans le foreach
            if (nb != 0)
            {
                moy = moy / nb;
            }
            return moy;
        }
    }
}