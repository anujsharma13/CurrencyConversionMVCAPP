using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConversionMVCAPP.Repository
{
    public class NumberValidation : ValidationAttribute
    {
        public NumberValidation(string allowed)
        {
            Allowed = allowed;
        }

        public string Allowed { get; }

        public override bool IsValid(object value)
        {
            string s = value.ToString();
            if (s.Contains('e'))
                return false;
            return true;
        }
    }
}
