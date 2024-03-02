using System;
using System.Collections.Generic;

namespace mikolo;

public partial class Ecran
{
    public string Id { get; set; } = null!;

    public string Label { get; set; } = null!;

    public int? Taille { get; set; }

    public virtual ICollection<Laptop> Laptops { get; set; } = new List<Laptop>();
}
