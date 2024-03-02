using System;
using System.Collections.Generic;

namespace mikolo;

public partial class MouvementPointDeVente
{
    public int Id { get; set; }

    public string? IdLaptop { get; set; }

    public string? IdPointDeVente { get; set; }

    public int? Entree { get; set; }

    public int? Sortie { get; set; }

    public virtual Laptop? IdLaptopNavigation { get; set; }

    public virtual PointDeVente? IdPointDeVenteNavigation { get; set; }
}
