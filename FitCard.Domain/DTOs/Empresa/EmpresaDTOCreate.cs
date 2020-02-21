using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FitCard.Domain.Entities;
using FitCard.Domain.Validations;

namespace FitCard.Domain.DTOs.Empresa
{
    public class EmpresaDTOCreate : IValidatableObject
    {
        public Guid Id { get; set; }
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
        [Cnpj(ErrorMessage = "Ops!!! CNPJ Invalido!!!")]
        public string EmpresaCNPJ { get; set; }

        [DisplayName("E-mail")]
        [MaxLength(100)]
        [Mail(ErrorMessage = "Email no Formato invalido!!!")]
        //[DataType(DataType.EmailAddress)]
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
        [MaxLength(16)]
        public string EmpresaTelefone { get; set; }

        [Display(Name = "Data Cadastro")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EmpresaDataCadastro { get; set; }

        [DisplayName("Status")]
        [MaxLength(10)]
        public string EmpresaStatus { get; set; }

        [DisplayName("Agencia")]
        [MaxLength(5)]
        public string EmpresaAgencia { get; set; }

        [DisplayName("Conta")]
        [MaxLength(10)]
        public string EmpresaConta { get; set; }


        //public CategoriaEntity Categoria { get; set; }

        [DisplayName("Categoria")]
        public Guid CategoriaId { get; set; }
         public virtual CategoriaEntity Categoria { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{


        //    var isValid = true;
        //    string GetErrorMessage() => $"CNPJ INVALIDO.";
        //    //logica de validação customizada

        //    int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        //    int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        //    string cnpj = EmpresaCNPJ.ToString().Trim().Replace(".", "").Replace("-", "").Replace("/", "");
        //    if (cnpj.Length != 14)
        //    {
        //        isValid = false;
        //    }


        //    string tempCnpj = cnpj.Substring(0, 12);
        //    int soma = 0;

        //    for (int i = 0; i < 12; i++)
        //        soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

        //    int resto = (soma % 11);
        //    if (resto < 2)
        //        resto = 0;
        //    else
        //        resto = 11 - resto;

        //    string digito = resto.ToString();
        //    tempCnpj = tempCnpj + digito;
        //    soma = 0;
        //    for (int i = 0; i < 13; i++)
        //        soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

        //    resto = (soma % 11);
        //    if (resto < 2)
        //        resto = 0;
        //    else
        //        resto = 11 - resto;

        //    digito = digito + resto.ToString();

        //    if (!cnpj.EndsWith(digito))
        //    {
        //        yield return new ValidationResult(
        //            $"CNPJ INVALIDO.",
        //            new[] { nameof(this.EmpresaCNPJ) });
        //    }


        //}
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (CategoriaId == Guid.Parse("8439A2C2-208E-4F36-A2F6-C5688119C377") && string.IsNullOrEmpty(EmpresaTelefone))
                yield return new ValidationResult("O campo Telefone é obrigatório caso categoria seja Supermercado!", new string[] { "EmpresaTelefone" });
        }
    }
}