using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MySql.Data;
#nullable disable

namespace AppReactBL.Models
{
    public partial class appreactdbContext : DbContext
    {
        public appreactdbContext()
        {
        }

        public appreactdbContext(DbContextOptions<appreactdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<NmcBanque> NmcBanques { get; set; }
        public virtual DbSet<Nmccptban> Nmccptbans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;user id=root;database=appreactdb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NmcBanque>(entity =>
            {
                entity.HasKey(e => e.IdBanque)
                    .HasName("PRIMARY");

                entity.ToTable("nmc_banque");

                entity.Property(e => e.IdBanque)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_banque");

                entity.Property(e => e.CodeBanque)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("code_banque");

                entity.Property(e => e.NomBanque)
                    .IsRequired()
                    .HasColumnName("nom_banque");

                entity.Property(e => e.SigleBanque).HasColumnName("sigle_banque");
            });

            modelBuilder.Entity<Nmccptban>(entity =>
            {
                entity.HasKey(e => new { e.IdBanque, e.Idcptban })
                    .HasName("PRIMARY");

                entity.ToTable("nmccptban");

                entity.Property(e => e.IdBanque)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_banque");

                entity.Property(e => e.Idcptban)
                    .HasColumnType("int(11)")
                    .HasColumnName("idcptban");

                entity.Property(e => e.Codeagencecptban)
                    .HasMaxLength(254)
                    .HasColumnName("codeagencecptban");

                entity.Property(e => e.Codeguichetcptban)
                    .HasMaxLength(254)
                    .HasColumnName("codeguichetcptban");

                entity.Property(e => e.Ibancptban)
                    .HasMaxLength(254)
                    .HasColumnName("ibancptban");

                entity.Property(e => e.Numcptban)
                    .HasMaxLength(254)
                    .HasColumnName("numcptban");

                entity.Property(e => e.Ribcptban)
                    .HasMaxLength(254)
                    .HasColumnName("ribcptban");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
