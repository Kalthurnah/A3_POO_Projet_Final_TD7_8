using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    public class PersonneMorale : Personne
    {

        public new static int Count { get => CompterPersonnesTypees<PersonneMorale>(); }
        /// <summary>
        /// Enum contenant les types d'activités possibles pour une personne morale. Accédé avec
        /// <code> PersonneMorale.TypeActivite.X </code>
        /// </summary>
        public enum TypeActivite
        {
            DepotVente,
            Transporteur
        }


        /// <summary>
        /// Type d'activité de la personne morale. Modifiable.
        /// </summary>
        private TypeActivite typeActivitePersonne;
        private TypeActivite TypeActivitePersonne { get => typeActivitePersonne; set => typeActivitePersonne = value; }

        public PersonneMorale(TypeActivite typeActivitePersonne, string nom, string prenom, string adresse, string numeroTel) : base(nom, prenom, adresse, numeroTel)
        {
            this.typeActivitePersonne = typeActivitePersonne;
        }

    }
}