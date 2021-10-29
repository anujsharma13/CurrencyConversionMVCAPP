using CurrencyConversionMVCAPP.Models;
using CurrencyConversionMVCAPP.Models.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConversionMVCAPP.Repository
{
    public class GetNames:IGetNames
    {
        public  IEnumerable<SelectListItem> get(Countries c)
        {
            var x = c.countries.Select(x => new SelectListItem { Text = x.countryName+" - "+ x.currencyCode, Value = x.currencyCode+" "+x.countryCode}).ToList();
            return x;
        }
    }
}
