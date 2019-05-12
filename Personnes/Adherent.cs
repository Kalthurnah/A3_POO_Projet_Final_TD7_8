using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        /// Identifiant de l'adhérent, non modifiable
        /// </summary>
        private int identifiant;

        /// <summary>
        /// Fonction de l'adhérent. Peut évoluer
        /// </summary>
        private Fonction fonctionAdherent;

        public Fonction FonctionAdherent { get => fonctionAdherent; set => fonctionAdherent = value; }//J'ai mis un set car il peut éventuellement être promu le petit mossieur

        /// <summary>
        /// Crée une instance de la classe Adhérent, selon son statut
        /// </summary>
        /// 
        /// <example> Cet exemple montre comment initialiser une instance de la classe <see cref="Adherent"/> 
        /// <code> 
        /// Adherent jacques = new Adherent(1,Adherent.Fonction.Membre, "DUPONT", "Jacques", "1 Rue du filou, Paris", "0123456789");
        /// </code> 
        /// </example>
        /// 
        /// <param name="identifiant">Identifiant de l'adhérent </param>
        /// <param name="fonction">Fonction de l'adhérent. Sous la forme <code>Adherent.Fonction.X</code> </param>
        public Adherent(int identifiant,Fonction fonction, string nom, string prenom, string adresse, string numeroTel) : base(nom, prenom, adresse, numeroTel)
        {
            this.identifiant = identifiant;
            this.fonctionAdherent = fonction;
        }
    }
}
