using System;
using System.Collections.Generic;

namespace mikolo;

public partial class PointDeVente
{
    public string? Id { get; set; }

    public string Label { get; set; } = null!;

    public string Adresse { get; set; } = null!;

    public double? Longitude { get; set; }

    public double? Latitude { get; set; }

    public virtual ICollection<MouvementPointDeVente> MouvementPointDeVentes { get; set; } = new List<MouvementPointDeVente>();

    public virtual ICollection<ReportPointDeVente> ReportPointDeVentes { get; set; } = new List<ReportPointDeVente>();

    public virtual ICollection<Utilisateur> Utilisateurs { get; set; } = new List<Utilisateur>();
}
