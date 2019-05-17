using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    /// <summary>
    /// Materiel simple que l'association peut recevoir/donner/vendre. Ses propriétés dépendent du type d'objet et sont donc propres aux classes abstraites
    /// </summary>
    public abstract class Materiel : IIdentifiable
    {
        private static int dernierIdDonne = 0;
        private int idObjet;
        private double prix;

        public int Identifiant { get => idObjet; }
        public double Prix { get => prix; }

        /// <summary>
        /// Constructeur "automatique" de la classe. A chaque objet instancié, on lui donne un id correspondant à son "numéro" d'objets, prix =0
        /// <param name="prix">prix de l'objet</param>
        /// </summary>
        protected Materiel(double prix = 0)
        {
            dernierIdDonne++;
            this.idObjet = dernierIdDonne;
            this.prix = prix;
        }

        //delegate qui retourne 
        public delegate Materiel CreateurMateriel();
        public static Materiel InterfaceCreationMateriel()
        {
            
            //TODO sous menu avec un choix de quel materiel creer, qui redirige à des delegues de créations de materiels dans les sous classes.
            throw new NotImplementedException();
        }

    }

}