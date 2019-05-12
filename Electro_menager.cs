using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    public class Electro_menager : Objet_volumineux
    {
        private int puissance;
        private int nombre;

        public Electro_menager()
        {
            throw new System.NotImplementedException();
        }

        public enum TypeMenager
        {
            Cuisinière,
            Réfrigérateur,
            Lavelinge
        }
    }
}