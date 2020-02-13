using FitCard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitCard.Data.Mapping
{
    public class EmpresaMap : IEntityTypeConfiguration<EmpresaEntity>
    {
        public void Configure(EntityTypeBuilder<EmpresaEntity> builder)
        {
            builder.ToTable("Empresa");
            builder.HasKey("EmpresaId");
            builder.Property(c => c.EmpresaRazao)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(c => c.EmpresaCNPJ)
                .IsRequired()
                .HasMaxLength(40);
        }
    }
}