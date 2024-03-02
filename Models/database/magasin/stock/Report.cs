using System;
using System.Collections.Generic;

namespace mikolo;

public partial class Report
{
    public int Id { get; set; }

    public string? IdLaptop { get; set; }

    public DateTime DateReport { get; set; }

    public int Nombre { get; set; }

    public virtual Laptop? IdLaptopNavigation { get; set; }
}
