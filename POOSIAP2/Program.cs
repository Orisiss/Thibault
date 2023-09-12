using System;
using System.Collections.Generic;

class Program
{
    static List<Catalogue> tousLesCatalogues = new List<Catalogue>();
    static List<Categorie> toutesLesCategories = new List<Categorie>();

    static void Main(string[] args)
    {
        Console.WriteLine("Bienvenue dans votre application de gestion de stock.");

        // Créez quelques catégories pour commencer
        Categorie categorie1 = new Categorie(1, "Electronique");
        Categorie categorie2 = new Categorie(2, "Vêtements");
        Categorie categorie3 = new Categorie(3, "Mobilier");

        toutesLesCategories.Add(categorie1);
        toutesLesCategories.Add(categorie2);
        toutesLesCategories.Add(categorie3);

        bool quitter = false;
        while (!quitter)
        {
            Console.WriteLine("\nMenu Principal:");
            Console.WriteLine("1. Créer un catalogue");
            Console.WriteLine("2. Modifier un catalogue");
            Console.WriteLine("3. Supprimer un catalogue");
            Console.WriteLine("4. Créer un article dans un catalogue");
            Console.WriteLine("5. Modifier un article dans un catalogue");
            Console.WriteLine("6. Supprimer un article dans un catalogue");
            Console.WriteLine("7. Rechercher un article par référence dans un catalogue");
            Console.WriteLine("8 .Ajouter un article au stock dans un catalogue en vérifiant l'unicité de la référence");
            Console.WriteLine("9. Recherche un article par nom dans un catalogue");
            Console.WriteLine("10. Afficher tous les catalogues");
            Console.WriteLine("Q. Quitter");

            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    CreerCatalogue();
                    break;
                case "2":
                    ModifierCatalogue();
                    break;
                case "3":
                    SupprimerCatalogue();
                    break;
                case "4":
                    AjouterArticle();
                    break;
                case "5":
                    M
                case "10":
                    AfficherTousLesCatalogues();
                    break;
                case "Q":
                    quitter = true;
                    break;
                    
                default:
                    Console.WriteLine("Choix invalide. Veuillez réessayer.");
                    break;
            }
        }
    }

    static void CreerCatalogue()
    {
        Console.WriteLine("Création d'un nouveau catalogue.");
        Console.Write("Entrez l'ID du catalogue : ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Entrez le libellé du catalogue : ");
        string libelle = Console.ReadLine();
        
        // Affichez les catégories disponibles pour la sélection
        Console.WriteLine("Catégories disponibles :");
        foreach (var categorie in toutesLesCategories)
        {
            Console.WriteLine($"{categorie.ID}. {categorie.Libelle}");
        }

        Console.Write("Entrez l'ID de la catégorie du catalogue : ");
        int categorieId = int.Parse(Console.ReadLine());

        // Recherchez la catégorie correspondante
        categorie = toutesLesCategories.Find(c => c.ID == categorieId);

        if (categorie == null)
        {
            Console.WriteLine("Catégorie non trouvée.");
            return;
        }

        Catalogue catalogue = Catalogue.CreerCatalogue(id, libelle, categorie);
        tousLesCatalogues.Add(catalogue);
        Console.WriteLine($"Catalogue créé avec succès : {catalogue}");
    }

    static void ModifierCatalogue()
    {
        Console.WriteLine("Modification d'un catalogue.");
        Console.Write("Entrez l'ID du catalogue à modifier : ");
        int id = int.Parse(Console.ReadLine());

        // Recherchez le catalogue correspondant
        Catalogue catalogue = tousLesCatalogues.Find(c => c.ID == id);

        if (catalogue == null)
        {
            Console.WriteLine("Catalogue non trouvé.");
            return;
        }

        Console.Write("Entrez le nouveau libellé du catalogue : ");
        string nouveauLibelle = Console.ReadLine();

        // Affichez les catégories disponibles pour la sélection
        Console.WriteLine("Catégories disponibles :");
        foreach (var categorie in toutesLesCategories)
        {
            Console.WriteLine($"{categorie.ID}. {categorie.Libelle}");
        }

        Console.Write("Entrez le nouvel ID de la catégorie du catalogue : ");
        int nouvelleCategorieId = int.Parse(Console.ReadLine());

        // Recherchez la nouvelle catégorie correspondante
        Categorie nouvelleCategorie = toutesLesCategories.Find(c => c.ID == nouvelleCategorieId);

        if (nouvelleCategorie == null)
        {
            Console.WriteLine("Nouvelle catégorie non trouvée.");
            return;
        }

        catalogue.ModifierCatalogue(nouveauLibelle, nouvelleCategorie);
        Console.WriteLine($"Catalogue modifié avec succès : {catalogue}");
    }

    static void SupprimerCatalogue()
    {
        Console.WriteLine("Suppression d'un catalogue.");
        Console.Write("Entrez l'ID du catalogue à supprimer : ");
        int id = int.Parse(Console.ReadLine());

        // Recherchez le catalogue correspondant
        Catalogue catalogueASupprimer = tousLesCatalogues.Find(c => c.ID == id);

        if (catalogueASupprimer == null)
        {
            Console.WriteLine("Catalogue non trouvé.");
            return;
        }

        tousLesCatalogues.Remove(catalogueASupprimer);
        catalogueASupprimer.SupprimerCatalogue();
        Console.WriteLine("Catalogue supprimé avec succès.");
    }

    static void AfficherTousLesCatalogues()
    {
        Console.WriteLine("\nListe de tous les catalogues :");
        foreach (var catalogue in tousLesCatalogues)
        {
            Console.WriteLine(catalogue.ToString());
        }
    }
}
