class Categorie
{
    public int ID { get; private set; }
    public string Libelle { get; private set; }

    public Categorie(int id, string libelle)
    {
        ID = id;
        Libelle = libelle;
    }

    // Méthode ToString pour afficher la catégorie
    public override string ToString()
    {
        return $"{ID} - {Libelle}";
    }
}