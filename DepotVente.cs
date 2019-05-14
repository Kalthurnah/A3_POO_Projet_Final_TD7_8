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
        public DepotVente()
        {
            solde = 1000;
        }

        public double Solde { get => solde; }
        //Todo override Add pour ajouter le solde
        

        //Todo Moyenne
    }
}