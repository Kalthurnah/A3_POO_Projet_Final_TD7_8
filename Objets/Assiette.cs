﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    public class Assiette : Vaisselle
    {
        /// <summary>
        /// Permet de créer une instance de classe Assiette
        /// </summary>
        /// <param name="nombreDePieces"></param>
        /// <param name="prix"></param>
        public Assiette(int nombreDePieces, double prix=0) : base(nombreDePieces,prix)
        {
        }

        /// <summary>
        /// Permet de créer une instance Assiette à partir des informations rentrées au clavier par l'utilisateur.
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

        public override string ToString()
        {
            string res = $"Ensemble de {base.NombreDePieces} assiettes à {base.Prix}euros.";
            return res;
        }

    }
}