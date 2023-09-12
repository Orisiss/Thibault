using System;
using System.Collections.Generic;
using System.Linq;

public class Categorie
{
    public int Id { get; set; }
    public string Libelle { get; set; }

    public Categorie(int id, string libelle)
    {
        Id = id;
        Libelle = libelle;
    }

    public override string ToString()
    {
        return $"{Id} - {Libelle}";
    }
}

public class Article
{
    public int Reference { get; set; }
    public string Nom { get; set; }
    public decimal PrixVente { get; set; }
    public int QuantiteStock { get; set; }

    public Article(int reference, string nom, decimal prixVente, int quantiteStock)
    {
        Reference = reference;
        Nom = nom;
        PrixVente = prixVente;
        QuantiteStock = quantiteStock;
    }

    public override string ToString()
    {
        return $"{Reference} - {Nom} - Prix : {PrixVente} - Stock : {QuantiteStock}";
    }
}

public class Catalogue
{
    public int Id { get; set; }
    public string Libelle { get; set; }
    public Categorie Categorie { get; set; }
    public List<Article> Articles { get; set; }

    public Catalogue(int id, string libelle, Categorie categorie)
    {
        Id = id;
        Libelle = libelle;
        Categorie = categorie;
        Articles = new List<Article>();
    }

    public override string ToString()
    {
        return $"{Id} - {Libelle} ({Categorie.Libelle}) - Articles : {Articles.Count}";
    }
}

public class Program
{
    static List<Catalogue> catalogues = new List<Catalogue>();

