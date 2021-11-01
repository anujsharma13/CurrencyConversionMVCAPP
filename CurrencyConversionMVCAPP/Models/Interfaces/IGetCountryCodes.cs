using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConversionMVCAPP.Models.Interfaces
{
   public interface IGetCountryCodes
    {
        public CurrencyData Convert(Countries Deserializeobj, string currencycode);
    }
}
