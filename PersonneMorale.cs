using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    class PersonneMorale : Personne
    {

        /// <summary>
        /// Enum contenant les types d'activités possibles pour une personne morale. Accédé avec
        /// <code> PersonneMorale.TypeActivite.X </code>
        /// </summary>
        public enum TypeActivite
        {
            DepotVente,
            Transporteur
        }

        private int identifiant;

        /// <summary>
        /// Type d'activité de la personne morale. Modifiable.
        /// </summary>
        private TypeActivite typeActivitePersonne;
        private TypeActivite TypeActivitePersonne { get => typeActivitePersonne; set => typeActivitePersonne = value; }

        public PersonneMorale(int identifiant, TypeActivite typeActivitePersonne, string nom, string prenom, string adresse, string numeroTel) : base(nom, prenom, adresse, numeroTel)
        {
            this.identifiant = identifiant;
            this.typeActivitePersonne = typeActivitePersonne;
        }

    }
}