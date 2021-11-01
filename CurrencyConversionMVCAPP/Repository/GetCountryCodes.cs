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
        public CurrencyData Convert(Countries Deserializeobj,string Currencycode)
        {
            var currencydata = Deserializeobj.countries.FirstOrDefault(x => x.currencyCode == Currencycode);
           
            return currencydata;
        }

    }
}
