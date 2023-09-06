class Article
{
    public int Reference { get; set; }
    public string Nom { get; set; }
    public decimal PrixVente { get; set; }
    public int QuantiteEnStock { get; set; }

    public Article(int reference, string nom, decimal prixVente, int quantiteEnStock)
    {
        Reference = reference;
        Nom = nom;
        PrixVente = prixVente;
        QuantiteEnStock = quantiteEnStock;
    }

    public override string ToString()
    {
        return $"Reference: {Reference}, Nom: {Nom}, Prix de Vente: {PrixVente:€}, Quantite en Stock: {QuantiteEnStock}";
    }
}