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
        public DepotVente() : base()
        {
            solde = 1000;
        }

        public double Solde { get => solde; }
        //Todo override Add pour ajouter le solde


        //On retourne la moyenne du prix des objets présents dans le DepotVente
        public double MoyennePrix()
        {

            double moy = 0;// On initialise la moyenne à zéro
            int nb = materielStocke.Count();// On stocke la taille de notre liste de matériel
            // Pour chaque don dans cette liste on ajoute la valeur de l'objet à la moyenne
            foreach (Don don in materielStocke.Values)
            {
                moy = moy + don.Objet.Prix;
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