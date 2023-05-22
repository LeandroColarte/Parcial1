using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Parcial1.Models
{
    public partial class FormularioContext : DbContext
    {
        public FormularioContext()
        {
        }

        public FormularioContext(DbContextOptions<FormularioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<Form> Forms { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__A3C02A10324C1DD1");

                entity.Property(e => e.TiposCategoria)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Form>(entity =>
            {
                entity.HasKey(e => e.IdForm)
                    .HasName("PK__Form__007D03D93B3CA4BC");

                entity.ToTable("Form");

                entity.Property(e => e.Cuit)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Domicilio)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RazonSocial)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.oCategorium)
                    .WithMany(p => p.Forms)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK_Categoria");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
