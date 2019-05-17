using System;
using System.Collections.Generic;
using System.Linq;

namespace TD7_8
{
    public abstract class LieuStockage : PersonneMorale
    {
        static protected List<LieuStockage> lieuxStockage = new List<LieuStockage>();//Liste statique stockant les lieux de stockage existants.



        protected SortedList<int, Don> donsStockes;
        protected SortedList<int, DonLegue> donsLegues;

        public LieuStockage(string nom, string prenom, string adresse, string numeroTel) : base(nom, prenom, adresse, numeroTel)
        {
            donsStockes = new SortedList<int, Don>();
            donsLegues = new SortedList<int, DonLegue>();
            lieuxStockage.Add(this);
        }

        public void StockerDon(Don donAAjouter)
        {
            throw new NotImplementedException();
            //TODO
        public static double MoyenneDureeStockageGenerale()
        {
            double moy = 0;
            foreach (LieuStockage lieuStockage in lieuxStockage)
            {
                moy += lieuStockage.MoyenneDureeStockage();
            }
            if (lieuxStockage.Count != 0)
            {
                moy = moy / lieuxStockage.Count;
            }
            return moy;
        }

        public double MoyenneDureeStockage()
        {
            double moy = 0;
            foreach (DonLegue donLegue in donsLegues.Values)
            {
                moy += (donLegue.DateLegue - donLegue.RefDonInitial.DateReception).Days;
            }
            if (donsLegues.Count != 0)
            {
                moy = moy / lieuxStockage.Count;
            }
            return moy;
        }


    }
}