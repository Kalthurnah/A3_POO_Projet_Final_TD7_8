using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    public abstract class ElectroMenager : ObjetVolumineux
    {

        protected ElectroMenager(double longueur, double largeur, double hauteur, double prix=0) : base(longueur, largeur, hauteur,prix)
        {
        }


    }
}