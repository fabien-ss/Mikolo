using System;
using System.Collections.Generic;

namespace mikolo;

public partial class DisqueDur
{
    public string Id { get; set; }

    public string Label { get; set; } = null!;

    public int Stockage { get; set; }

    public int Rotation { get; set; }

    public int Taille { get; set; }

    public virtual ICollection<Laptop> Laptops { get; set; } = new List<Laptop>();
}
