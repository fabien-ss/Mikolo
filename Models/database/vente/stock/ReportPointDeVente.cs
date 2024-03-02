using System;
using System.Collections.Generic;

namespace mikolo;

public partial class ReportPointDeVente
{
    public int Id { get; set; }

    public string? IdPointDeVente { get; set; }

    public string? IdLaptop { get; set; }

    public DateTime DateReport { get; set; }

    public int Nombre { get; set; }

    public virtual Laptop? IdLaptopNavigation { get; set; }

    public virtual PointDeVente? IdPointDeVenteNavigation { get; set; }
}
