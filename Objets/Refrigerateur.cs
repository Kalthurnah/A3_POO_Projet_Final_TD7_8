using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    public class Refrigerateur : ElectroMenager
    {
        public Refrigerateur(double longueur, double largeur, double hauteur, double prix) : base(longueur, largeur, hauteur,prix)
        {
        }
    }
}