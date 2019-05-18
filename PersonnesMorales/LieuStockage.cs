using System;
using System.Collections.Generic;
using System.Linq;

namespace TD7_8
{
    public abstract class LieuStockage : PersonneMorale
    {
        static protected List<LieuStockage> lieuxStockage = new List<LieuStockage>();//Liste statique stockant les lieux de stockage existants.

        protected SortedList<int, Don> donsStockes;
        protected SortedList<int, DonLegue> donsLegues;

        public SortedList<int, Don> DonsStockes { get => donsStockes; }
        public SortedList<int, DonLegue> DonsLegues { get => donsLegues; }

        public LieuStockage(string nom, string prenom, string adresse, string numeroTel) : base(nom, prenom, adresse, numeroTel)
        {
            donsStockes = new SortedList<int, Don>();
            donsLegues = new SortedList<int, DonLegue>();
            lieuxStockage.Add(this);
        }

        /// <summary>
        /// Trouve les instances de lieu de stockage correspondant à la condition donnée
        /// </summary>
        /// <typeparam name="T">Type de Lieux de stockages qu'on veut obtenir</typeparam>
        /// <param name="predicat"></param>
        /// <returns></returns>
        public static List<T> TrouverInstance<T>(Predicate<T> predicat) where T : LieuStockage
        {
            List<T> lieuxStockageTypes = lieuxStockage.OfType<T>().ToList();
            return lieuxStockageTypes.FindAll(predicat);
        }

        /// <summary>
        /// Ajoute un don à la liste des dons stockés.
        /// </summary>
        /// <param name="donAAjouter"></param>
        public void StockerDon(Don donAAjouter)
        {
            donsStockes.Add(donAAjouter.Identifiant, donAAjouter);
        }

        /// <summary>
        /// Permet d'enlever un don des dons stockés et de l'ajouter à la liste des dons légués.
        /// </summary>
        /// <param name="donLegue"></param>
        public void LeguerDon(DonLegue donLegue)
        {
            donsStockes.Remove(donLegue.Identifiant);
            donsLegues.Add(donLegue.Identifiant, donLegue);
        }

        /// <summary>
        /// Permet de trouver les dons d'un certain type correspondants à la condition passée en argument.
        /// </summary>
        /// <typeparam name="M"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<Don> TrouverDon<M>(Predicate<Don> predicate) where M : Materiel
        {
            List<Don> donsTrouves = new List<Don>();
            foreach (Don don in donsStockes.Values)
            {
                if (don.TypeObjet==typeof(M) && predicate(don))
                {
                    donsTrouves.Add(don);
                }
            }
            return donsTrouves;
        }

        /// <summary>
        /// Permet de calculer la durée de stockage moyenne de tous les lieux de stockage.
        /// </summary>
        /// <returns></returns>
        public static double MoyenneDureeStockageGenerale()
        {
            double moy = 0;
            foreach (LieuStockage lieuStockage in lieuxStockage)
            {
                moy += lieuStockage.MoyenneDureeStockage();
            }
            if (lieuxStockage.Count != 0)
            {
                moy /= lieuxStockage.Count;
            }
            return moy;
        }

        /// <summary>
        /// Permet de calculer la durée de stockage moyenne d'un lieu de stockage.
        /// </summary>
        /// <returns></returns>
        public double MoyenneDureeStockage()
        {
            double moy = 0;
            foreach (DonLegue donLegue in donsLegues.Values)
            {
                moy += (donLegue.DateLegue - donLegue.RefDonInitial.DateReception).Days;
            }
            if (donsLegues.Count != 0)
            {
                moy /= lieuxStockage.Count;
            }
            return moy;
        }

        /// <summary>
        /// Permet de créer un lieu de stockage selon les saisies en console faites par l'utilisateur.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static LieuStockage InterfaceCreationLieuStockage<T>() where T : LieuStockage
        {
            LieuStockage nouveauLieu;
            Dictionary<string, string> parametres = InteractionUtilisateur.DemanderParametres(new string[] { "nom", "prenom", "adresse", "numeroTel" });
            if (typeof(T) == typeof(DepotVente))
            {
                nouveauLieu = new DepotVente(parametres["nom"], parametres["prenom"], parametres["adresse"], parametres["numeroTel"]);
            }
            else
            {
                if (typeof(T) == typeof(GardeMeuble))
                {
                    nouveauLieu = new GardeMeuble(parametres["nom"], parametres["prenom"], parametres["adresse"], parametres["numeroTel"]);
                }
                else
                {   //type association
                    nouveauLieu = new StockageAssociation(parametres["nom"], parametres["prenom"], parametres["adresse"], parametres["numeroTel"]);
                }

            }
            return nouveauLieu;

        }

    }
}