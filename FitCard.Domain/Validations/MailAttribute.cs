using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace FitCard.Domain.Validations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class MailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool valido = true;

            if (value != null)
            {
                Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
                valido = rg.IsMatch(value.ToString());
            }
            return valido;
        }
    }
}
