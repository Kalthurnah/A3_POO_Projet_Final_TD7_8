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

        public int IdObjet { get => idObjet; }

        /// <summary>
        /// Constructeur "automatique" de la classe objet. A chaque objet instancié, on lui donne un id correspondant à son "numéro" d'objets.
        /// </summary>
        protected Materiel()
        {
            nbObjets++;
            this.idObjet = nbObjets;
        }
    }

}