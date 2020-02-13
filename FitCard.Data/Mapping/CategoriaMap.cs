﻿using FitCard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitCard.Data.Mapping
{
    public class CategoriaMap : IEntityTypeConfiguration<CategoriaEntity>
    {
        public void Configure(EntityTypeBuilder<CategoriaEntity> builder)
        {
            builder.ToTable("Categoria");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CategoriaNome)
                .IsRequired()
                .HasMaxLength(40);
        }
    }
}