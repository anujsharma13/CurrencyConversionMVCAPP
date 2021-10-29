using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConversionMVCAPP.Models.Interfaces
{
   public interface IJsonToList
    {
        public Countries Convert(string json);
        }
}
