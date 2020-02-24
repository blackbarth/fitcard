using System;
using System.ComponentModel.DataAnnotations;

namespace FitCard.Domain.Validations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed class CnpjAttribute : ValidationAttribute
    {

       

        public override bool IsValid(object value)
        {



            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return false;
            }

            //logica de validação customizada

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            string cnpj = value.ToString().Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
            {
                return false;
            }


            string tempCnpj = cnpj.Substring(0, 12);
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            int resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            if (!cnpj.EndsWith(digito))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //{

        //    //logica de validação customizada

        //    int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        //    int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        //    string cnpj = value.ToString().Trim().Replace(".", "").Replace("-", "").Replace("/", "");
        //    if (cnpj.Length != 14)
        //    {
        //        return new ValidationResult("Ops!!! CNPJ inválido.");
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
        //        return new ValidationResult("Ops!!! CNPJ inválido.");
        //    }
        //    return ValidationResult.Success;

        //}
        //public override string FormatErrorMessage(string name)
        //{
        //    return name;
        //}
    }
}