using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConversionMVCAPP.Models.Crypto
{
    public class CryptoJsonToList
    {
        public static CryptoCurrency Convert(string json)
        {
            var cryptodata = JsonConvert.DeserializeObject<CryptoCurrency>(json);

            return cryptodata;
        }
    }
}
