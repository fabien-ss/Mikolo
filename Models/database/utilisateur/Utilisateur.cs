using System;
using System.Collections.Generic;
using mikolo.Models.authentification;

namespace mikolo;

public partial class Utilisateur : Auth
{
    public string? Id { get; set; } = null!;

    public string Nom { get; set; } = null!;

    public string? Prenom { get; set; }

    public DateOnly? DateEmbauche { get; set; }

    public DateOnly? DateResilliation { get; set; }

    public string? IdPointDeVente { get; set; }

    public virtual PointDeVente? IdPointDeVenteNavigation { get; set; }
    public void register(Object mikoloContext)
    {
        MikoloContext _mikoloContext = (MikoloContext)mikoloContext;
        _mikoloContext.Add(this);
        _mikoloContext.SaveChanges();
    }

    public void login(Object mikoloContext)
    {
        MikoloContext _mikoloContext = (MikoloContext) mikoloContext;
        Utilisateur utilisateur = _mikoloContext.Utilisateurs.
            Where(u => u.Nom == this.Nom && this.Prenom == this.Prenom).First();
        if (utilisateur == null) throw new Exception("Login invalide");
    }

    public string getString()
    {
        throw new NotImplementedException();
    }
}
