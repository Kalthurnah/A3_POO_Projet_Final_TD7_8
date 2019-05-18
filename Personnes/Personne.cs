﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TD7_8
{
    public abstract class Personne : IIdentifiable, IComparable<Personne>
    {
        static protected List<Personne> personnes = new List<Personne>();//Stocke les personne créees de facon statique dans la classe Personne.
        static int dernierIdDonne = 0;// Le dernier id donné n'est pas forcément le nombre de personnes, dans le cas ou on en supprime par exemple.
        public static int Count { get => personnes.Count(); }//Compteur de personne, qu'on remplace dans les classes filles avec new

        //Attributs d'instance v .

        private int identifiant;
        protected string nom;
        protected string prenom;
        protected string adresse;
        protected string numeroTel;

        public int Identifiant { get => identifiant; }
        /// <summary>
        /// "Les différentes informations peuvent être modifiables", selon l'énoncé. Ci dessous get et set permettant la modification, au besoin.
        /// </summary>
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string NumeroTel { get => numeroTel; set => numeroTel = value; }



        /// <summary>
        /// Crée une instance de la classe Personne.
        /// </summary>
        /// <param name="nom">Nom de la personne</param>
        /// <param name="prenom">Prenom de la personne</param>
        /// <param name="adresse">Adresse de la personne</param>
        /// <param name="numeroTel">Numéro de téléphone de la personne</param>
        public Personne(string nom, string prenom, string adresse, string numeroTel)
        {
            dernierIdDonne++;
            identifiant = dernierIdDonne;
            this.nom = nom;
            this.prenom = prenom;
            this.adresse = adresse;
            this.numeroTel = numeroTel;
            personnes.Add(this);
        }

        public static void ImporterCSV<T>(string nomFichier) where T : Personne
        {
            StreamReader fichLect = new StreamReader(nomFichier);
            char[] sep = new char[1] { ';' };
            string ligne = "";//TODO : retirer le =.., meme raison qu'en dessous 
            string[] datas = new string[6];//Todo : retirer le = ... car ligne.split retourne de toute facon une new string[]
            DateTime date;
            string nom;
            string prenom;
            string adresse;
            string tel;
            Adherent.Fonction statut;
            while (fichLect.Peek() > 0)
            {
                ligne = fichLect.ReadLine();
                if (ligne != "")
                {
                    Console.WriteLine($"Ajout du {typeof(T).Name} : " + ligne);
                    datas = ligne.Split(sep);
                    nom = datas[1];
                    prenom = datas[4];
                    adresse = datas[2];
                    tel = datas[3];
                    if (typeof(T) == typeof(Beneficiaire))
                    {
                        date = DateTime.ParseExact(datas[5], "dd/MM/yyyy", null);
                        new Beneficiaire(date, nom, prenom, adresse, tel);
                    }
                    else
                    {
                        switch (datas[5])
                        {
                            case "membre":
                                statut = Adherent.Fonction.Membre;
                                break;
                            case "tresorier":
                                statut = Adherent.Fonction.Tresorier;
                                break;
                            case "president":
                                statut = Adherent.Fonction.President;
                                break;
                            default:
                                statut = Adherent.Fonction.Membre;
                                break;
                        }
                        new Adherent(statut, nom, prenom, adresse, tel);
                    }
                }
            }
            Console.WriteLine("Importation terminée.");
        }

        public static List<T> TrouverInstance<T>(Predicate<T> predicate) where T : Personne
        {
            List<T> personnesTypees = personnes.OfType<T>().ToList();
            return personnesTypees.FindAll(predicate);
        }
        /// <summary>
        /// Méthode supprimant une personne de la liste des personnes.
        /// </summary>
        public void Supprimer()
        {
            personnes.Remove(this);
        }

        public int CompareTo(Personne other)
        {
            return nom.CompareTo(other.Nom);
        }

        delegate Personne CreateurPersonne();
        public static Personne InterfaceCreation()
        {
            CreateurPersonne createurChoisi = InteractionUtilisateur.DemanderChoixObjet<CreateurPersonne>("Quel est le type de personnes à créer ?",
                new CreateurPersonne[] { Adherent.InterfaceCreation,
                    Donateur.InterfaceCreation,
                    Beneficiaire.InterfaceCreation},
             new string[] { "Adhérent",
                 "Donateur",
                 "Bénéficiaire"}
             );
            Personne personneCree = createurChoisi();//Lance l'interface de création pour le type de personne choisi.
            return personneCree;
        }

    }
}
