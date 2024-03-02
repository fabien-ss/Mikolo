using System;
using System.Collections.Generic;

namespace mikolo;

public partial class Ram
{
    public string Id { get; set; } = null!;

    public string Label { get; set; } = null!;

    public int Puissance { get; set; }

    public virtual ICollection<Laptop> Laptops { get; set; } = new List<Laptop>();
}
