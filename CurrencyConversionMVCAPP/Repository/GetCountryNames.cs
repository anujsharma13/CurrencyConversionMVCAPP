using CurrencyConversionMVCAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConversionMVCAPP.Repository
{
    public class GetCountryNames
    {
        public static string Convert(Countries Deserializeobj, string Countrycode)
        {
            var currencydata = Deserializeobj.countries.FirstOrDefault(x => x.countryCode == Countrycode);
            var CountryName = currencydata.countryName;
            return CountryName;
        }
    }
}
