using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD7_8
{
    interface ICreableInterface<T>
    {
        /// <summary>
        /// Fonction demandant à l'utilisateur des entrées pour créer une instance.
        /// </summary>
        T InterfaceCreation();
    }
}
