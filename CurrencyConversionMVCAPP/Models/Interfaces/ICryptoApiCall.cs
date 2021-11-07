using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConversionMVCAPP.Models.Interfaces
{
  public  interface ICryptoApiCall
    {
        
        [Get("/query?function=CURRENCY_EXCHANGE_RATE&from_currency={source}&to_currency={destination}&apikey=9JO5LJWEMAA43SRO")]
        public Task<JsonResult> apidata([Query] string source, [Query] string destination);
    }
}
