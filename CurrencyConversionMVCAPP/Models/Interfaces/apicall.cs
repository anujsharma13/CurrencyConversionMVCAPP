using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConversionMVCAPP.Models.Interfaces
{
   public interface apicall
    {
            [Headers("x-rapidapi-key : 64892e83d5msh2c4dfea8d121897p1f23a7jsnafd1a9f55ca0")]
            [Get("/exchange?to={destination}&from={source}&q=1.0")]
           public Task<double> apidata([Query]string source,[Query] string destination); 
    }
}
