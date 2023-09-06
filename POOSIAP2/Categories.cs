class Categorie
{
    public int ID { get; }
    public string Libelle { get; }

    public Categorie(int id, string libelle)
    {
        ID = id;
        Libelle = libelle;
    }
}