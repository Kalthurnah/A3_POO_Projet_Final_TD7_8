using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    /// <summary>
    /// Classe représentant un objet qui a été légué par l'association (donné ou vendu) à un bénéficiaire.
    /// </summary>
    public class ObjetLegue
    {
        private Materiel refObjet;
        private Type typeObjet;
        private string description;
        private double prix;
        private Beneficiaire beneficiaireObjet;
        private LieuStockage lieuDeStockage;

        public LieuStockage LieuDeStockage { get => lieuDeStockage; }
        public string Description { get => description; }
        public double Prix { get => prix; }
        public Type Type { get => typeObjet; }
        public Materiel RefObjet { get => refObjet; }
        public Beneficiaire BeneficiaireObjet { get => beneficiaireObjet; }
    }
}