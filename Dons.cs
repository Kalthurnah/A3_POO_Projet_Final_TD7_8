﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    public abstract class Dons
    {
        private DateTime date_reception;
        private string description_complémentaire;

        public Dons()
        {
            throw new System.NotImplementedException();
        }

        public Beneficiaire Beneficiaire
        {
            get => default(Beneficiaire);
            set
            {
            }
        }

        public Objet Objet
        {
            get => default(Objet);
            set
            {
            }
        }
    }
}