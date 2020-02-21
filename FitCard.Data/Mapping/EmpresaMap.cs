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
            builder.HasKey(c => c.Id);
            //builder.HasIndex(e => e.CategoriaId)
            //    .HasName("IX_Empresa_CategoriaId");


            builder.Property(e => e.EmpresaAgencia).HasMaxLength(5);

            builder.Property(e => e.EmpresaCidade).HasMaxLength(50);

            builder.Property(e => e.EmpresaCnpj)
                .IsRequired()
                .HasColumnName("EmpresaCNPJ")
                .HasMaxLength(40);

            builder.Property(e => e.EmpresaConta).HasMaxLength(10);

            builder.Property(e => e.EmpresaEmail).HasMaxLength(100);

            builder.Property(e => e.EmpresaEndereco).HasMaxLength(150);

            builder.Property(e => e.EmpresaEstado).HasMaxLength(40);

            builder.Property(e => e.EmpresaNomeFantasia).HasMaxLength(100);

            builder.Property(e => e.EmpresaRazao)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.EmpresaStatus).HasMaxLength(10);

            builder.Property(e => e.EmpresaTelefone).HasMaxLength(20);

            //builder.HasOne(d => d.Categoria)
            //    .WithMany(p => p.Empresa)
            //    .HasForeignKey(d => d.CategoriaId);
        }
    }
}