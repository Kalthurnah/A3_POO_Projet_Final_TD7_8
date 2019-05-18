using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    public class Cuisiniere : ElectroMenager
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
            double longueur = InteractionUtilisateur.DemanderDouble("Entrer la longueur");
            double largeur = InteractionUtilisateur.DemanderDouble("Entrer la largeur");
            double hauteur = InteractionUtilisateur.DemanderDouble("Entrer la hauteur");
            double prix = InteractionUtilisateur.DemanderDouble("Entrer le prix");
            int nombrePlaques = 0;
            int puissance = 0;
            bool valid = false;
            do
            {
                Dictionary<string, string> parametres = InteractionUtilisateur.DemanderParametres(new string[] { "puissance", "nombrePlaques" });

                try
                {
                    puissance = Convert.ToInt32(parametres["puissance"]);
                    nombrePlaques = Convert.ToInt32(parametres["nombrePlaques"]);
                    valid = true;
                }
                catch
                {
                    valid = false;
                }
            } while (!valid);

            return new Cuisiniere(puissance, nombrePlaques, longueur, largeur, hauteur, prix);
        }

        public override string ToString()
        {
            string res = $"Cuisinière à {nombrePlaques} plaques, de dimensions {Dimensions.longueur}x{Dimensions.largeur}x{Dimensions.hauteur}, de puissance {puissance}W à {Prix}euros.";
            return res;
        }
    }
}