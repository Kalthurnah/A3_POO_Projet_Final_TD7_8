﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    public class Chevet : MobilierChambre
    {
        public Chevet(double longueur, double largeur, double hauteur, double prix = 0) : base(longueur, largeur, hauteur, prix)
        {
        }

        static public new Materiel InterfaceCreation()
        {
            bool valid = false;
            double longueur = InteractionUtilisateur.DemanderDouble("Entrer la longueur");
            double largeur = InteractionUtilisateur.DemanderDouble("Entrer la largeur");
            double hauteur = InteractionUtilisateur.DemanderDouble("Entrer la hauteur");
            double prix = InteractionUtilisateur.DemanderDouble("Entrer le prix");

            return new Chevet(longueur, largeur, hauteur, prix);
        }
    }
}