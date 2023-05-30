using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using VP.Models;
using VP.Controllers;


namespace VP.Models;

public partial class SustaviBpContext : DbContext
{
    public SustaviBpContext()
    {
    }

    public SustaviBpContext(DbContextOptions<SustaviBpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DodjelaVozila> DodjelaVozilas { get; set; }

    public virtual DbSet<Kategorija> Kategorijas { get; set; }

    public virtual DbSet<LokacijaVozila> LokacijaVozilas { get; set; }

    public virtual DbSet<Marka> Markas { get; set; }

    public virtual DbSet<ModelVozila> ModelVozilas { get; set; }

    public virtual DbSet<Pozicija> Pozicijas { get; set; }

    public virtual DbSet<Uposlenik> Uposleniks { get; set; }

    public virtual DbSet<UposlenikKategorija> UposlenikKategorijas { get; set; }

    public virtual DbSet<Vozilo> Vozilos { get; set; }

    public virtual DbSet<VrstaVozila> VrstaVozilas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseNpgsql(connectionString);
            }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DodjelaVozila>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_Dodjela_vozila");

            entity.ToTable("Dodjela_vozila");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Dodatak)
                .HasMaxLength(50)
                .HasColumnName("dodatak");
            entity.Property(e => e.Dodjeljeno).HasColumnName("dodjeljeno");
            entity.Property(e => e.IdUposlenika).HasColumnName("id_uposlenika");
            entity.Property(e => e.IdVozila).HasColumnName("id_vozila");
            entity.Property(e => e.VratitiDo).HasColumnName("vratiti_do");

            entity.HasOne(d => d.IdUposlenikaNavigation).WithMany(p => p.DodjelaVozilas)
                .HasForeignKey(d => d.IdUposlenika)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Dodjela_vozila_id_uposlenika");

            entity.HasOne(d => d.IdVozilaNavigation).WithMany(p => p.DodjelaVozilas)
                .HasForeignKey(d => d.IdVozila)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Dodjela_vozila_id_vozila");
        });

        modelBuilder.Entity<Kategorija>(entity =>
        {
            entity.HasKey(e => e.IdKategorije).HasName("pk_Kategorija");

            entity.ToTable("Kategorija");

            entity.Property(e => e.IdKategorije).HasColumnName("id_kategorije");
            entity.Property(e => e.NazivKategorije)
                .HasMaxLength(30)
                .HasColumnName("naziv_kategorije");
            entity.Property(e => e.OpisKategorije)
                .HasMaxLength(40)
                .HasColumnName("opis_kategorije");
        });

        modelBuilder.Entity<LokacijaVozila>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_lokacija_vozila");

            entity.ToTable("lokacija_vozila");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NazivLokacije)
                .HasMaxLength(30)
                .HasColumnName("naziv_lokacije");
        });

        modelBuilder.Entity<Marka>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_Marka");

            entity.ToTable("Marka");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Naziv)
                .HasMaxLength(30)
                .HasColumnName("naziv");
        });

        modelBuilder.Entity<ModelVozila>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_Model_vozila");

            entity.ToTable("Model_vozila");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdMarke).HasColumnName("id_marke");
            entity.Property(e => e.Naziv)
                .HasMaxLength(30)
                .HasColumnName("naziv");

            entity.HasOne(d => d.IdMarkeNavigation).WithMany(p => p.ModelVozilas)
                .HasForeignKey(d => d.IdMarke)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Model_vozila_id_marke");
        });

        modelBuilder.Entity<Pozicija>(entity =>
        {
            entity.HasKey(e => e.PozicijaId).HasName("pk_Pozicija");

            entity.ToTable("Pozicija");

            entity.Property(e => e.PozicijaId).HasColumnName("pozicija_id");
            entity.Property(e => e.Naziv)
                .HasMaxLength(30)
                .HasColumnName("naziv");
        });

        modelBuilder.Entity<Uposlenik>(entity =>
        {
            entity.HasKey(e => e.IdUposlenik).HasName("pk_Uposlenik");

            entity.ToTable("Uposlenik");

            entity.Property(e => e.IdUposlenik).HasColumnName("id_uposlenik");
            entity.Property(e => e.Adresa)
                .HasMaxLength(30)
                .HasColumnName("adresa");
            entity.Property(e => e.BrojMobitela)
                .HasMaxLength(30)
                .HasColumnName("broj_mobitela");
            entity.Property(e => e.DatumRodjenja).HasColumnName("datum_rodjenja");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .HasColumnName("email");
            entity.Property(e => e.Ime)
                .HasMaxLength(30)
                .HasColumnName("ime");
            entity.Property(e => e.Jmbg)
                .HasMaxLength(15)
                .HasColumnName("jmbg");
            entity.Property(e => e.PozicijaId).HasColumnName("pozicija_id");
            entity.Property(e => e.Prezime)
                .HasMaxLength(30)
                .HasColumnName("prezime");

            entity.HasOne(d => d.Pozicija).WithMany(p => p.Uposleniks)
                .HasForeignKey(d => d.PozicijaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Uposlenik_pozicija_id");
        });

        modelBuilder.Entity<UposlenikKategorija>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_Uposlenik_kategorija");

            entity.ToTable("Uposlenik_kategorija");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdKategorije).HasColumnName("id_kategorije");
            entity.Property(e => e.IdUposlenik).HasColumnName("id_uposlenik");

            entity.HasOne(d => d.IdKategorijeNavigation).WithMany(p => p.UposlenikKategorijas)
                .HasForeignKey(d => d.IdKategorije)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Uposlenik_kategorija_id_kategorije");

            entity.HasOne(d => d.IdUposlenikNavigation).WithMany(p => p.UposlenikKategorijas)
                .HasForeignKey(d => d.IdUposlenik)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Uposlenik_kategorija_id_uposlenik");
        });

        modelBuilder.Entity<Vozilo>(entity =>
        {
            entity.HasKey(e => e.IdVozila).HasName("pk_Vozilo");

            entity.ToTable("Vozilo");

            entity.Property(e => e.IdVozila).HasColumnName("id_vozila");
            entity.Property(e => e.BrojSasije)
                .HasMaxLength(20)
                .HasColumnName("broj_sasije");
            entity.Property(e => e.GodinaProizvodnje).HasColumnName("godina_proizvodnje");
            entity.Property(e => e.Gorivo)
                .HasMaxLength(20)
                .HasColumnName("gorivo");
            entity.Property(e => e.IdLokacije).HasColumnName("id_lokacije");
            entity.Property(e => e.Kategorija)
                .HasMaxLength(5)
                .HasColumnName("kategorija");
            entity.Property(e => e.ModelVozila).HasColumnName("model_vozila");
            entity.Property(e => e.RegistracijskaOznaka)
                .HasMaxLength(20)
                .HasColumnName("registracijska_oznaka");
            entity.Property(e => e.VrstaVozila).HasColumnName("vrsta_vozila");

            entity.HasOne(d => d.IdLokacijeNavigation).WithMany(p => p.Vozilos)
                .HasForeignKey(d => d.IdLokacije)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Vozilo_id_lokacije");

            entity.HasOne(d => d.ModelVozilaNavigation).WithMany(p => p.Vozilos)
                .HasForeignKey(d => d.ModelVozila)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Vozilo_model_vozila");

            entity.HasOne(d => d.VrstaVozilaNavigation).WithMany(p => p.Vozilos)
                .HasForeignKey(d => d.VrstaVozila)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Vozilo_vrsta_vozila");
            entity.Property(e => e.PictureName)
                .HasMaxLength(255)
                .IsRequired(false);
            entity.Property(e => e.PictureData)
                .HasColumnType("bytea")
                .IsRequired(false);

        });

        modelBuilder.Entity<VrstaVozila>(entity =>
        {
            entity.HasKey(e => e.VrstaId).HasName("pk_Vrsta_vozila");

            entity.ToTable("Vrsta_vozila");

            entity.Property(e => e.VrstaId).HasColumnName("vrsta_id");
            entity.Property(e => e.Naziv)
                .HasMaxLength(30)
                .HasColumnName("naziv");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
