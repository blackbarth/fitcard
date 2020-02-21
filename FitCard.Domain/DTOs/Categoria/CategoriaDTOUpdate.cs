using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FitCard.Domain.Entities;

namespace FitCard.Domain.DTOs.Categoria
{
    public class CategoriaDTOUpdate
    {
        public Guid Id { get; set; }
        [MaxLength(40)]
        [DisplayName("Categoria")]
        public string CategoriaNome { get; set; }
        [DisplayName("Logo")]
        public string CategoriaFotoUrl { get; set; }
        public virtual ICollection<EmpresaEntity> Empresas { get; set; }
    }
}