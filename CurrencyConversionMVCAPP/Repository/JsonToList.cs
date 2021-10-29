using CurrencyConversionMVCAPP.Models;
using CurrencyConversionMVCAPP.Models.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;


namespace CurrencyConversionMVCAPP.Repository
{
    public  class JsonToList:IJsonToList
    {
        public Countries Convert(string json)
        {
            var countries = JsonConvert.DeserializeObject<Countries>(json);
            
            return countries;
         }
    }
}
