using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConversionMVCAPP.Models.Crypto
{
    public class CryptoCurrencyData
    {
       public string Source { get; set; }
       public string Destination { get; set; }
       public IEnumerable<SelectListItem> CurrencyNames { get; set; }
    }
}
