using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FitCard.Domain.Validations
{
    public class DataHoraCompareAttribute : ValidationAttribute, IClientModelValidator
    {
        public string NomeComparacao { get; set; }

        public DataHoraCompareAttribute(string nomeComparacao)
        {
            NomeComparacao = nomeComparacao;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext.ObjectInstance != null)
            {
                Type _t = validationContext.ObjectInstance.GetType();
                PropertyInfo _d = _t.GetProperty(NomeComparacao);
                if (_d != null)
                {
                    DateTime _dt1 = (DateTime)value;
                    DateTime _dt0 = (DateTime)_d
                        .GetValue(validationContext.ObjectInstance, null);
                    if (_dt1 != null &&
                        _dt0 != null &&
                        _dt0 <= _dt1)
                    {
                        return ValidationResult.Success;
                    }
                }
            }
            return new ValidationResult("A data final é menor que os dados inicial");
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            context.Attributes.Add("data-val-datetimecompare", ErrorMessageString);
            context.Attributes.Add("data-val-datetimecompare-param", NomeComparacao);
        }
    }
}