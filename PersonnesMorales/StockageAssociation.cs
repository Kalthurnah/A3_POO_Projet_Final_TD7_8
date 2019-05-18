using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    public class StockageAssociation : LieuStockage
    {
        public StockageAssociation(string nom, string adresse, string numeroTel) : base(nom, adresse, numeroTel)
        {
        }
    }
}