using System;
using System.ComponentModel.DataAnnotations;

namespace FitCard.Domain.Validations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class DataAttribute : ValidationAttribute
    {


        //protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //{
        //    DateTime dateTime = Convert.ToDateTime(value);

        //    if (dateTime <= DateTime.Now)
        //    {
        //        return new ValidationResult("Erros");
        //    }


        //    return ValidationResult.Success;
        //}
        public override bool IsValid(object value)
        {
            DateTime dateTime = Convert.ToDateTime(value);
            return dateTime <= DateTime.Now;
        }
    }
}
