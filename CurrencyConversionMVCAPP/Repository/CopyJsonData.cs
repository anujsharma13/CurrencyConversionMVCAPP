using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CurrencyConversionMVCAPP.Models
{
    public class CopyJsonData
    {
        public static string Convert()
        {
            var webClient = new WebClient();
            var json = webClient.DownloadString(@"C:\Users\Admin\source\repos\CurrencyConversionMVCAPP\CurrencyConversionMVCAPP\countries.json");
            return json;
        }
    }
}
