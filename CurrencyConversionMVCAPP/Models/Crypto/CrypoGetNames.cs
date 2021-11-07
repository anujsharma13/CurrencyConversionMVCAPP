using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConversionMVCAPP.Models.Crypto
{
    public class CrypoGetNames
    {
        public static IEnumerable<SelectListItem> get(CryptoCurrency c)
        {
            var x = c.cryptocurrency.Select(x => new SelectListItem { Text = x.CurrencyName , Value = x.CurrencyCode }).ToList();
            return x;
        }
    }
}
