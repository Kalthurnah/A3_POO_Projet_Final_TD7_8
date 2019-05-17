using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    public class Couvert : Vaisselle
    {
        public Couvert(int nombreDePieces,double prix=0) : base(nombreDePieces,prix)
        {
        }
        static public new Materiel InterfaceCreation()
        {
            bool valide = false;
            int nombreDePieces = 0;
            double prix = 0;
            do
            {
                Dictionary<string, string> parametres = InteractionUtilisateur.DemanderParametres(new string[] { "nombre de pieces", "prix" });

                try
                {
                    nombreDePieces = Convert.ToInt32(parametres["nombre de pieces"]);
                    prix = Convert.ToDouble(parametres["largeur"]);
                    valide = true;
                }
                catch
                {
                    valide = false;
                }
            } while (!valide);
            return new Couvert(nombreDePieces, prix);
        }
    }
}