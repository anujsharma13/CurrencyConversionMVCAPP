using CurrencyConversionMVCAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConversionMVCAPP.ViewModels
{
    public class CurrencyResultViewModel
    {
        public Currency currency { get; set; }
        public double Result { get; set; }
        public double Amount { get; set; }
        public double RevResult { get; set; }
        public double oneResult { get; set; }
        public double oneRevResult { get; set; }
        public string ImgSrc { get; set; }
        public string ImgDest { get; set; }
       public CurrencyData SourceCurrencyData { get; set; }
        public CurrencyData DestinationCurrencyData { get; set; }
    }
}
