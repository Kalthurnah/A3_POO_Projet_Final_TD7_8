using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD7_8
{
    public class InteractionUtilisateur
    {
        /// <summary>
        /// Demande une confirmation à l'utilisateur
        /// </summary>
        /// <param name="message">Message à afficher à l'utilisateur</param>
        /// <returns>true ou false selon la confirmation de l'utilisateur</returns>
        public static bool ObtenirConfirmation(string message = "Vous confirmez ?")
        {
            bool confirmation = DemanderChoixObjet<bool>(message, new bool[] { true, false }, new string[] { "Oui", "Non" });
            return confirmation;
        }
        /// <summary>
        /// Affiche une array
        /// </summary>
        /// <param name="message">Message à afficher à l'utilisateur</param>
        /// <param name="listeChoix">array à afficher</param>
        public static void ListerObjets<T>(string message, T[] listeChoix)
        {
            Console.WriteLine(message);
            for (int index = 0; index < listeChoix.Length; index++)
            {
                Console.WriteLine($"{index + 1} - {listeChoix[index]}");
            }
        }
        public static void ListerObjets<T>(string message, List<T> listeChoix)
        {
            Console.WriteLine(message);
            for (int index = 0; index < listeChoix.Count; index++)
            {
                Console.WriteLine($"{index + 1} - {listeChoix[index]}");
            }
        }

        /// <summary>
        /// Affiche un message à l'utilisateur, et lui propose des choix parmi lesquels il doit en rentrer un. 
        /// </summary>
        /// <param name="message">Message à afficher pour expliquer le contexte à l'utilisateur</param>
        /// <param name="listeIntitulesChoix">Liste d'intitulés de choix possibles</param>
        /// <returns>entier entre 0 et le nombre de choix possibles -1, représentant l'index du choix dans la liste de strings.</returns>
        public static int DemanderChoixInt(string message, string[] listeIntitulesChoix)
        {
            string lecture;
            bool valid = false;
            int choix = 0;
            ListerObjets<string>(message, listeIntitulesChoix);
            Console.WriteLine("Entrer un choix >");

            do
            {
                lecture = Console.ReadLine();
                try
                {
                    choix = Convert.ToInt32(lecture);
                    valid = true;
                    if (choix <= 0 || choix > listeIntitulesChoix.Length)
                    {
                        valid = false;
                        Console.WriteLine("Choix invalide, faites un choix parmi ceux présentés.>");
                    }
                }
                catch
                {
                    Console.WriteLine("Entrée invalide - Rentrez un nombre");
                }

            } while (!valid);//On redemande tant que l'entrée est invalide

            return choix - 1;//-1 pour rapporter le choix à un index entre 0 et length (exclu)
        }
        /// <summary>
        /// Affiche un message à l'utilisateur, et lui demande une entrée 
        /// </summary>
        /// <param name="message">Message à afficher pour expliquer le contexte à l'utilisateur</param>
        /// <returns>string rentré par l'utilisateur.</returns>
        public static string DemanderString(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        /// <summary>
        /// Affiche un message à l'utilisateur, et lui propose des choix parmi lesquels il doit en choisir un. 
        /// </summary>
        /// <typeparam name="T">Type des objets choisis à retourner</typeparam>
        /// <param name="message">Message à afficher pour expliquer le contexte à l'utilisateur</param>
        /// <param name="listeChoix">Objets parmi lesquels l'utilisateur peut choisir </param>
        /// <param name="listeIntitulesChoix">Optionnel : Une liste d'intitulé de choix. Si elle n'est pas renseignée, utilise les représentations textuelles des objets comme intitulés.</param>
        /// <returns>L'objet choisi</returns>
        public static T DemanderChoixObjet<T>(string message, T[] listeChoix, string[] listeIntitulesChoix = null)
        {
            T objetChoisi;
            if (listeIntitulesChoix == null)
            {
                listeIntitulesChoix = new string[listeChoix.Length];//Nouvelle liste de longueur identique au nombre de choix
                for (int i = 0; i < listeChoix.Length; i++)
                {
                    listeIntitulesChoix[i] = listeChoix[i].ToString();
                }
            }
            int choix = DemanderChoixInt(message, listeIntitulesChoix);
            objetChoisi = listeChoix[choix];//L'objet choisi est celui de la liste correspondant au numéro choisi par l'utilisateur. 
            return objetChoisi;
        }
        /// <summary>
        /// Demande un par un plusieurs paramètres à l'utilisateur
        /// </summary>
        /// <param name="parametresADemander">array des noms des parametres à demander. Seront utilisés comme clés du dico et affichés à l'utilisateur lors de la demande</param>
        /// <returns>Dico de clés paramètres et valeurs les valeurs entrées par l'utilisateur</returns>
        public static Dictionary<string, string> DemanderParametres(string[] parametresADemander)
        {
            Dictionary<string, string> choix = new Dictionary<string, string>();
            foreach (string parametre in parametresADemander)
            {
                choix.Add(parametre, DemanderString($"Rentrer {parametre}"));
            }
            return choix;
        }
        /// <summary>
        /// Demande une date à l'utilisateur
        /// </summary>
        /// <param name="message">Message de contexte à afficher</param>
        /// <returns>Element DateTime correspondant à l'entrée utilisateur</returns>
        public static DateTime DemanderDateTime(string message = "Entrez une date")
        {
            Console.WriteLine($"{message}");
            string lecture;
            DateTime date = DateTime.Now;
            bool valid;
            do
            {
                Console.WriteLine($"La date doit être au format \"dd/MM/yyyy\".");
                lecture = Console.ReadLine();
                try
                {
                    date = DateTime.ParseExact(lecture, "dd/MM/yyyy", null);
                    valid = true;
                }
                catch
                {
                    valid = false;
                    Console.WriteLine("Date invalide. Réessayer");
                }
            } while (!valid);
            return date;
        }
        /// <summary>
        /// Demande un double à l'utilisateur
        /// </summary>
        /// <param name="message">Message de contexte à afficher</param>
        /// <returns>double correspondant à l'entrée utilisateur</returns>
        public static double DemanderDouble(string message = "Entrez une nombre")
        {
            Console.WriteLine($"{message}");
            string lecture;
            double nombre = 0;
            bool valid;
            do
            {
                lecture = Console.ReadLine();
                try
                {
                    nombre = Convert.ToDouble(lecture);
                    valid = true;
                }
                catch
                {
                    valid = false;
                    Console.WriteLine("Nombre invalide. Réessayer");
                }
            } while (!valid);
            return nombre;
        }

        /// <summary>
        /// Demande à l'utilisateur une entrée pour une recherche, et lui permet de choisir un objet parmi les résultats de cette recherche.
        /// </summary>
        /// <typeparam name="T">Type des objets choisis à retourner</typeparam>
        /// <param name="fonctionDeRecherche">Fonction de recherche prenant une entrée en argument .</param>
        /// <param name="demanderChoix">booléen indiquant si un choix est requis ou non. Si non, la fonction retourne toujours une valeur nulle/par défaut</param>
        /// <param name="nomArgumentRecherche">nom de l'argument de recherche. Doit renseigner l'utilisateur sur l'entrée qui lui est demandée, par exemple, recherche par "titre", par "ville", etc. </param>
        /// <returns></returns>
        public static T RechercherUnElement<T>(Recherche.FonctionRecherche<T> fonctionDeRecherche, bool demanderChoix = true, string nomArgumentRecherche = null)
        {

            T instanceChoisie = default(T);
            bool valid;
            string lecture;
            List<T> resultats;
            do
            {
                Console.Write($"Recherche d'une instance de {typeof(T).Name} ");
                if (nomArgumentRecherche != null)
                {
                    Console.WriteLine($"par {nomArgumentRecherche}");
                }
                Console.Write(">");
                do
                {
                    valid = true;
                    lecture = Console.ReadLine();
                    resultats = fonctionDeRecherche(lecture);
                    if (resultats.Count < 1)
                    {
                        Console.WriteLine($"Aucun résultat trouvé. Veuillez réessayer avec une autre entrée");
                        valid = false;
                    }
                } while (!valid);

                if (demanderChoix)
                {
                    instanceChoisie = DemanderChoixObjet<T>("Quel résultat choisir ?", resultats.ToArray());
                    Console.WriteLine($"Vous avez choisi {instanceChoisie}");
                }
                else
                {//Si on n'exige pas que l'utilisateur fasse un choix, on affiche juste la liste
                    ListerObjets<T>($"Voici les {resultats.Count} résultats", resultats);
                }
            } while (!ObtenirConfirmation("Continuer et quitter la recherche ? (Si vous choissisez non, vous pourrez relancer une recherche.)"));//On relance une recherche si l'utilisateur n'a pas reconfirmé son choix

            return instanceChoisie;
        }
    }
}
