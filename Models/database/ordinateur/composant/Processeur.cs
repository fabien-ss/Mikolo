using System;
using System.Collections.Generic;

namespace mikolo;

public partial class Processeur
{
    public string Id { get; set; } = null!;

    public string? Label { get; set; }

    public double Frequence { get; set; }

    public int Coeur { get; set; }

    public int Gravure { get; set; }

    public virtual ICollection<Laptop> Laptops { get; set; } = new List<Laptop>();
}
