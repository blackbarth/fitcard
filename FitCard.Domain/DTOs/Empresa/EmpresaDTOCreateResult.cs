using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FitCard.Domain.Entities;

namespace FitCard.Domain.DTOs.Empresa
{
    public class EmpresaDTOCreateResult
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Razão Social é Preenchimento Obrigatório")]
        [DisplayName("Razão Social")]
        [MaxLength(100)]
        public string EmpresaRazao { get; set; }

        [MaxLength(100)]
        [DisplayName("Nome Fantasia")]
        public string EmpresaNomeFantasia { get; set; }

        [Required(ErrorMessage = "CNPJ é Preenchimento Obrigatório")]
        [DisplayName("CNPJ")]
        [MaxLength(40)]
        public string EmpresaCNPJ { get; set; }

        [DisplayName("E-mail")]
        [MaxLength(100)]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string EmpresaEmail { get; set; }

        [DisplayName("Endereço")]
        [MaxLength(150)]
        public string EmpresaEndereco { get; set; }

        [DisplayName("Cidade")]
        [MaxLength(50)]
        public string EmpresaCidade { get; set; }

        [DisplayName("Estado")]
        [MaxLength(40)]
        public string EmpresaEstado { get; set; }

        [DisplayName("Telefone")]
        [MaxLength(15)]
        public string EmpresaTelefone { get; set; }

        [Display(Name = "Data Cadastro")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EmpresaDataCadastro { get; set; }

        [DisplayName("Status")]
        [MaxLength(3)]
        public string EmpresaStatus { get; set; }

        [DisplayName("Agencia")]
        [MaxLength(5)]
        public string EmpresaAgencia { get; set; }

        [DisplayName("Conta")]
        [MaxLength(10)]
        public string EmpresaConta { get; set; }


        //public CategoriaEntity Categoria { get; set; }

        [DisplayName("Categoria")]
        public int CategoriaId { get; set; }
    }
}