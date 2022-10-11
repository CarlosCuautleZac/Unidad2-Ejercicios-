using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ejercicio6.Models
{
    public partial class villancicosContext : DbContext
    {
        public villancicosContext()
        {
        }

        public villancicosContext(DbContextOptions<villancicosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Villancico> Villancicos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;username=root;password=root;database=villancicos", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.17-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<Villancico>(entity =>
            {
                entity.ToTable("villancico");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Anyo).HasColumnType("int(11)");

                entity.Property(e => e.Compositor).HasMaxLength(50);

                entity.Property(e => e.Idioma).HasMaxLength(45);

                entity.Property(e => e.Información).HasColumnType("text");

                entity.Property(e => e.Letra).HasColumnType("text");

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.Property(e => e.VideoUrl)
                    .HasMaxLength(200)
                    .HasColumnName("VideoURL");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
