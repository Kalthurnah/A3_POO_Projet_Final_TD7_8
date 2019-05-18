using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    public class Assiette : Vaisselle
    {
        public Assiette(int nombreDePieces, double prix=0) : base(nombreDePieces,prix)
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
                    prix = InteractionUtilisateur.DemanderDouble("Entrer le prix");
                    valide = true;
                }
                catch
                {
                    valide = false;
                }
            } while (!valide);
            return new Assiette(nombreDePieces, prix);
        }
    }
}