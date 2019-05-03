using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD7_8
{
    class tmp
    {
        public class Personne
        {
            public string nom;
            public string prenom;
            public string adresse;
            public string numeroTel;

            public Personne(string nom, string prenom, string adresse, string numeroTel)
            {
                this.nom = nom;
                this.prenom = prenom;
                this.adresse = adresse;
                this.numeroTel = numeroTel;
            }
        }

        public class Adherent : Personne
        {
            public string statut;

            public Adherent(string statut, string nom, string prenom, string adresse, string numeroTel) : base(nom, prenom, adresse, numeroTel)
            {
                this.statut = statut;
            }
        }

        public class Beneficiaire : Personne
        {
            public DateTime naissance;

            public Beneficiaire(DateTime naissance, string nom, string prenom, string adresse, string numeroTel) : base(nom, prenom, adresse, numeroTel)
            {
                this.naissance = naissance;
            }
        }
    }
}
