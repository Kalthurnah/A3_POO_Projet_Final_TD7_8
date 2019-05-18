using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    public class Chaise : MobilierSalleCuisine
    {
        public Chaise(double longueur, double largeur, double hauteur, double prix = 0) : base(longueur, largeur, hauteur, prix)
        {
        }

        static public new Materiel InterfaceCreation()
        {

            double longueur = InteractionUtilisateur.DemanderDouble("Entrer la longueur");
            double largeur = InteractionUtilisateur.DemanderDouble("Entrer la largeur");
            double hauteur = InteractionUtilisateur.DemanderDouble("Entrer la hauteur");
            double prix = InteractionUtilisateur.DemanderDouble("Entrer le prix");

            return new Chaise(longueur, largeur, hauteur, prix);
        }

        public override string ToString()
        {
            string res = $"Chaise de dimensions {base.Dimensions} à {base.Prix}€.";
            return base.ToString();
        }
    }
}