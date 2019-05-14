using System;
using System.Collections.Generic;

namespace TD7_8
{
    public abstract class LieuStockage : PersonneMorale
    {
        static List<LieuStockage> lieuxStockage = new List<LieuStockage>();//Liste statique stockant les lieux de stockage existants.



        protected SortedList<DateTime, Don> donsStockes;
        protected SortedList<DateTime, DonLegue> donsLegues;

        public LieuStockage(string nom, string prenom, string adresse, string numeroTel) : base(nom, prenom, adresse, numeroTel)
        {
            donsStockes = new SortedList<DateTime, Don>();
            donsLegues = new SortedList<DateTime, DonLegue>();
            lieuxStockage.Add(this);
        }

        public void StockerDon(Don donAAjouter)
        {
            throw new NotImplementedException();
            //TODO
        }

        public DonLegue LeguerObjet()
        {
            //TODO
            throw new NotImplementedException();
        }


    }
}