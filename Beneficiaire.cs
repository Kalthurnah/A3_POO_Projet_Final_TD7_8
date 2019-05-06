using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    class Beneficiaire : Personne
    {
        /// <summary>
        /// Identifiant du bénéficiaire, non modifiable
        /// </summary>
        private int identifiant;

        private DateTime dateNaissance;

        public DateTime DateNaissance { get => dateNaissance; }


        /// <summary>
        /// Crée une instance de la classe Beneficiaire
        /// </summary>
        /// <param name="identifiant">Identifiant du bénéficiaire </param>
        /// <param name="dateNaissance">Objet DateTime correspondant à la date de naissance du bénéficiaire</param>
        public Beneficiaire(int identifiant, DateTime dateNaissance,string nom, string prenom, string adresse, string numeroTel) : base(nom, prenom, adresse, numeroTel)
        {
            this.identifiant = identifiant;
            this.dateNaissance = dateNaissance;
        }

    }
}