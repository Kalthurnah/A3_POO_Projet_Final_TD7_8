using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    public class Couvert : Vaisselle
    {
        public Couvert(int nombreDePieces, double prix = 0) : base(nombreDePieces, prix)
        {
        }

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
    }
}