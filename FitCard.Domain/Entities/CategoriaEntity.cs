using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FitCard.Domain.Entities
{
    public class CategoriaEntity : BaseEntity
    {
        public CategoriaEntity()
        {
            Empresas = new Collection<EmpresaEntity>();
        }

        [MaxLength(40)]
        [DisplayName("Categoria")]
        public string CategoriaNome { get; set; }

        public virtual ICollection<EmpresaEntity> Empresas { get; set; }
    }
}