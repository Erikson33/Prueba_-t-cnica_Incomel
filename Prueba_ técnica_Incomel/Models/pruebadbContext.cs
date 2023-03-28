using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Prueba__técnica_Incomel.Models
{
    public partial class pruebadbContext : DbContext
    {
        public pruebadbContext()
        {
        }

        public pruebadbContext(DbContextOptions<pruebadbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.Idempleado)
                    .HasName("PRIMARY");

                entity.ToTable("empleado");

                entity.HasIndex(e => e.Dpi, "DPI")
                    .IsUnique();

                entity.HasIndex(e => e.Idusuario, "IDUSUARIO");

                entity.Property(e => e.Idempleado)
                    .HasColumnType("int(11)")
                    .HasColumnName("IDEMPLEADO");

                entity.Property(e => e.Bonodecreto)
                    .HasColumnType("double(11,2)")
                    .HasColumnName("BONODECRETO")
                    .HasDefaultValueSql("'250.00'");

                entity.Property(e => e.Bonopaternidad)
                    .HasColumnType("double(11,2)")
                    .HasColumnName("BONOPATERNIDAD");

                entity.Property(e => e.CantHijos)
                    .HasColumnType("int(11)")
                    .HasColumnName("CANT_HIJOS");

                entity.Property(e => e.Dpi)
                    .HasMaxLength(45)
                    .HasColumnName("DPI");

                entity.Property(e => e.Fechacreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHACREACION")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Idusuario)
                    .HasColumnType("int(11)")
                    .HasColumnName("IDUSUARIO");

                entity.Property(e => e.Igss)
                    .HasColumnType("double(11,2)")
                    .HasColumnName("IGSS");

                entity.Property(e => e.Irtra)
                    .HasColumnType("double(11,2)")
                    .HasColumnName("IRTRA");

                entity.Property(e => e.Nombrecompleto)
                    .HasMaxLength(45)
                    .HasColumnName("NOMBRECOMPLETO");

                entity.Property(e => e.SalarioLiquido)
                    .HasColumnType("double(11,2)")
                    .HasColumnName("SALARIO_LIQUIDO");

                entity.Property(e => e.SalarioTotal)
                    .HasColumnType("double(11,2)")
                    .HasColumnName("SALARIO_TOTAL");

                entity.Property(e => e.Salariobase)
                    .HasColumnType("double(11,2)")
                    .HasColumnName("SALARIOBASE");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.Idusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("empleado_ibfk_1");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario)
                    .HasName("PRIMARY");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.Email, "EMAIL")
                    .IsUnique();

                entity.Property(e => e.Idusuario)
                    .HasColumnType("int(11)")
                    .HasColumnName("IDUSUARIO");

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(200)
                    .HasColumnName("CONTRASEÑA");

                entity.Property(e => e.Email)
                    .HasMaxLength(45)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_NACIMIENTO");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.TokenRecovery)
                    .HasMaxLength(200)
                    .HasColumnName("TOKEN_RECOVERY");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
