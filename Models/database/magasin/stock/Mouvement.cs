using System;
using System.Collections.Generic;

namespace mikolo;

public partial class Mouvement
{
    public string Id { get; set; } = null!;

    public DateTime DateMouvement { get; set; }

    public string? IdLaptop { get; set; }

    public int? Entree { get; set; }

    public int? Sortie { get; set; }

    public virtual Laptop? IdLaptopNavigation { get; set; }
}
