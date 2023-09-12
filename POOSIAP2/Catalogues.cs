using System;
using System.Collections.Generic;

class Catalogue
{
    public int ID { get; }
    public string Libelle { get; set; }
    public Categorie Categorie { get; set; }
    public List<Article> Articles { get; }
    
    private static List<Catalogue> tousLesCatalogues = new List<Catalogue>();

    public Catalogue(int id, string libelle, Categorie categorie)
    {
        ID = id;
        Libelle = libelle;
        Categorie = categorie;
        Articles = new List<Article>();
    }

    // Méthode pour ajouter un article au catalogue
    public void AjouterArticle(Article article)
    {
        Articles.Add(article);
    }

    // Méthode pour éditer un article dans le catalogue
    public void EditerArticle(Article article)
    {
        // Recherche de l'article par numéro de référence
        Article articleExist = Articles.Find(a => a.NumeroReference == article.NumeroReference);

        if (articleExist != null)
        {
            // Mettre à jour les attributs de l'article existant
            articleExist.Nom = article.Nom;
            articleExist.PrixVente = article.PrixVente;
            articleExist.QuantiteStock = article.QuantiteStock;
        }
        else
        {
            Console.WriteLine("Article non trouvé dans le catalogue.");
        }
    }

    // Méthode pour supprimer un article du catalogue par référence
    public void SupprimerArticleParReference(string reference)
    {
        Article articleASupprimer = Articles.Find(a => a.NumeroReference == reference);
        if (articleASupprimer != null)
        {
            Articles.Remove(articleASupprimer);
            Console.WriteLine("Article supprimé avec succès.");
        }
        else
        {
            Console.WriteLine("Article non trouvé dans le catalogue.");
        }
    }

    // Méthode pour rechercher un article par référence
    public Article RechercherArticleParReference(string reference)
    {
        return Articles.Find(a => a.NumeroReference == reference);
    }

    // Méthode pour rechercher un article par nom
    public List<Article> RechercherArticlesParNom(string nom)
    {
        return Articles.FindAll(a => a.Nom.Equals(nom, StringComparison.OrdinalIgnoreCase));
    }

    // Méthode pour afficher tous les articles du catalogue
    public void AfficherTousLesArticles()
    {
        Console.WriteLine($"Articles dans le catalogue {Libelle}:");
        foreach (var article in Articles)
        {
            Console.WriteLine(article.ToString());
        }
    }

    // Méthode pour rechercher tous les articles d'un catalogue par intervalle de prix de vente
    public List<Article> RechercherArticlesParIntervallePrix(double prixMin, double prixMax)
    {
        return Articles.FindAll(a => a.PrixVente >= prixMin && a.PrixVente <= prixMax);
    }
    
    public static Catalogue CreerCatalogue(int id, string libelle, Categorie categorie)
    {
        Catalogue nouveauCatalogue = new Catalogue(id, libelle, categorie);
        tousLesCatalogues.Add(nouveauCatalogue);
        return nouveauCatalogue;
    }

    // Méthode pour modifier les attributs d'un catalogue
    public void ModifierCatalogue(string nouveauLibelle, Categorie nouvelleCategorie)
    {
        Libelle = nouveauLibelle;
        Categorie = nouvelleCategorie;
    }

    // Méthode pour supprimer le catalogue actuel
    public void SupprimerCatalogue()
    {
        tousLesCatalogues.Remove(this);
    }

    // Méthode pour obtenir tous les catalogues
    public static List<Catalogue> ObtenirTousLesCatalogues()
    {
        return tousLesCatalogues;
    }

    public override string ToString()
    {
        return $"{ID} - {Libelle} ({Categorie.Libelle})";
    }
}
