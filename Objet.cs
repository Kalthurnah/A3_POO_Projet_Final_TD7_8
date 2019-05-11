using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    public abstract class Objet
    {
        private string référence;
        private string type;
        private string description;
        private double prix;

        public Objet()
        {
            throw new System.NotImplementedException();
        }

        public string Référence
        {
            get => default(int);
            set
            {
            }
        }

        public string Type
        {
            get => default(int);
            set
            {
            }
        }

        public string Description
        {
            get => default(int);
            set
            {
            }
        }

        public int Prix
        {
            get => default(int);
            set
            {
            }
        }
    }
}