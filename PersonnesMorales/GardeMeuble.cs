using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    public class GardeMeuble : LieuStockage
    {
        public static int Count { get => lieuxStockage.OfType<GardeMeuble>().Count<GardeMeuble>(); }

        public GardeMeuble(string nom, string prenom, string adresse, string numeroTel) : base(nom, prenom, adresse, numeroTel)
        {
        }
    }
}