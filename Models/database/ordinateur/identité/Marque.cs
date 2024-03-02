using System;
using System.Collections.Generic;

namespace mikolo;

public partial class Marque
{
    public string? Id { get; set; } 

    public string Label { get; set; } = null!;

    public virtual ICollection<Reference> References { get; set; } = new List<Reference>();
}
