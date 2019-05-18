using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    public class Donateur : Adherent
    {
        public new static int Count { get => personnes.OfType<Donateur>().Count(); }

        /// <summary>
        /// Crée une instance de la classe Donateur, selon son statut
        /// </summary>
        /// <param name="identifiant">Identifiant du donateur </param>
        /// <param name="fonction">Fonction du donateur, sous la forme <code>Adherent.Fonction.X</code>  </param>
        public Donateur(Fonction fonction, string nom, string prenom, string adresse, string numeroTel)
            : base(fonction, nom, prenom, adresse, numeroTel)
        {

        }


        static public new Personne InterfaceCreation()
        {
            Personne personneCree;
            //TODO demander details et creer 
            return personneCree = new Donateur();
        }
    }
}