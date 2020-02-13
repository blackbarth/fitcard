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
            modelBuilder.Entity<CategoriaEntity>(new CategoriaMap().Configure);
            modelBuilder.Entity<EmpresaEntity>(new EmpresaMap().Configure);
        }
        public DbSet<CategoriaEntity> Categoria { get; set; }
        public DbSet<EmpresaEntity> Empresa { get; set; }
    }
}