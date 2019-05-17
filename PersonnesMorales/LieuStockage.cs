using System;
using System.Collections.Generic;

namespace TD7_8
{
    public abstract class LieuStockage : PersonneMorale
    {
        static List<LieuStockage> lieuxStockage = new List<LieuStockage>();//Liste statique stockant les lieux de stockage existants.



        protected SortedList<DateTime, Don> donsStockes;
        protected SortedList<DateTime, DonLegue> donsLegues;

        public LieuStockage(string nom, string prenom, string adresse, string numeroTel) : base(nom, prenom, adresse, numeroTel)
        {
            donsStockes = new SortedList<DateTime, Don>();
            donsLegues = new SortedList<DateTime, DonLegue>();
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


        public void StockerDon(Don donAAjouter)
        {
            donsStockes.Add(donAAjouter.Identifiant, donAAjouter);
        }

        public static double MoyenneDureeStockageGenerale()
        {
            double moy = 0;
            foreach (LieuStockage lieuStockage in lieuxStockage)
            {
                moy += lieuStockage.MoyenneDureeStockage();
            }
            if (lieuxStockage.Count != 0)
            {
                moy = moy / lieuxStockage.Count;
            }
            return moy;
        }

        public DonLegue LeguerObjet()
        {
            //TODO
            throw new NotImplementedException();
        }

        public DonLegue LeguerDon(Don donALeguer, Beneficiaire beneficiaire, DateTime dateLeguee)
        {
            DonLegue donLegue = new DonLegue(donALeguer, beneficiaire, dateLeguee);
            donsStockes.Remove(donLegue.Identifiant);
            return donLegue;
        }


    }
}