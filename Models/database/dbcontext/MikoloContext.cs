using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace mikolo;

public partial class MikoloContext : DbContext
{
    public MikoloContext()
    {
    }

    public MikoloContext(DbContextOptions<MikoloContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DisqueDur> DisqueDurs { get; set; }

    public virtual DbSet<Ecran> Ecrans { get; set; }

    public virtual DbSet<Laptop> Laptops { get; set; }

    public virtual DbSet<Marque> Marques { get; set; }

    public virtual DbSet<Mouvement> Mouvements { get; set; }

    public virtual DbSet<MouvementPointDeVente> MouvementPointDeVentes { get; set; }

    public virtual DbSet<PointDeVente> PointDeVentes { get; set; }

    public virtual DbSet<Processeur> Processeurs { get; set; }

    public virtual DbSet<Ram> Rams { get; set; }

    public virtual DbSet<Reference> References { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<ReportPointDeVente> ReportPointDeVentes { get; set; }

    public virtual DbSet<Utilisateur> Utilisateurs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=ConnectionStrings:MikoloDbContext");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DisqueDur>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("disque_dur_pkey");

            entity.ToTable("disque_dur");

            entity.Property(e => e.Id)
                .HasMaxLength(20)
                .HasDefaultValueSql("nextval('disque_dur_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Label)
                .HasMaxLength(200)
                .HasColumnName("label");
            entity.Property(e => e.Rotation).HasColumnName("rotation");
            entity.Property(e => e.Stockage).HasColumnName("stockage");
            entity.Property(e => e.Taille).HasColumnName("taille");
        });

        modelBuilder.Entity<Ecran>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ecran_pkey");

            entity.ToTable("ecran");

            entity.Property(e => e.Id)
                .HasMaxLength(20)
                .HasDefaultValueSql("nextval('ecran_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Label)
                .HasMaxLength(200)
                .HasColumnName("label");
            entity.Property(e => e.Taille).HasColumnName("taille");
        });

        modelBuilder.Entity<Laptop>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("laptop_pkey");

            entity.ToTable("laptop");

