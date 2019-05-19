namespace TD7_8
{
    public class GardeMeuble : LieuStockage
    {
        public GardeMeuble(string nom, string adresse, string numeroTel) : base(nom, adresse, numeroTel)
        {
        }
        public override string ToString()
        {
            string res = $" Garde meuble: {identifiant}, {nom}, {adresse}, {numeroTel}.";
            return res;
        }
    }
}