using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    public class Vaisselle : Objet
    {
        private int nb;

        public Vaisselle()
        {
            throw new System.NotImplementedException();
        }

        public enum TypeVaisselle
        {
            Couverts,
            Assiettes
        }
    }
}