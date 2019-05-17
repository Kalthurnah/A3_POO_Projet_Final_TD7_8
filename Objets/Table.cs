using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    public class Table : MobilierSalleCuisine
    {
        /// <summary>
        /// Enum contenant les types de table existants
        /// </summary>
        public enum TypeTable
        {
            Cuisine,
            Salon
        }
        /// <summary>
        /// Enum contenant les formes de tables existantes
        /// </summary>
        public enum FormeTable
        {
            Rectangulaire,
            Carree,
            Ronde
        }

        private TypeTable type;
        private FormeTable forme;

        private FormeTable Forme { get => forme; }
        private TypeTable Type { get => type; }

        public Table(TypeTable type, FormeTable forme, double longueur, double largeur, double hauteur, double prix = 0) : base(longueur, largeur, hauteur, prix)
        {
            this.type = type;
            this.forme = forme;
        }
        //TODO Createur table

    }
}