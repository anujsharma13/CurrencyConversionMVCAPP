using CurrencyConversionMVCAPP.Models;
using CurrencyConversionMVCAPP.Models.Interfaces;
using CurrencyConversionMVCAPP.Repository;
using CurrencyConversionMVCAPP.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CurrencyConversionMVCAPP.Controllers
{
    public class CurrencyController : Controller
    {
        private readonly apicall _client;
        private static string json = CopyJsonData.Convert();
        private static Countries Deserializeobj = JsonToList.Convert(json);
        private IEnumerable<SelectListItem> list = GetNames.get(Deserializeobj);
        public CurrencyController(apicall client)
        {
            _client = client;
        }
        public IActionResult Index()
        {
           
            Currency currency = new Currency()
            {
                Source="",
                Destination="",
                CurrencyNames=list
            };
            return View(currency);
         
        }
        [HttpPost]
        public async Task<IActionResult> Index(Currency _currency)
        {
           
            double result;
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                ApiHelper apiHelper = new ApiHelper();
                 result = await apiHelper.Helper(_currency.Source, _currency.Destination);
            }
            catch(Exception e)
            {
                return View("Error = ", e.Message);
            }
            string CountryCodeSource = GetCountryCodes.Convert(Deserializeobj,_currency.Source).ToLower();
            string CountryCodeDestination = GetCountryCodes.Convert(Deserializeobj, _currency.Destination).ToLower();
            String SrcUrl = $"https://flagcdn.com/48x36/{CountryCodeSource}.png";
            String DestUrl = $"https://flagcdn.com/48x36/{CountryCodeDestination}.png";

            CurrencyResultViewModel model = new CurrencyResultViewModel()
            {
                currency = _currency,
                Result =result*_currency.Amount,
                ImgSrc=SrcUrl,
                ImgDest=DestUrl
            };
            return View("Result", model);
        }
       
      
    }
}
