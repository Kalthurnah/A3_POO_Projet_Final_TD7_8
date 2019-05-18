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
        protected Materiel(double prix)
        {
            dernierIdDonne++;
            this.idObjet = dernierIdDonne;
            this.prix = prix;
        }

        /// <summary>
        /// Delegate ayant pour but la création de matériel.
        /// </summary>
        /// <returns></returns>
        public delegate Materiel CreateurMateriel();
        /// <summary>
        /// Interface permettant la création d'un objet en fonction du type voulu par l'utilisateur.
        /// Renvoie aux interfaces de créations de chaque objet précis
        /// </summary>
        /// <returns></returns>
        public static Materiel InterfaceCreation()
        {
            CreateurMateriel createurChoisi = InteractionUtilisateur.DemanderChoixObjet<CreateurMateriel>("Quel est le type de matériel à créer ?",
                new CreateurMateriel[] { Refrigerateur.InterfaceCreation,
                    LaveLinge.InterfaceCreation,
                    Chaise.InterfaceCreation,
                    Chevet.InterfaceCreation,
                    Armoire.InterfaceCreation,
                    Matelas.InterfaceCreation,
                    Couvert.InterfaceCreation,
                    Assiette.InterfaceCreation,
                    Cuisiniere.InterfaceCreation,
                    Table.InterfaceCreation},
             new string[] { "Réfrigérateur",
                 "Lave-Linge",
                 "Chaise",
                 "Chevet",
                 "Armoire",
                 "Matelas",
                 "Couvert",
                 "Assiette",
                 "Cuisinière",
                 "Table"}
             );
            Materiel materielCree = createurChoisi();//Lance l'interface de création pour l'objet choisi.
            return materielCree;
        }

    }

}