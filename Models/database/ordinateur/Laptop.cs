using System;
using System.Collections.Generic;

namespace mikolo;

public partial class Laptop
{
    public string? Id { get; set; }

    public string IdReference { get; set; } = null!;

    public string IdProcesseur { get; set; } = null!;

    public string IdRam { get; set; } = null!;

    public string IdEcran { get; set; } = null!;

    public string IdDisqueDur { get; set; }= null!;

    public virtual DisqueDur? IdDisqueDurNavigation { get; set; }

    public virtual Ecran? IdEcranNavigation { get; set; }

    public virtual Processeur? IdProcesseurNavigation { get; set; }

    public virtual Ram? IdRamNavigation { get; set; }

    public virtual Reference? IdReferenceNavigation { get; set; }

    public virtual ICollection<MouvementPointDeVente> MouvementPointDeVentes { get; set; } = new List<MouvementPointDeVente>();

    public virtual ICollection<Mouvement> Mouvements { get; set; } = new List<Mouvement>();

    public virtual ICollection<ReportPointDeVente> ReportPointDeVentes { get; set; } = new List<ReportPointDeVente>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
}
