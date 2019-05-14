using System;
using System.Collections.Generic;

namespace TD7_8
{
    public abstract class LieuStockage
    {
        private SortedList<DateTime, Don> materielStocke;
        private SortedList<DateTime, ObjetLegue> materielLegue;
    }
}