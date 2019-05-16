using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    public class Armoire : MobilierChambre
    {
        public Armoire(double longueur, double largeur, double hauteur, double prix=0) : base(longueur, largeur, hauteur, prix)
        {
        }
    }
}