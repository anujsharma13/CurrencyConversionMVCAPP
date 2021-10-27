using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConversionMVCAPP.Models
{
    public static class GetNames
    {
        public static IEnumerable<SelectListItem> get(Countries c)
        {
            var x = c.countries.Select(x => new SelectListItem { Text = x.currencyCode+" - "+x.countryName, Value = x.currencyCode}).ToList();
            return x;
        }
    }
}
