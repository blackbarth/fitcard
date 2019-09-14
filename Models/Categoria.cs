using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FitCard.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        
        public Categoria()
        {
            Empresas = new Collection<Empresa>();
        }

        [Key]
        [DisplayName("Código")]
        public int CategoriaId { get; set; }
        [MaxLength(40)]
        [DisplayName("Categoria")]
        public string CategoriaNome { get; set; }

        public ICollection<Empresa> Empresas { get; set; }
    }
}
