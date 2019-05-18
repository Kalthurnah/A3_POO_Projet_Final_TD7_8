using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    public abstract class ObjetVolumineux : Materiel
    {
        public struct Dimension
        {
            public double longueur;
            public double largeur;
            public double hauteur;
        }

        protected Dimension dimensions;

        protected double volume;


        public Dimension Dimensions { get => dimensions; }
        public double Volume { get => volume; }

        /// <summary>
        /// Constructeur d'un objet volumineux depuis ses dimensions données
        /// </summary>
        /// <param name="longueur">longueur de l'objet</param>
        /// <param name="largeur">largeur de l'objet</param>
        /// <param name="hauteur">hauteur de l'objet</param>
        protected ObjetVolumineux(double longueur, double largeur, double hauteur,double prix):base(prix)
        {
            dimensions.longueur = longueur;
            dimensions.largeur = largeur;
            dimensions.hauteur = hauteur;

            MettreAJourVolume();//Mets à jour l'attribut volume selon les dimensions que l'on vient d'attribuer
        }



        /// <summary>
        /// Méthode d'instance qui met à jour l'attribut du volume de l'objet depuis ses dimensions 
        /// </summary>
        protected void MettreAJourVolume()
        {
            volume = CalculerVolume(dimensions);//On recalcule le volume de l'objet à partir de ses dimensions, et on met à jour l'attribut volume en conséquence.
        }

        /// <summary>
        /// Méthode de classe calculant un volume depuis des dimensions
        /// </summary>
        /// <param name="dimensions">dimensions dont on veut calculer le volume</param>
        /// <returns>Volume correspondant aux dimensions passées</returns>
        private static double CalculerVolume(Dimension dimensions)
        {
            return dimensions.longueur * dimensions.largeur * dimensions.hauteur;
        }
    }
}