using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    public class Couvert : Vaisselle
    {
        /// <summary>
        /// Permet de créer une instance de la classe Couvert.
        /// </summary>
        /// <param name="nombreDePieces"></param>
        /// <param name="prix"></param>
        public Couvert(int nombreDePieces, double prix = 0) : base(nombreDePieces, prix)
        {
        }

        /// <summary>
        /// Initialise la création d'une instance de la classe Couvert à partir des informations données par l'utilsateur.
        /// </summary>
        /// <returns></returns>
        static public new Materiel InterfaceCreation()
        {
            bool valide = false;
            int nombreDePieces = 0;
            double prix = 0;
            do
            {
                try
                {
                    nombreDePieces = Convert.ToInt32(InteractionUtilisateur.DemanderDouble("Entrer le nombre de pieces"));
                    valide = true;
                }
                catch
                {
                    valide = false;
                }
            } while (!valide);
            prix = InteractionUtilisateur.DemanderDouble("Entrer le prix");
            return new Couvert(nombreDePieces, prix);
        }

        public override string ToString()
        {
            string res = $"Ensemble de {base.NombreDePieces} couverts à {base.Prix}€.";
            return res;
        }
    }
}