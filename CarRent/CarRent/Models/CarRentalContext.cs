using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Models;

public partial class CarRentalContext : DbContext
{
    public CarRentalContext()
    {
    }

    public CarRentalContext(DbContextOptions<CarRentalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Avto> Avtos { get; set; }

    public virtual DbSet<Dogovor> Dogovors { get; set; }

    public virtual DbSet<Klient> Klients { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=CarRental;Trusted_Connection=True; Integrated Security = true; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Avto>(entity =>
        {
            entity.HasKey(e => e.AvtoId).HasName("PK__Avto__20000193EB8D53ED");

            entity.ToTable("Avto");

            entity.Property(e => e.AvtoId).HasColumnName("Avto_id");
            entity.Property(e => e.BrandName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Brand_name");
            entity.Property(e => e.ClassName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Class_name");
            entity.Property(e => e.Color)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Drive)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Endgine)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Mark)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Photo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Transmission)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Weel)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.YearOfProduction)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Year_of_production");
        });

        modelBuilder.Entity<Dogovor>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Dogovor");

            entity.Property(e => e.AvtoId).HasColumnName("Avto_id");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.DogovorId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Dogovor_id");
            entity.Property(e => e.KlientId).HasColumnName("Klient_id");
            entity.Property(e => e.ManagerId).HasColumnName("Manager_id");

            entity.HasOne(d => d.Avto).WithMany()
                .HasForeignKey(d => d.AvtoId)
                .HasConstraintName("FK__Dogovor__Avto_id__5FB337D6");

            entity.HasOne(d => d.Klient).WithMany()
                .HasForeignKey(d => d.KlientId)
                .HasConstraintName("FK__Dogovor__Klient___5DCAEF64");

            entity.HasOne(d => d.Manager).WithMany()
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK__Dogovor__Manager__5EBF139D");
        });

        modelBuilder.Entity<Klient>(entity =>
        {
            entity.HasKey(e => e.KlientId).HasName("PK__Klient__FB9C4B5D4964DCAC");

            entity.ToTable("Klient");

            entity.Property(e => e.KlientId).HasColumnName("Klient_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Birthday)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DriversLicense)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Drivers_license");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("First_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Last_name");
            entity.Property(e => e.Passport)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Patronymic)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.ManagerId).HasName("PK__Manager__ADA093659B87F785");

            entity.ToTable("Manager");

            entity.Property(e => e.ManagerId).HasColumnName("Manager_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("First_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Last_name");
            entity.Property(e => e.Login)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Patronymic)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
