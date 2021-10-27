using CurrencyConversionMVCAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConversionMVCAPP.Repository
{
    public class GetCountryCodes
    {
        public static string Convert(Countries Deserializeobj,string currencycode)
        {
            var currencydata = Deserializeobj.countries.FirstOrDefault(x => x.currencyCode == currencycode);
            var CountryCode = currencydata.countryCode;
            return CountryCode;
        }

    }
}
