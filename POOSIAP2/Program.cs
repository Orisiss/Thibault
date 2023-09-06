using POOSIAP2;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Catalogue> catalogues = new List<Catalogue>();
    static List<Categorie> categories = new List<Categorie>();

    static void Main()
    {
        categories.Add(new Categorie(1, "Catégorie 1"));
        categories.Add(new Categorie(2, "Catégorie 2"));

        bool quit = false;

        while (!quit)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Créer / modifier / supprimer un catalogue par ID");
            Console.WriteLine("2. Créer / modifier / supprimer un article dans un catalogue");
            Console.WriteLine("3. Rechercher un article par référence dans un catalogue");
            Console.WriteLine("4. Ajouter un article au stock dans un catalogue en vérifiant l'unicité de la référence");
            Console.WriteLine("5. Rechercher un article par nom dans un catalogue");
            Console.WriteLine("6. Afficher tous les articles d'un catalogue");
            Console.WriteLine("7. Quitter");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Implémentez les fonctionnalités de gestion de catalogues (création, modification, suppression) ici.
                    break;

                case "2":
                    // Implémentez les fonctionnalités de gestion d'articles (création, modification, suppression) ici.
                    break;

                case "3":
                    // Implémentez la recherche d'article par référence ici.
                    break;

                case "4":
                    // Implémentez l'ajout d'article au stock ici.
                    break;

                case "5":
                    // Implémentez la recherche d'article par nom ici.
                    break;

                case "6":
                    // Implémentez l'affichage de tous les articles d'un catalogue ici.
                    break;

                case "7":
                    quit = true;
                    break;

                default:
                    Console.WriteLine("Choix invalide. Veuillez réessayer.");
                    break;
            }
        }
    }
}