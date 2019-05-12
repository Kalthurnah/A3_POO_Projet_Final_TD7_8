using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    public class MobilierSalleCuisine : ObjetVolumineux
    {
        private int forme;
        private int piece;

        public MobilierSalleCuisine()
        {
            throw new System.NotImplementedException();
        }

        public enum TypeCuisine
        {
            Table,
            Chaise
        }
    }
}