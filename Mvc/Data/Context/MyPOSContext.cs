using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Mvc.Data.Models;

namespace Mvc.Data.Context
{
    public partial class MyPOSContext : DbContext
    {
        public MyPOSContext()
        {
        }

        public MyPOSContext(DbContextOptions<MyPOSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Municipality> Municipalities { get; set; } = null!;
        public virtual DbSet<Occasion> Occasions { get; set; } = null!;
        public virtual DbSet<Office> Offices { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductOccasion> ProductOccasions { get; set; } = null!;
        public virtual DbSet<Provider> Providers { get; set; } = null!;
        public virtual DbSet<State> States { get; set; } = null!;
        public virtual DbSet<TempCodigo> TempCodigos { get; set; } = null!;
        public virtual DbSet<ZipCode> ZipCodes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.IntNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdSettlementNavigation)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.IdSettlement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Addresses_ZipCodes");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdParentNavigation)
                    .WithMany(p => p.InverseIdParentNavigation)
                    .HasForeignKey(d => d.IdParent)
                    .HasConstraintName("FK_Categories_Categories");
            });

            modelBuilder.Entity<Municipality>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdStateNavigation)
                    .WithMany(p => p.Municipalities)
                    .HasForeignKey(d => d.IdState)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Municipalities_States");
            });

            modelBuilder.Entity<Occasion>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Office>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAddressNavigation)
                    .WithMany(p => p.Offices)
                    .HasForeignKey(d => d.IdAddress)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Offices_Addresses");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Categories");

                entity.HasOne(d => d.IdProviderNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdProvider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Providers");
            });

            modelBuilder.Entity<ProductOccasion>(entity =>
            {
                entity.ToTable("ProductOccasion");

                entity.HasOne(d => d.IdOccasionNavigation)
                    .WithMany(p => p.ProductOccasions)
                    .HasForeignKey(d => d.IdOccasion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductOccasion_Occasions");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.ProductOccasions)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductOccasion_Products");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAddressNavigation)
                    .WithMany(p => p.Providers)
                    .HasForeignKey(d => d.IdAddress)
                    .HasConstraintName("FK_Providers_Addresses");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TempCodigo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tempCodigos");

                entity.Property(e => e.CCp)
                    .IsUnicode(false)
                    .HasColumnName("c_CP");

                entity.Property(e => e.CCveCiudad)
                    .IsUnicode(false)
                    .HasColumnName("c_cve_ciudad");

                entity.Property(e => e.CEstado)
                    .IsUnicode(false)
                    .HasColumnName("c_estado");

                entity.Property(e => e.CMnpio)
                    .IsUnicode(false)
                    .HasColumnName("c_mnpio");

                entity.Property(e => e.COficina)
                    .IsUnicode(false)
                    .HasColumnName("c_oficina");

                entity.Property(e => e.CTipoAsenta)
                    .IsUnicode(false)
                    .HasColumnName("c_tipo_asenta");

                entity.Property(e => e.DAsenta)
                    .IsUnicode(false)
                    .HasColumnName("d_asenta");

                entity.Property(e => e.DCiudad)
                    .IsUnicode(false)
                    .HasColumnName("d_ciudad");

                entity.Property(e => e.DCodigo)
                    .IsUnicode(false)
                    .HasColumnName("d_codigo");

                entity.Property(e => e.DCp)
                    .IsUnicode(false)
                    .HasColumnName("d_CP");

                entity.Property(e => e.DEstado)
                    .IsUnicode(false)
                    .HasColumnName("d_estado");

                entity.Property(e => e.DMnpio)
                    .IsUnicode(false)
                    .HasColumnName("D_mnpio");

                entity.Property(e => e.DTipoAsenta)
                    .IsUnicode(false)
                    .HasColumnName("d_tipo_asenta");

                entity.Property(e => e.DZona)
                    .IsUnicode(false)
                    .HasColumnName("d_zona");

                entity.Property(e => e.IdAsentaCpcons)
                    .IsUnicode(false)
                    .HasColumnName("id_asenta_cpcons");
            });

            modelBuilder.Entity<ZipCode>(entity =>
            {
                entity.Property(e => e.Settlement)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMunicipalityNavigation)
                    .WithMany(p => p.ZipCodes)
                    .HasForeignKey(d => d.IdMunicipality)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ZipCodes_Municipalities");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
