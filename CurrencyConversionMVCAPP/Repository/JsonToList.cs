using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CurrencyConversionMVCAPP.Models
{
    public  class JsonToList
    {
        public static Countries Convert(string json)
        {
            var countries = JsonConvert.DeserializeObject<Countries>(json);
            
            return countries;
         }
    }
}
