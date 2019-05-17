using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD7_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Personne.ImporterCSV<Beneficiaire>("Beneficiaires.txt");
            Personne.ImporterCSV<Adherent>("Adherents.txt");
            Console.ReadKey();
        }
    }
}
