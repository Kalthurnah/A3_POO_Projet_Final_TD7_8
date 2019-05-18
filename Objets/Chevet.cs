using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    public class Chevet : MobilierChambre
    {
        /// <summary>
        /// Permet de créer une instance de classe Chevet
        /// </summary>
        /// <param name="longueur"></param>
        /// <param name="largeur"></param>
        /// <param name="hauteur"></param>
        /// <param name="prix"></param>
        public Chevet(double longueur, double largeur, double hauteur, double prix = 0) : base(longueur, largeur, hauteur, prix)
        {
        }

        /// <summary>
        /// Créé une instance de classe Chevet à partir des informations rentrées par l'utilisateur.
        /// </summary>
        /// <returns></returns>
        static public new Materiel InterfaceCreation()
        {
            double longueur = InteractionUtilisateur.DemanderDouble("Entrer la longueur");
            double largeur = InteractionUtilisateur.DemanderDouble("Entrer la largeur");
            double hauteur = InteractionUtilisateur.DemanderDouble("Entrer la hauteur");
            double prix = InteractionUtilisateur.DemanderDouble("Entrer le prix");

            return new Chevet(longueur, largeur, hauteur, prix);
        }

        public override string ToString()
        {
            string res = $"Table de chevet de dimensions {Dimensions.longueur}x{Dimensions.largeur}x{Dimensions.hauteur} à {Prix}€.";
            return res;
        }
    }
}