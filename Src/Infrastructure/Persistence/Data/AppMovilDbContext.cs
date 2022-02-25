using System;
using System.Collections.Generic;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.Persistence.Data
{
    public partial class AppMovilDbContext : DbContext
    {
        public AppMovilDbContext() : base()
        {
        }

        public AppMovilDbContext(DbContextOptions<AppMovilDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<App> Apps { get; set; } = null!;
        public virtual DbSet<AppVersion> AppVersions { get; set; } = null!;
        public virtual DbSet<Descarga> Descargas { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<App>(entity =>
            {
                entity.ToTable("App");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<AppVersion>(entity =>
            {
                entity.ToTable("AppVersion");

                entity.Property(e => e.AppVersion1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("app_version");

                entity.Property(e => e.FechaPublicacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_publicacion")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdApp).HasColumnName("Id_app");

                entity.Property(e => e.UrlDescarga)
                    .HasMaxLength(2048)
                    .IsUnicode(false)
                    .HasColumnName("url_descarga");

                entity.HasOne(d => d.IdAppNavigation)
                    .WithMany(p => p.AppVersions)
                    .HasForeignKey(d => d.IdApp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppVersion_App");
            });

            modelBuilder.Entity<Descarga>(entity =>
            {
                entity.ToTable("DescargaUsuario");

                entity.Property(e => e.FechaDescarga)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_descarga")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdAppVersion).HasColumnName("Id_app_version");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");

                entity.HasOne(d => d.IdAppVersionNavigation)
                    .WithMany(p => p.DescargaUsuarios)
                    .HasForeignKey(d => d.IdAppVersion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DescargaUsuario_AppVersion");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.DescargaUsuarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DescargaUsuario_Usuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });
        }
    }
}
