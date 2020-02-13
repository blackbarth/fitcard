using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FitCard.Domain.Entities;

namespace FitCard.Domain.DTOs
{
    public class CategoriaDTO
    {
        [MaxLength(40)]
        [DisplayName("Categoria")]
        public string CategoriaNome { get; set; }

        public virtual ICollection<EmpresaEntity> Empresas { get; set; }
    }
}