            entity.Property(e => e.Id)
                .HasMaxLength(20)
                .HasDefaultValueSql("nextval('laptop_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.IdDisqueDur)
                .HasMaxLength(20)
                .HasColumnName("id_disque_dur");
            entity.Property(e => e.IdEcran)
                .HasMaxLength(20)
                .HasColumnName("id_ecran");
            entity.Property(e => e.IdProcesseur)
                .HasMaxLength(20)
                .HasColumnName("id_processeur");
            entity.Property(e => e.IdRam)
                .HasMaxLength(20)
                .HasColumnName("id_ram");
            entity.Property(e => e.IdReference)
                .HasMaxLength(20)
                .HasColumnName("id_reference");

            entity.HasOne(d => d.IdDisqueDurNavigation).WithMany(p => p.Laptops)
                .HasForeignKey(d => d.IdDisqueDur)
                .HasConstraintName("laptop_id_disque_dur_fkey");

            entity.HasOne(d => d.IdEcranNavigation).WithMany(p => p.Laptops)
                .HasForeignKey(d => d.IdEcran)
                .HasConstraintName("laptop_id_ecran_fkey");

            entity.HasOne(d => d.IdProcesseurNavigation).WithMany(p => p.Laptops)
                .HasForeignKey(d => d.IdProcesseur)
                .HasConstraintName("laptop_id_processeur_fkey");

            entity.HasOne(d => d.IdRamNavigation).WithMany(p => p.Laptops)
                .HasForeignKey(d => d.IdRam)
                .HasConstraintName("laptop_id_ram_fkey");

            entity.HasOne(d => d.IdReferenceNavigation).WithMany(p => p.Laptops)
                .HasForeignKey(d => d.IdReference)
                .HasConstraintName("laptop_id_reference_fkey");
        });

        modelBuilder.Entity<Marque>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("marque_pkey");

            entity.ToTable("marque");

            entity.Property(e => e.Id)
                .HasMaxLength(20)
                .HasDefaultValueSql("nextval('marque_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Label)
                .HasMaxLength(200)
                .HasColumnName("label");
        });

        modelBuilder.Entity<Mouvement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mouvement_pkey");

            entity.ToTable("mouvement");

            entity.Property(e => e.Id)
                .HasMaxLength(20)
                .HasDefaultValueSql("nextval('mouvement_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.DateMouvement)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_mouvement");
            entity.Property(e => e.Entree).HasColumnName("entree");
            entity.Property(e => e.IdLaptop)
                .HasMaxLength(20)
                .HasColumnName("id_laptop");
            entity.Property(e => e.Sortie).HasColumnName("sortie");

            entity.HasOne(d => d.IdLaptopNavigation).WithMany(p => p.Mouvements)
                .HasForeignKey(d => d.IdLaptop)
                .HasConstraintName("mouvement_id_laptop_fkey");
        });

        modelBuilder.Entity<MouvementPointDeVente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mouvement_point_de_vente_pkey");

            entity.ToTable("mouvement_point_de_vente");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Entree).HasColumnName("entree");
            entity.Property(e => e.IdLaptop)
                .HasMaxLength(20)
                .HasColumnName("id_laptop");
            entity.Property(e => e.IdPointDeVente)
                .HasMaxLength(20)
                .HasColumnName("id_point_de_vente");
            entity.Property(e => e.Sortie).HasColumnName("sortie");

            entity.HasOne(d => d.IdLaptopNavigation).WithMany(p => p.MouvementPointDeVentes)
                .HasForeignKey(d => d.IdLaptop)
                .HasConstraintName("mouvement_point_de_vente_id_laptop_fkey");

            entity.HasOne(d => d.IdPointDeVenteNavigation).WithMany(p => p.MouvementPointDeVentes)
                .HasForeignKey(d => d.IdPointDeVente)
                .HasConstraintName("mouvement_point_de_vente_id_point_de_vente_fkey");
        });

        modelBuilder.Entity<PointDeVente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("point_de_vente_pkey");

            entity.ToTable("point_de_vente");

            entity.Property(e => e.Id)
                .HasMaxLength(20)
                .HasDefaultValueSql("nextval('point_de_vente_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Adresse)
                .HasMaxLength(200)
                .HasColumnName("adresse");
            entity.Property(e => e.Label)
                .HasMaxLength(20)
                .HasColumnName("label");
            entity.Property(e => e.Latitude).HasColumnName("latitude");
            entity.Property(e => e.Longitude).HasColumnName("longitude");
        });

        modelBuilder.Entity<Processeur>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("processeur_pkey");

            entity.ToTable("processeur");

            entity.Property(e => e.Id)
                .HasMaxLength(20)
                .HasDefaultValueSql("nextval('processeur_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Coeur).HasColumnName("coeur");
            entity.Property(e => e.Frequence).HasColumnName("frequence");
            entity.Property(e => e.Gravure).HasColumnName("gravure");
            entity.Property(e => e.Label)
                .HasMaxLength(200)
                .HasColumnName("label");
        });

        modelBuilder.Entity<Ram>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ram_pkey");

            entity.ToTable("ram");

            entity.Property(e => e.Id)
                .HasMaxLength(20)
                .HasDefaultValueSql("nextval('ram_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Label)
                .HasMaxLength(200)
                .HasColumnName("label");
            entity.Property(e => e.Puissance).HasColumnName("puissance");
        });

        modelBuilder.Entity<Reference>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("reference_pkey");

            entity.ToTable("reference");

            entity.Property(e => e.Id)
                .HasMaxLength(20)
                .HasDefaultValueSql("nextval('reference_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.IdMarque)
                .HasMaxLength(20)
                .HasColumnName("id_marque");
            entity.Property(e => e.Label)
                .HasMaxLength(200)
                .HasColumnName("label");

            entity.HasOne(d => d.IdMarqueNavigation).WithMany(p => p.References)
                .HasForeignKey(d => d.IdMarque)
                .HasConstraintName("reference_id_marque_fkey");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("report_pkey");

            entity.ToTable("report");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateReport)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_report");
            entity.Property(e => e.IdLaptop)
                .HasMaxLength(20)
                .HasColumnName("id_laptop");
            entity.Property(e => e.Nombre).HasColumnName("nombre");

            entity.HasOne(d => d.IdLaptopNavigation).WithMany(p => p.Reports)
                .HasForeignKey(d => d.IdLaptop)
                .HasConstraintName("report_id_laptop_fkey");
        });

        modelBuilder.Entity<ReportPointDeVente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("report_point_de_vente_pkey");

            entity.ToTable("report_point_de_vente");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateReport)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_report");
            entity.Property(e => e.IdLaptop)
                .HasMaxLength(20)
                .HasColumnName("id_laptop");
            entity.Property(e => e.IdPointDeVente)
                .HasMaxLength(20)
                .HasColumnName("id_point_de_vente");
            entity.Property(e => e.Nombre).HasColumnName("nombre");

            entity.HasOne(d => d.IdLaptopNavigation).WithMany(p => p.ReportPointDeVentes)
                .HasForeignKey(d => d.IdLaptop)
                .HasConstraintName("report_point_de_vente_id_laptop_fkey");

            entity.HasOne(d => d.IdPointDeVenteNavigation).WithMany(p => p.ReportPointDeVentes)
                .HasForeignKey(d => d.IdPointDeVente)
                .HasConstraintName("report_point_de_vente_id_point_de_vente_fkey");
        });

        modelBuilder.Entity<Utilisateur>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("utilisateur_pkey");

            entity.ToTable("utilisateur");

            entity.Property(e => e.Id)
                .HasMaxLength(20)
                .HasDefaultValueSql("nextval('utilisateur_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.DateEmbauche).HasColumnName("date_embauche");
            entity.Property(e => e.DateResilliation).HasColumnName("date_resilliation");
            entity.Property(e => e.IdPointDeVente)
                .HasMaxLength(20)
                .HasColumnName("id_point_de_vente");
            entity.Property(e => e.Nom)
                .HasMaxLength(500)
                .HasColumnName("nom");
            entity.Property(e => e.Prenom)
                .HasMaxLength(200)
                .HasColumnName("prenom");

            entity.HasOne(d => d.IdPointDeVenteNavigation).WithMany(p => p.Utilisateurs)
                .HasForeignKey(d => d.IdPointDeVente)
                .HasConstraintName("utilisateur_id_point_de_vente_fkey");
        });
        modelBuilder.HasSequence("disque_dur_seq");
        modelBuilder.HasSequence("ecran_seq");
        modelBuilder.HasSequence("laptop_seq");
        modelBuilder.HasSequence("marque_seq");
        modelBuilder.HasSequence("mouvement_seq");
        modelBuilder.HasSequence("point_de_vente_seq");
        modelBuilder.HasSequence("processeur_seq");
        modelBuilder.HasSequence("ram_seq");
        modelBuilder.HasSequence("reference_seq");
        modelBuilder.HasSequence("utilisateur_seq");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
