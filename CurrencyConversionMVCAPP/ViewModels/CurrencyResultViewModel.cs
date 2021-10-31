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
        public double RevResult { get; set; }
        public string ImgSrc { get; set; }
        public string ImgDest { get; set; }
    }
}
