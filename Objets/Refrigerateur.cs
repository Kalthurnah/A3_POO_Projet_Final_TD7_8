using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    public class Refrigerateur : ElectroMenager, ICreableInterface<Materiel>
    {
        public Refrigerateur(double longueur, double largeur, double hauteur, double prix) : base(longueur, largeur, hauteur, prix)
        {
        }

        static public new Materiel InterfaceCreation()
        {
            bool valid = false;
            double longueur = 0;
            double largeur = 0;
            double hauteur = 0;
            double prix = 0;
            do
            {
                Dictionary<string, string> parametres = InteractionUtilisateur.DemanderParametres(new string[] { "longueur", "largeur", "hauteur", "prix" });

                try
                {
                    longueur = Convert.ToDouble(parametres["longueur"]);
                    largeur = Convert.ToDouble(parametres["largeur"]);
                    hauteur = Convert.ToDouble(parametres["largeur"]);
                    prix = Convert.ToDouble(parametres["largeur"]);
                    valid = true;
                }
                catch
                {
                    valid = false;
                }
            } while (!valid);

            return new Refrigerateur(longueur, largeur, hauteur, prix);
        }
    }
}