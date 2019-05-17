using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Amine AGOUSSAL, Cécile AMSALLEM
//Groupe TD A, A3

namespace TD7_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu.sousMenu quitter = delegate () { return; };
            do
            {
                Menu.sousMenu menuChoisi = InteractionUtilisateur.DemanderChoixObjet<Menu.sousMenu>("Menu :",
                     new Menu.sousMenu[] { Menu.MenuRecherchePersonne, quitter },
                     new string[] { "Recherche de personnes", "Quitter" });
                menuChoisi();
            } while (true);
        }
    }
}
