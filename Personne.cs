using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD7_8
{
    class Personne
    {
        private string nom;
        private string prenom;
        private string adresse;
        private string numeroTel;

        public string Nom { get => nom; }
        public string Prenom { get => prenom; }
        public string Adresse { get => adresse; }
        public string NumeroTel { get => numeroTel; }

        public Personne(string nom, string prenom, string adresse, string numeroTel)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.adresse = adresse;
            this.numeroTel = numeroTel;
        }
    }
}
