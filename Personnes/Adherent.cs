using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace TD7_8
{
    public class Adherent : Personne
    {
        /// <summary>
        /// Enum contenant les fonctions possibles des adhérents. Accédé avec
        /// <code>
        /// Adherent.Fonction.X
        /// </code>
        /// </summary>
        public enum Fonction
        {
            Tresorier,
            President,
            Membre
        };

        /// <summary>
        /// Fonction de l'adhérent. Peut évoluer
        /// </summary>
        protected Fonction fonctionAdherent;

        public Fonction FonctionAdherent { get => fonctionAdherent; set => fonctionAdherent = value; }
        public new static int Count { get => personnes.OfType<Adherent>().Count(); }

        /// <summary>
        /// Crée une instance de la classe Adhérent, selon son statut
        /// </summary>
        /// 
        /// <example> Cet exemple montre comment initialiser une instance de la classe <see cref="Adherent"/> 
        /// <code> 
        /// Adherent jacques = new Adherent(Adherent.Fonction.Membre, "DUPONT", "Jacques", "1 Rue du filou, Paris", "0123456789");
        /// </code> 
        /// </example>
        /// 
        /// <param name="fonction">Fonction de l'adhérent. Sous la forme <code>Adherent.Fonction.X</code> </param>
        public Adherent(Fonction fonction, string nom, string prenom, string adresse, string numeroTel) : base(nom, prenom, adresse, numeroTel)
        {
            this.fonctionAdherent = fonction;
        }

        public static new Personne InterfaceCreation()
        {
            Dictionary<string, string> parametres = InteractionUtilisateur.DemanderParametres(new string[] { "nom", "prénom", "adresse", "numéro de téléphone" });
            Fonction fonction = InteractionUtilisateur.DemanderChoixObjet("Renseigner sa fonction dans l'association",
                new Fonction[] { Fonction.Membre, Fonction.Tresorier, Fonction.President },
                new string[] { "Membre", "Tresorier", "President" }
                );
            return new Adherent(fonction, parametres["nom"], parametres["prénom"], parametres["adresse"], parametres["numéro de téléphone"]);
        }

        public override string ToString()
        {
            return base.ToString()+$", {fonctionAdherent}";
        }

        public void ExporterAdherents()
        {
            string[] lignes = new string[Adherent.Count];
            string ligne = "";
            List<Adherent> adherents = TrouverInstance<Adherent>(x => true);
            int i = 0;
            foreach (Adherent adherent in adherents)
            {
                ligne = adherent.nom + ";" + adherent.prenom + ";" + adherent.adresse + ";" + adherent.numeroTel + ";" + adherent.fonctionAdherent;
                lignes[i] = ligne;
                i++;
            }
            File.WriteAllLines(@"C: \Users\Public\export_adherents.txt", lignes);
        }
    }
}
