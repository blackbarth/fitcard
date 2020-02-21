using System;

namespace FitCard.Domain.Entities
{
    public class EmpresaEntity : BaseEntity
    {

        public string EmpresaRazao { get; set; }
        public string EmpresaNomeFantasia { get; set; }
        public string EmpresaCnpj { get; set; }
        public string EmpresaEmail { get; set; }
        public string EmpresaEndereco { get; set; }
        public string EmpresaCidade { get; set; }
        public string EmpresaEstado { get; set; }
        public string EmpresaTelefone { get; set; }
        public DateTime? EmpresaDataCadastro { get; set; }
        public string EmpresaStatus { get; set; }
        public string EmpresaAgencia { get; set; }
        public string EmpresaConta { get; set; }
        public int CategoriaId { get; set; }

        //public virtual CategoriaEntity Categoria { get; set; }
    }
}