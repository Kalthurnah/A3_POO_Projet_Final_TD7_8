using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    class Donateur : Adherent
    {
        /// <summary>
        /// Crée une instance de la classe Donateur, selon son statut
        /// </summary>
        /// <param name="identifiant">Identifiant du donateur </param>
        /// <param name="fonction">Fonction du donateur, sous la forme <code>Adherent.Fonction.X</code>  </param>
        public Donateur(int identifiant, Fonction fonction, string nom, string prenom, string adresse, string numeroTel)
            : base(identifiant, fonction, nom, prenom, adresse, numeroTel)
        {

        }
    }
}