namespace TD7_8
{
    public abstract class PersonneMorale : IIdentifiable
    {
        static int dernierIdDonne = 0;// Le dernier id donné n'est pas forcément le nombre de personnes, dans le cas ou on en supprime par exemple.

        protected int identifiant;
        protected string nom;
        protected string adresse;
        protected string numeroTel;

        /// <summary>
        /// "Les différentes informations peuvent être modifiables", selon l'énoncé. Ci dessous get et set permettant cela.
        /// </summary>
        public string Nom { get => nom; set => nom = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string NumeroTel { get => numeroTel; set => numeroTel = value; }
        public int Identifiant { get => identifiant; }

        /// <summary>
        /// Crée une instance de la classe Personne.
        /// </summary>
        /// <param name="nom">Nom de la personne</param>
        /// <param name="prenom">Prenom de la personne</param>
        /// <param name="adresse">Adresse de la personne</param>
        /// <param name="numeroTel">Numéro de téléphone de la personne</param>
        public PersonneMorale(string nom, string adresse, string numeroTel)
        {
            dernierIdDonne++;
            identifiant = dernierIdDonne;
            this.nom = nom;
            this.adresse = adresse;
            this.numeroTel = numeroTel;
        }

    }
}