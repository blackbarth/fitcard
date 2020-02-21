using FitCard.Data.Mapping;
using FitCard.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitCard.Data.Context
{
    public class FitCardContext : DbContext
    {
        public FitCardContext(DbContextOptions options) : base(options)
        {
            //Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<CategoriaEntity>(new CategoriaMap().Configure);
            //modelBuilder.Entity<EmpresaEntity>(new EmpresaMap().Configure);
            //modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            modelBuilder.Entity<CategoriaEntity>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CategoriaFotoUrl).HasMaxLength(500);

                entity.Property(e => e.CategoriaNome)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<EmpresaEntity>(entity =>
            {

                entity.HasIndex(e => e.CategoriaId)
                    .HasName("IX_Empresa_CategoriaId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EmpresaAgencia).HasMaxLength(5);

                entity.Property(e => e.EmpresaCidade).HasMaxLength(50);

                entity.Property(e => e.EmpresaCnpj)
                    .IsRequired()
                    .HasColumnName("EmpresaCnpj")
                    .HasMaxLength(40);

                entity.Property(e => e.EmpresaConta).HasMaxLength(10);

                entity.Property(e => e.EmpresaEmail).HasMaxLength(100);

                entity.Property(e => e.EmpresaEndereco).HasMaxLength(150);

                entity.Property(e => e.EmpresaEstado).HasMaxLength(40);

                entity.Property(e => e.EmpresaNomeFantasia).HasMaxLength(100);

                entity.Property(e => e.EmpresaRazao)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.EmpresaStatus).HasMaxLength(10);

                entity.Property(e => e.EmpresaTelefone).HasMaxLength(20);

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Empresa)
                    .HasForeignKey(d => d.CategoriaId);
            });

            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100);
            });

        }
        public virtual DbSet<CategoriaEntity> Categoria { get; set; }
        public virtual DbSet<EmpresaEntity> Empresa { get; set; }
        public virtual DbSet<UserEntity> User { get; set; }
    }
}