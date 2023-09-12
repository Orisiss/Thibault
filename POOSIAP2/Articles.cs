class Article
{
    public string NumeroReference { get; private set; }
    public string Nom { get; set; }
    public double PrixVente { get; set; }
    public int QuantiteStock { get; set; }

    public Article(string numeroReference, string nom, double prixVente, int quantiteStock)
    {
        NumeroReference = numeroReference;
        Nom = nom;
        PrixVente = prixVente;
        QuantiteStock = quantiteStock;
    }

    // Méthode ToString pour afficher l'article
    public override string ToString()
    {
        return $"Référence : {NumeroReference}, Nom : {Nom}, Prix de vente : {PrixVente:C}, Quantité en stock : {QuantiteStock}";
    }
}