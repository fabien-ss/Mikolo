using System;
using System.Collections.Generic;

namespace mikolo;

public partial class Reference
{
    public string? Id { get; set; } = null!;

    public string? IdMarque { get; set; }

    public string Label { get; set; } = null!;

    public virtual Marque? IdMarqueNavigation { get; set; }

    public virtual ICollection<Laptop> Laptops { get; set; } = new List<Laptop>();
}
