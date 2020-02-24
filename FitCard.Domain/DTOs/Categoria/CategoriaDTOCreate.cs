using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FitCard.Domain.DTOs.Categoria
{
    public class CategoriaDTOCreate
    {
        public int Id { get; set; }
        [MaxLength(40)]
        [DisplayName("Categoria")]
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório!")]
        public string CategoriaNome { get; set; }
        [DisplayName("Logo")]
        public string CategoriaFotoUrl { get; set; }
        //public virtual ICollection<EmpresaEntity> Empresas { get; set; }
    }
}