using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ejercicio5.Models
{
    public partial class pixarContext : DbContext
    {
        public pixarContext()
        {
        }

        public pixarContext(DbContextOptions<pixarContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Apariciones> Apariciones { get; set; } = null!;
        public virtual DbSet<Categoria> Categoria { get; set; } = null!;
        public virtual DbSet<Cortometraje> Cortometraje { get; set; } = null!;
        public virtual DbSet<Pelicula> Pelicula { get; set; } = null!;
        public virtual DbSet<Personaje> Personaje { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=pixar;user=root;password=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.17-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Apariciones>(entity =>
            {
                entity.ToTable("apariciones");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.IdPelicula, "fkPelicula_idx");

                entity.HasIndex(e => e.IdPersonaje, "fkPersonaje_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.IdPelicula).HasColumnType("int(11)");

                entity.Property(e => e.IdPersonaje).HasColumnType("int(11)");

                entity.HasOne(d => d.IdPeliculaNavigation)
                    .WithMany(p => p.Apariciones)
                    .HasForeignKey(d => d.IdPelicula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkPelicula");

                entity.HasOne(d => d.IdPersonajeNavigation)
                    .WithMany(p => p.Apariciones)
                    .HasForeignKey(d => d.IdPersonaje)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkPersonaje");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("categoria");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Nombre).HasMaxLength(45);
            });

            modelBuilder.Entity<Cortometraje>(entity =>
            {
                entity.ToTable("cortometraje");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.IdCategoria, "fkCategoria_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Descripcion).HasColumnType("text");

                entity.Property(e => e.IdCategoria).HasColumnType("int(11)");

                entity.Property(e => e.Nombre).HasMaxLength(45);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Cortometraje)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("fkCategoria");
            });

            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.ToTable("pelicula");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Descripción).HasColumnType("text");

                entity.Property(e => e.Nombre).HasMaxLength(45);

                entity.Property(e => e.NombreOriginal).HasMaxLength(100);
            });

            modelBuilder.Entity<Personaje>(entity =>
            {
                entity.ToTable("personaje");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Nombre).HasMaxLength(45);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
