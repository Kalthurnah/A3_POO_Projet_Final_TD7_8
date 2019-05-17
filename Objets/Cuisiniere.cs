using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    public class Cuisiniere : ElectroMenager, ICreableInterface<object>
    {
        private int puissance;
        private int nombrePlaques;

        public Cuisiniere(int puissance, int nombrePlaques, double longueur, double largeur, double hauteur, double prix) : base(longueur, largeur, hauteur, prix)
        {
            this.puissance = puissance;
            this.nombrePlaques = nombrePlaques;
        }

        public int NombrePlaques { get => nombrePlaques; }
        public int Puissance { get => puissance; }

        static public new Materiel InterfaceCreation()
        {
            bool valid = false;
            int nombrePlaques = 0;
            int puissance = 0;
            double longueur = 0;
            double largeur = 0;
            double hauteur = 0;
            double prix = 0;
            do
            {
                Dictionary<string, string> parametres = InteractionUtilisateur.DemanderParametres(new string[] { "puissance", "nombrePlaques", "longueur", "largeur", "hauteur", "prix" });

                try
                {
                    puissance = Convert.ToInt32(parametres["puissance"]);
                    nombrePlaques = Convert.ToInt32(parametres["nombrePlaques"]);
                    longueur = Convert.ToDouble(parametres["longueur"]);
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

            return new Cuisiniere(puissance, nombrePlaques, longueur, largeur, hauteur, prix);
        }
    }
}