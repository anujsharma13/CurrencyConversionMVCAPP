using CurrencyConversionMVCAPP.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConversionMVCAPP.Models
{
    public class Currency
    {
        [Required(ErrorMessage ="This Field is required")]
        [Range(0.1, 9e300)]
      //  [NumberValidation(allowed:"e")]
        public double Amount { get; set; } = 1;
        [Required]
        public string Source { get; set; }
        [Required]
        public string Destination { get; set; }
        public IEnumerable<SelectListItem> CurrencyNames { get; set; }  
        
    }
}   
