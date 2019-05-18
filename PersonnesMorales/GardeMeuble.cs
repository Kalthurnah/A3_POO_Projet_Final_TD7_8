using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    public class GardeMeuble : LieuStockage
    {
        public GardeMeuble(string nom, string adresse, string numeroTel) : base(nom, adresse, numeroTel)
        {
        }

        public override string ToString()
        {
            string res = $"Garde meuble : {nom}, {adresse}, {numeroTel}.";
            return res;
        }
    }
}