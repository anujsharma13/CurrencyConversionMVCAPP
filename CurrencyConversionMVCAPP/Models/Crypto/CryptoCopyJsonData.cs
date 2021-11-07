using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CurrencyConversionMVCAPP.Models.Crypto
{
    public class CryptoCopyJsonData
    {
        public static string Convert()
        {
            var webClient = new WebClient();
            var json = webClient.DownloadString(@"C:\Users\Admin\source\repos\CurrencyConversionMVCAPP\CurrencyConversionMVCAPP\CryptoCurrency.json");
            return json;
        }
    }
}