    static void Main(string[] args)
    {
        bool continuer = true;
        while (continuer)
        {
            Console.WriteLine("Menu :");
            Console.WriteLine("1. Créer/Modifier/Supprimer un catalogue");
            Console.WriteLine("2. Créer/Modifier/Supprimer un article dans un catalogue");
            Console.WriteLine("3. Rechercher un article par référence dans un catalogue");
            Console.WriteLine("4. Ajouter un article au stock dans un catalogue");
            Console.WriteLine("5. Rechercher un article par nom dans un catalogue");
            Console.WriteLine("6. Afficher tous les articles d'un catalogue");
            Console.WriteLine("7. Bonus : Rechercher tous les articles d'un catalogue par intervalle de prix de vente");
            Console.WriteLine("8. Quitter");

            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    GererCatalogues();
                    break;
                case "2":
                    GererArticles();
                    break;
                case "3":
                    RechercherArticleParReference();
                    break;
                case "4":
                    AjouterArticleAuStock();
                    break;
                case "5":
                    RechercherArticleParNom();
                    break;
                case "6":
                    AfficherTousLesArticles();
                    break;
                case "7":
                    RechercherArticlesParIntervallePrix();
                    break;
                case "8":
                    continuer = false;
                    break;
                default:
                    Console.WriteLine("Choix invalide. Veuillez réessayer.");
                    break;
            }
        }
    }

    static void GererCatalogues()
    {
        Console.WriteLine("1. Créer un catalogue");
        Console.WriteLine("2. Modifier un catalogue");
        Console.WriteLine("3. Supprimer un catalogue");
        string choix = Console.ReadLine();

        switch (choix)
        {
            case "1":
                Console.WriteLine("Entrez l'ID du catalogue :");
                int idCatalogue = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Entrez le libellé du catalogue :");
                string libelleCatalogue = Console.ReadLine();
                Console.WriteLine("Entrez l'ID de la catégorie :");
                int idCategorie = Convert.ToInt32(Console.ReadLine());
                Catalogue catalogue = new Catalogue(idCatalogue, libelleCatalogue, new Categorie(idCategorie, "NomDeLaCategorie"));
                catalogues.Add(catalogue);
                Console.WriteLine("Catalogue créé avec succès !");
                break;
            case "2":
                Console.WriteLine("Entrez l'ID du catalogue que vous souhaitez modifier :");
                int idModif = Convert.ToInt32(Console.ReadLine());
                Catalogue catalogueAModifier = catalogues.FirstOrDefault(c => c.Id == idModif);
                if (catalogueAModifier != null)
                {
                    Console.WriteLine("Entrez le nouveau libellé du catalogue :");
                    catalogueAModifier.Libelle = Console.ReadLine();
                    Console.WriteLine("Catalogue modifié avec succès !");
                }
                else
                {
                    Console.WriteLine("Catalogue non trouvé.");
                }
                break;
            case "3":
                Console.WriteLine("Entrez l'ID du catalogue que vous souhaitez supprimer :");
                int idSuppr = Convert.ToInt32(Console.ReadLine());
                Catalogue catalogueASupprimer = catalogues.FirstOrDefault(c => c.Id == idSuppr);
                if (catalogueASupprimer != null)
                {
                    catalogues.Remove(catalogueASupprimer);
                    Console.WriteLine("Catalogue supprimé avec succès !");
                }
                else
                {
                    Console.WriteLine("Catalogue non trouvé.");
                }
                break;
            default:
                Console.WriteLine("Choix invalide. Retour au menu principal.");
                break;
        }
    }

    static void GererArticles()
    {
        Console.WriteLine("1. Créer un article");
        Console.WriteLine("2. Modifier un article");
        Console.WriteLine("3. Supprimer un article");
        string choix = Console.ReadLine();

        switch (choix)
        {
            case "1":
                Console.WriteLine("Entrez la référence de l'article :");
                int referenceArticle = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Entrez le nom de l'article :");
                string nomArticle = Console.ReadLine();
                Console.WriteLine("Entrez le prix de vente de l'article :");
                decimal prixVenteArticle = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Entrez la quantité en stock de l'article :");
                int stockArticle = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Entrez l'ID du catalogue dans lequel ajouter cet article :");
                int idCatalogueArticle = Convert.ToInt32(Console.ReadLine());
                Catalogue catalogueArticle = catalogues.FirstOrDefault(c => c.Id == idCatalogueArticle);
                if (catalogueArticle != null)
                {
                    Article article = new Article(referenceArticle, nomArticle, prixVenteArticle, stockArticle);
                    catalogueArticle.Articles.Add(article);
                    Console.WriteLine("Article créé avec succès !");
                }
                else
                {
                    Console.WriteLine("Catalogue non trouvé.");
                }
                break;
            case "2":
                Console.WriteLine("Entrez la référence de l'article que vous souhaitez modifier :");
                int referenceModif = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Entrez le nouveau nom de l'article :");
                string nomModif = Console.ReadLine();
                Console.WriteLine("Entrez le nouveau prix de vente de l'article :");
                decimal prixModif = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Entrez la nouvelle quantité en stock de l'article :");
                int stockModif = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Entrez l'ID du catalogue dans lequel se trouve cet article :");
                int idCatalogueModif = Convert.ToInt32(Console.ReadLine());
                Catalogue catalogueModif = catalogues.FirstOrDefault(c => c.Id == idCatalogueModif);
                if (catalogueModif != null)
                {
                    Article articleAModifier = catalogueModif.Articles.FirstOrDefault(a => a.Reference == referenceModif);
                    if (articleAModifier != null)
                    {
                        articleAModifier.Nom = nomModif;
                        articleAModifier.PrixVente = prixModif;
                        articleAModifier.QuantiteStock = stockModif;
                        Console.WriteLine("Article modifié avec succès !");
                    }
                    else
                    {
                        Console.WriteLine("Article non trouvé.");
                    }
                }
                else
                {
                    Console.WriteLine("Catalogue non trouvé.");
                }
                break;
            case "3":
                Console.WriteLine("Entrez la référence de l'article que vous souhaitez supprimer :");
                int referenceSuppr = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Entrez l'ID du catalogue dans lequel se trouve cet article :");
                int idCatalogueSuppr = Convert.ToInt32(Console.ReadLine());
                Catalogue catalogueSuppr = catalogues.FirstOrDefault(c => c.Id == idCatalogueSuppr);
                if (catalogueSuppr != null)
                {
                    Article articleASupprimer = catalogueSuppr.Articles.FirstOrDefault(a => a.Reference == referenceSuppr);
                    if (articleASupprimer != null)
                    {
                        catalogueSuppr.Articles.Remove(articleASupprimer);
                        Console.WriteLine("Article supprimé avec succès !");
                    }
                    else
                    {
                        Console.WriteLine("Article non trouvé.");
                    }
                }
                else
                {
                    Console.WriteLine("Catalogue non trouvé.");
                }
                break;
            default:
                Console.WriteLine("Choix invalide. Retour au menu principal.");
                break;
        }
    }

    static void RechercherArticleParReference()
    {
        Console.WriteLine("Entrez la référence de l'article que vous recherchez :");
        int referenceRecherche = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Entrez l'ID du catalogue dans lequel rechercher cet article :");
        int idCatalogueRecherche = Convert.ToInt32(Console.ReadLine());
        Catalogue catalogueRecherche = catalogues.FirstOrDefault(c => c.Id == idCatalogueRecherche);
        if (catalogueRecherche != null)
        {
            Article articleTrouve = catalogueRecherche.Articles.FirstOrDefault(a => a.Reference == referenceRecherche);
            if (articleTrouve != null)
            {
                Console.WriteLine("Article trouvé :");
                Console.WriteLine(articleTrouve);
            }
            else
            {
                Console.WriteLine("Article non trouvé.");
            }
        }
        else
        {
            Console.WriteLine("Catalogue non trouvé.");
        }
    }

    static void AjouterArticleAuStock()
    {
        Console.WriteLine("Entrez la référence de l'article auquel vous souhaitez ajouter du stock :");
        int referenceAjout = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Entrez la quantité à ajouter :");
        int quantiteAjout = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Entrez l'ID du catalogue dans lequel se trouve cet article :");
        int idCatalogueAjout = Convert.ToInt32(Console.ReadLine());
        Catalogue catalogueAjout = catalogues.FirstOrDefault(c => c.Id == idCatalogueAjout);
        if (catalogueAjout != null)
        {
            Article articleAjout = catalogueAjout.Articles.FirstOrDefault(a => a.Reference == referenceAjout);
            if (articleAjout != null)
            {
                articleAjout.QuantiteStock += quantiteAjout;
                Console.WriteLine("Stock mis à jour avec succès !");
            }
            else
            {
                Console.WriteLine("Article non trouvé.");
            }
        }
        else
        {
            Console.WriteLine("Catalogue non trouvé.");
        }
    }

    static void RechercherArticleParNom()
    {
        Console.WriteLine("Entrez le nom de l'article que vous recherchez :");
        string nomRecherche = Console.ReadLine();
        Console.WriteLine("Entrez l'ID du catalogue dans lequel rechercher cet article :");
        int idCatalogueRecherche = Convert.ToInt32(Console.ReadLine());
        Catalogue catalogueRecherche = catalogues.FirstOrDefault(c => c.Id == idCatalogueRecherche);
        if (catalogueRecherche != null)
        {
            List<Article> articlesTrouves = catalogueRecherche.Articles.Where(a => a.Nom.Contains(nomRecherche)).ToList();
            if (articlesTrouves.Count > 0)
            {
                Console.WriteLine("Articles trouvés :");
                foreach (var article in articlesTrouves)
                {
                    Console.WriteLine(article);
                }
            }
            else
            {
                Console.WriteLine("Aucun article trouvé.");
            }
        }
        else
        {
            Console.WriteLine("Catalogue non trouvé.");
        }
    }

    static void AfficherTousLesArticles()
    {
        Console.WriteLine("Entrez l'ID du catalogue dont vous souhaitez afficher les articles :");
        int idCatalogueAffichage = Convert.ToInt32(Console.ReadLine());
        Catalogue catalogueAffichage = catalogues.FirstOrDefault(c => c.Id == idCatalogueAffichage);
        if (catalogueAffichage != null)
        {
            if (catalogueAffichage.Articles.Count > 0)
            {
                Console.WriteLine("Articles dans ce catalogue :");
                foreach (var article in catalogueAffichage.Articles)
                {
                    Console.WriteLine(article);
                }
            }
            else
            {
                Console.WriteLine("Aucun article dans ce catalogue.");
            }
        }
        else
        {
            Console.WriteLine("Catalogue non trouvé.");
        }
    }

    static void RechercherArticlesParIntervallePrix()
    {
        Console.WriteLine("Entrez l'ID du catalogue dans lequel rechercher les articles :");
        int idCatalogueRecherche = Convert.ToInt32(Console.ReadLine());
        Catalogue catalogueRecherche = catalogues.FirstOrDefault(c => c.Id == idCatalogueRecherche);
        if (catalogueRecherche != null)
        {
            Console.WriteLine("Entrez le prix minimum :");
            decimal prixMin = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Entrez le prix maximum :");
            decimal prixMax = Convert.ToDecimal(Console.ReadLine());
            List<Article> articlesTrouves = catalogueRecherche.Articles.Where(a => a.PrixVente >= prixMin && a.PrixVente <= prixMax).ToList();
            if (articlesTrouves.Count > 0)
            {
                Console.WriteLine("Articles trouvés dans l'intervalle de prix :");
                foreach (var article in articlesTrouves)
                {
                    Console.WriteLine(article);
                }
            }
            else
            {
                Console.WriteLine("Aucun article trouvé dans cet intervalle de prix.");
            }
        }
        else
        {
            Console.WriteLine("Catalogue non trouvé.");
        }
    }
}