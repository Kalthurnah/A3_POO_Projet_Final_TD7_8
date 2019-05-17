using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace TD7_8
{
    public class Beneficiaire : Personne
    {
        /// <summary>
        /// Identifiant du bénéficiaire, non modifiable
        /// </summary>

        private DateTime dateNaissance;

        public DateTime DateNaissance { get => dateNaissance; }

        public new static int Count { get => personnes.OfType<Beneficiaire>().Count<Beneficiaire>(); }

        /// <summary>
        /// Accesseur pour obtenir l'age selon l'année actuelle à l'execution. Ne calcule qu'avec les années sans se préoccuper du mois / jour
        /// </summary>
        public int Age { get => (DateTime.Now.Year - dateNaissance.Year); }


        /// <summary>
        /// Crée une instance de la classe Beneficiaire
        /// </summary>
        /// <param name="identifiant">Identifiant du bénéficiaire </param>
        /// <param name="dateNaissance">Materiel DateTime correspondant à la date de naissance du bénéficiaire</param>
        public Beneficiaire(DateTime dateNaissance, string nom, string prenom, string adresse, string numeroTel) : base(nom, prenom, adresse, numeroTel)
        {
            this.dateNaissance = dateNaissance;
        }

        public static double MoyenneAge()
        {
            double moy = 0;
            foreach (Beneficiaire beneficiaire in personnes.OfType<Beneficiaire>())
            {//On itère parmi uniquement les bénéficiaires de notre liste de personnes enregistrées.
                moy += beneficiaire.Age;
            }
            if (Count != 0)
            {
                moy = moy / Count;
            }
            return moy;
        }

        public static new Personne InterfaceCreation()
        {
            Personne personneCree;
            //TODO demander details et creer 
            return personneCree = new Beneficiaire();
        }

    }
}