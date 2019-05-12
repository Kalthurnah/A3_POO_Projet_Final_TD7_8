using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    public abstract class Objet
    {
        private string référence;
        private Type type;
        private string description;
        private double prix;

        public Objet()
        {
            throw new System.NotImplementedException();
        }

        public string Référence
        {
            get => default(string);
            set
            {
            }
        }

        public string Type
        {
            get => default(string);
            set
            {
            }
        }

        public string Description
        {
            get => default(string);
            set
            {
            }
        }

        public double Prix
        {
            get => default(int);
            set
            {
            }
        }
    }


}