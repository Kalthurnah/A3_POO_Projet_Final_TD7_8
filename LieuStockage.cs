using System;
using System.Collections.Generic;

namespace TD7_8
{
    public abstract class LieuStockage : IIdentifiable
    {
        static List<LieuStockage> lieuxStockage = new List<LieuStockage>();
        static int dernierIdDonne = 0;

        private int identifiant;
        protected SortedList<DateTime, Don> materielStocke;
        protected SortedList<DateTime, DonLegue> materielLegue;

        public int Identifiant { get => identifiant; }

        public LieuStockage()
        {
            dernierIdDonne++;
            identifiant = dernierIdDonne;
            materielStocke = new SortedList<DateTime, Don>();
            materielLegue = new SortedList<DateTime, DonLegue>();
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