using System;
using System.Collections.Generic;

namespace mikolo;

public partial class Utilisateur
{
    public string Id { get; set; } = null!;

    public string Nom { get; set; } = null!;

    public string? Prenom { get; set; }

    public DateOnly? DateEmbauche { get; set; }

    public DateOnly? DateResilliation { get; set; }

    public string? IdPointDeVente { get; set; }

    public virtual PointDeVente? IdPointDeVenteNavigation { get; set; }
}
