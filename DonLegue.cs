﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    /// <summary>
    /// Classe représentant un don qui a été légué par l'association (donné ou vendu) à un bénéficiaire.
    /// </summary>
    public class DonLegue
    {
        private Materiel objet;
        private string idObjet;
        private Type typeObjet;
        private Don refDonInitial;
        private string description;
        private Beneficiaire beneficiaireObjet;
        private LieuStockage lieuStockage;
        private double montant;
        private DateTime dateLegue;

        public LieuStockage LieuStockage { get => lieuStockage; }
        public string Description { get => description; }
        public double Montant { get => montant; }
        public Type Type { get => typeObjet; }
        public Materiel Objet { get => objet; }
        public Beneficiaire BeneficiaireObjet { get => beneficiaireObjet; }
        public Don RefDonInitial { get => refDonInitial; }
        public DateTime DateLegue { get => dateLegue; }

        public DonLegue(Don DonALeguer, Beneficiaire beneficiaireObjet, DateTime dateLegue)
        {
            //On obtient les infos depuis le don initial
            this.refDonInitial = DonALeguer;
            this.objet = DonALeguer.Objet;
            this.typeObjet = DonALeguer.TypeObjet;
            this.montant = DonALeguer.Objet.Prix;

            this.description = DonALeguer.DescriptionComplementaire;
            this.beneficiaireObjet = beneficiaireObjet;
            this.lieuStockage = DonALeguer.LieuStockageDon;

            //TODO ARCHIVER UN DON EN LE LEGUANT ?
        }

    }
}