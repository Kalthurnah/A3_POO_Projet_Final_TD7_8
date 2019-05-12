using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    public class ElectroMenager : ObjetVolumineux
    {
        private int puissance;
        private int nombre;

        public enum TypeMenager
        {
            Cuisiniere,
            Refrigerateur,
            LaveLinge
        }
    }
}