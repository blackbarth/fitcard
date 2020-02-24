using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace FitCard.Domain.Validations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class DataAttribute : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            bool valido = true;

            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                valido = false;
            }



            if (value != null)
            {
                DateTime data = Convert.ToDateTime(value);
                Regex r = new Regex(@"^([0]?[1-9]|[1|2][0-9]|[3][0|1])[./-]([0]?[1-9]|[1][0-2])[./-]([0-9]{4}|[0-9]{2})$");
                valido = r.Match(data.ToShortDateString()).Success;
            }

            return valido;
        }
    }
}
