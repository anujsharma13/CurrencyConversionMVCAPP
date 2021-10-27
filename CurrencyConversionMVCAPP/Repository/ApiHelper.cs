using CurrencyConversionMVCAPP.Models;
using CurrencyConversionMVCAPP.Models.Interfaces;
using Refit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConversionMVCAPP.Repository
{
    public class ApiHelper
    {
       

        public double result;
        public async Task<double> Helper(string source,string destination)
            {
          
            double body;
           
                try
                {
                    var call = RestService.For<apicall>("https://currency-exchange.p.rapidapi.com");
                    body = await call.apidata(source, destination);

                }
                catch (Exception w)
                {
                    throw new InvalidOperationException(w.Message);
                }
            return body;
            }
    }
}
