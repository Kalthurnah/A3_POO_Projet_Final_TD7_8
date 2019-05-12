using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    public abstract class Vaisselle : Objet
    {
        private int nombreDePieces;

        public int NombreDePieces { get => nombreDePieces; }

        protected Vaisselle(int nombreDePieces)
        {
            this.nombreDePieces = nombreDePieces;
        }

    }
}