using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    public class Refrigerateur : ElectroMenager
    {
        public Refrigerateur(double longueur, double largeur, double hauteur, double prix) : base(longueur, largeur, hauteur, prix)
        {
        }

        static public new Materiel InterfaceCreation()
        {
            double longueur = InteractionUtilisateur.DemanderDouble("Entrer la longueur");
            double largeur = InteractionUtilisateur.DemanderDouble("Entrer la largeur");
            double hauteur = InteractionUtilisateur.DemanderDouble("Entrer la hauteur");
            double prix = InteractionUtilisateur.DemanderDouble("Entrer le prix");
            return new Refrigerateur(longueur, largeur, hauteur, prix);
        }

        public override string ToString()
        {
            string res = $"Réfrigérateur de dimensions {Dimensions.longueur}x{Dimensions.largeur}x{Dimensions.hauteur} à {Prix}euros.";
            return res;
        }
    }
}