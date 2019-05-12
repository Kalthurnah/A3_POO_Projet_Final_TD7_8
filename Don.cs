using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    public abstract class Don
    {
        private int idDon;
        private Beneficiaire beneficiaireDon;
        private string descriptionComplémentaire;
        private DateTime dateReception;
        private Type typeObjet;
        private Objet refObjet;

        public int IdDon { get => idDon; }
        public Beneficiaire BeneficiaireDon { get => beneficiaireDon; }
        public string DescriptionComplémentaire { get => descriptionComplémentaire; }
        public DateTime DateReception { get => dateReception; }
        public Type TypeObjet { get => typeObjet; }
        public Objet RefObjet { get => refObjet; }

        public Don()
        {
            throw new System.NotImplementedException();
        }


        public enum Statut
        {
            Accepte,
            Refuse,
            Stocke
        }
    }
}