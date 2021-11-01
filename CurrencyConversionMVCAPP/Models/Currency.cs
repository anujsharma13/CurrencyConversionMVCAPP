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
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Only positive number allowed")]
        public double Amount { get; set; } = 1;
        [Required]
        public string Source { get; set; }
        [Required]
        public string Destination { get; set; }
        public IEnumerable<SelectListItem> CurrencyNames { get; set; }
     
    }
}
