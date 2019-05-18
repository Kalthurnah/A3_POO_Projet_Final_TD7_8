using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    /// <summary>
    /// Classe représentant un don qui a été légué par l'association (donné ou vendu) à un bénéficiaire.
    /// </summary>
    public class DonLegue : IIdentifiable
    {
        //Liste des dons légués. Les dons initiaux correspondants à ceux ci sont toujours stockes dans Don.donsArchives
        static List<DonLegue> donsLegues = new List<DonLegue>();
        private Materiel objet;
        private Type typeObjet;
        private Don DonInitial;
        private string description;
        private Beneficiaire beneficiaireObjet;
        private LieuStockage lieuStockage;
        private double montant;
        private DateTime dateLegue;

        public static List<DonLegue> DonsLegues { get => donsLegues; }
        public LieuStockage LieuStockage { get => lieuStockage; }
        public string Description { get => description; }
        public double Montant { get => montant; }
        public Type Type { get => typeObjet; }
        public Materiel Objet { get => objet; }
        public Beneficiaire BeneficiaireObjet { get => beneficiaireObjet; }
        public Don RefDonInitial { get => DonInitial; }
        public DateTime DateLegue { get => dateLegue; }

        public int Identifiant { get => objet.Identifiant; }

        /// <summary>
        /// Constructeur de donLegue. Retirer l'élément de la liste des dons dispos doit être fait après l'avoir légué - ie pour leguer un don appeler don.Leguer !!
        /// </summary>
        /// <param name="DonALeguer"></param>
        /// <param name="beneficiaireObjet"></param>
        /// <param name="dateLegue"></param>
        public DonLegue(Don DonALeguer, Beneficiaire beneficiaireObjet, DateTime dateLegue)
        {
            //On obtient les infos depuis le don initial
            this.DonInitial = DonALeguer;
            this.objet = DonALeguer.Objet;
            this.typeObjet = DonALeguer.TypeObjet;
            this.montant = DonALeguer.Objet.Prix;
            this.dateLegue = dateLegue;
            this.description = DonALeguer.DescriptionComplementaire;
            this.beneficiaireObjet = beneficiaireObjet;
            this.lieuStockage = DonALeguer.LieuStockageDon;

            //On ajoute le don à la liste des dons légués
            donsLegues.Add(this);
        }


        public static DonLegue InterfaceLeguerDon()
        {
            Don donALeguer = Menu.MenuRechercheDon(demanderChoix:true);
            Beneficiaire beneficiaire = Menu.MenuRecherchePersonneMode<Beneficiaire>(demanderChoix:true);
            DateTime dateLegue = InteractionUtilisateur.DemanderDateTime("Rentrer la date à laquelle le don a été légué.");
            return donALeguer.Leguer(beneficiaire,dateLegue);
        }

    }
}