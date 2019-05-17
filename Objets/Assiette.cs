using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD7_8
{
    public class Assiette : Vaisselle
    {
        public Assiette(int nombreDePieces, double prix=0) : base(nombreDePieces,prix)
        {
        }
    }
}