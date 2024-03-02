using System;
using System.Collections.Generic;
using Lombok.NET;

namespace mikolo;
    
public partial class Mouvement
{
    public string Id { get; set; } = null!;

    public DateTime DateMouvement { get; set; }

    public string? IdLaptop { get; set; }

    public int? Entree { get; set; }

    public int? Sortie { get; set; }

    public virtual Laptop? IdLaptopNavigation { get; set; }

    public Mouvement(string id, DateTime dateMouvement, string? idLaptop, int? entree, int? sortie)
    {
        Id = id;
        DateMouvement = dateMouvement;
        IdLaptop = idLaptop;
        Entree = entree;
        Sortie = sortie;
    }

    public Mouvement()
    {
    }
}
