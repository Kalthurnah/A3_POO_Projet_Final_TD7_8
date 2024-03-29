﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    public class Chaise : MobilierSalleCuisine
    {
        /// <summary>
        /// Permet de créer une instance de classe Chaise
        /// </summary>
        /// <param name="longueur"></param>
        /// <param name="largeur"></param>
        /// <param name="hauteur"></param>
        /// <param name="prix"></param>
        public Chaise(double longueur, double largeur, double hauteur, double prix = 0) : base(longueur, largeur, hauteur, prix)
        {
        }

        /// <summary>
        /// Permet d'initialiser la création d'une instance de classe Chaise à partir des informations rentrées au clavier.
        /// </summary>
        /// <returns></returns>
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
            string res = $"Chaise de dimensions {Dimensions.longueur}x{Dimensions.largeur}x{Dimensions.hauteur} à {Prix}euros.";
            return res;
        }
    }
}