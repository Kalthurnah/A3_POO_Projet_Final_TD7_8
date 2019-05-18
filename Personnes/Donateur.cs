using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    public class Donateur : Adherent
    {
        public new static int Count { get => personnes.OfType<Donateur>().Count(); }

        /// <summary>
        /// Crée une instance de la classe Donateur, selon son statut
        /// </summary>
        /// <param name="identifiant">Identifiant du donateur </param>
        /// <param name="fonction">Fonction du donateur, sous la forme <code>Adherent.Fonction.X</code>  </param>
        public Donateur(Fonction fonction, string nom, string prenom, string adresse, string numeroTel)
            : base(fonction, nom, prenom, adresse, numeroTel)
        {

        }


        public static new Personne InterfaceCreation()
        {
            Dictionary<string, string> parametres = InteractionUtilisateur.DemanderParametres(new string[] { "nom", "prénom", "adresse", "numéro de téléphone" });
            Fonction fonction = InteractionUtilisateur.DemanderChoixObjet("Renseigner sa fonction dans l'association",
                new Fonction[] { Fonction.Membre, Fonction.Tresorier, Fonction.President },
                new string[] { "Membre", "Tresorier", "President" }
                );
            return new Donateur(fonction, parametres["nom"], parametres["prénom"], parametres["adresse"], parametres["numéro de téléphone"]);
        }

        public override string ToString()
        {
            return base.ToString()+" et donateur";
        }
    }
}