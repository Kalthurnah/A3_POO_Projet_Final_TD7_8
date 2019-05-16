using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    public class Cuisiniere : ElectroMenager
    {
        private int puissance;
        private int nombrePlaques;

        public Cuisiniere(int puissance, int nombrePlaques, double longueur, double largeur, double hauteur, double prix) : base(longueur, largeur, hauteur, prix)
        {
            this.puissance = puissance;
            this.nombrePlaques = nombrePlaques;
        }

        public int NombrePlaques { get => nombrePlaques; }
        public int Puissance { get => puissance; }
    }
}