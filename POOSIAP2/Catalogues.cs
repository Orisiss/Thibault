class Catalogue
{
    public int ID { get; set; }
    public string Libelle { get; set; }
    public List<Article> Articles { get; set; }
    public string Categorie { get; set; }

    public Catalogue(int id, string libelle, string categorie)
    {
        ID = id;
        Libelle = libelle;
        Articles = new List<Article>();
        Categorie = categorie;
    }

    static void CreerCatalogue()
    {
        Console.WriteLine("Création d'un nouveau catalogue :");
        Console.Write("ID du catalogue : ");
        int id = int.Parse(Console.ReadLine());

        if (CatalogueExiste(id))
        {
            Console.WriteLine("Un catalogue avec cet ID existe déjà.");
        }
        else
        {
            Console.Write("Libellé du catalogue : ");
            string libelle = Console.ReadLine();
            Console.Write("Catégorie du catalogue (1 ou 2) : ");
            int categorieID = int.Parse(Console.ReadLine());

            if (categories.Any(c => c.ID == categorieID))
            {
                catalogues.Add(new Catalogue(id, libelle, categories.First(c => c.ID == categorieID).Libelle));
                Console.WriteLine("Catalogue créé avec succès.");
            }
            else
            {
                Console.WriteLine("Catégorie invalide.");
            }
        }
    }

    static void ModifierCatalogue()
    {
        Console.WriteLine("Modification d'un catalogue :");
        Console.Write("ID du catalogue à modifier : ");
        int id = int.Parse(Console.ReadLine());

        Catalogue catalogue = catalogues.FirstOrDefault(c => c.ID == id);

        if (catalogue != null)
        {
            Console.Write("Nouveau libellé : ");
            string nouveauLibelle = Console.ReadLine();
            catalogue.Libelle = nouveauLibelle;

            Console.WriteLine("Catalogue modifié avec succès.");
        }
        else
        {
            Console.WriteLine("Catalogue introuvable.");
        }
    }

    static void SupprimerCatalogue()
    {
        Console.WriteLine("Suppression d'un catalogue :");
        Console.Write("ID du catalogue à supprimer : ");
        int id = int.Parse(Console.ReadLine());

        Catalogue catalogue = catalogues.FirstOrDefault(c => c.ID == id);

        if (catalogue != null)
        {
            catalogues.Remove(catalogue);
            Console.WriteLine("Catalogue supprimé avec succès.");
        }
        else
        {
            Console.WriteLine("Catalogue introuvable.");
        }
    }

    public override string ToString()
    {
        return $"ID: {ID}, Libelle: {Libelle}, Categorie: {Categorie}";
    }
}