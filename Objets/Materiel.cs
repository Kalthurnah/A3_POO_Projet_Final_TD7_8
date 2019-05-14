using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    /// <summary>
    /// Materiel simple que l'association peut recevoir/donner/vendre. Ses propriétés dépendent du type d'objet et sont donc propres aux classes abstraites
    /// </summary>
    public abstract class Materiel
    {
        private static int nbObjets=0;//Compte le nombre d'objets instanciés
        private int idObjet;
        private double prix;

        public int IdObjet { get => idObjet; }
        public double Prix { get => prix; }

        /// <summary>
        /// Constructeur "automatique" de la classe objet. A chaque objet instancié, on lui donne un id correspondant à son "numéro" d'objets, prix =0
        /// </summary>
        protected Materiel()
        {
            nbObjets++;
            this.idObjet = nbObjets;
            prix = 0;
        }
        /// <summary>
        /// Constructeur permettant de spécifier le prix.
        /// </summary>
        /// <param name="prix"></param>
        protected Materiel(double prix):this()
        {
            this.prix = prix;
        }
    }

}