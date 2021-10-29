using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConversionMVCAPP.Models.Interfaces
{
   public interface IGetNames
    {
        public IEnumerable<SelectListItem> get(Countries c);
        }
}
