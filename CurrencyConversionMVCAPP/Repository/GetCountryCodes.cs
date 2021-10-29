using CurrencyConversionMVCAPP.Models;
using CurrencyConversionMVCAPP.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConversionMVCAPP.Repository
{
    public class GetCountryCodes:IGetCountryCodes
    {
        public string Convert(Countries Deserializeobj,string Countrycode)
        {
            var currencydata = Deserializeobj.countries.FirstOrDefault(x => x.countryCode == Countrycode);
            var CountryCode = currencydata.countryCode;
            return CountryCode;
        }

    }
}
