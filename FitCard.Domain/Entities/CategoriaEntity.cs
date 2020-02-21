using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FitCard.Domain.Entities
{
    public class CategoriaEntity : BaseEntity
    {
        //public CategoriaEntity()
        //{
        //    Empresa = new Collection<EmpresaEntity>();
        //}

        [MaxLength(40)]
        [DisplayName("Categoria")]
        public string CategoriaNome { get; set; }

        public string CategoriaFotoUrl { get; set; }


        //public virtual ICollection<EmpresaEntity> Empresa { get; set; }

    }
}