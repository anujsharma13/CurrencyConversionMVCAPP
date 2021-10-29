using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConversionMVCAPP.Repository
{
    public class FlagUrl
    {
        public static string GetUrl(string CountryCode)
        {
            return $"https://flagcdn.com/48x36/{CountryCode}.png";
        }
    }
}
