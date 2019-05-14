using System;
using System.Collections.Generic;

namespace TD7_8
{
    public abstract class LieuStockage
    {
        protected SortedList<DateTime, Don> materielStocke;
        protected SortedList<DateTime, ObjetLegue> materielLegue;

        public LieuStockage()
        {
            materielStocke = new SortedList<DateTime, Don>();
            materielLegue = new SortedList<DateTime, ObjetLegue>();
        }
    }
}