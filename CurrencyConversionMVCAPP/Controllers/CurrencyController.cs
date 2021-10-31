using CurrencyConversionMVCAPP.Models;
using CurrencyConversionMVCAPP.Models.Interfaces;
using CurrencyConversionMVCAPP.Repository;
using CurrencyConversionMVCAPP.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Threading.Tasks;

namespace CurrencyConversionMVCAPP.Controllers
{
    public class CurrencyController : Controller
    {
        private readonly IGetCountryCodes getCountryCodes;
        private readonly IGetNames getNames;
        private readonly IJsonToList jsonToList;
        private readonly ICopyJsonData copyJsonData;
        private readonly apicall apicall;

        public CurrencyController(IGetCountryCodes getCountryCodes,IGetNames getNames,IJsonToList jsonToList, ICopyJsonData copyJsonData,apicall apicall)
        {
            this.getCountryCodes = getCountryCodes;
            this.getNames = getNames;
            this.jsonToList = jsonToList;
            this.copyJsonData = copyJsonData;
            this.apicall = apicall;
        }

        public IActionResult Index()
        {
            string json = copyJsonData.Convert();
            var Deserializeobj = jsonToList.Convert(json);
            var list = getNames.get(Deserializeobj);
            Currency currency = new Currency()
            {
                Source="",
                Destination="",
                CurrencyNames=list
            };
            return View("Index",currency);
        }
        [HttpPost]
        public async Task<IActionResult> Index(Currency _currency)
        {
            //string json = copyJsonData.Convert();
            //var Deserializeobj = jsonToList.Convert(json);
            //var list = getNames.get(Deserializeobj);
            double result,revresult;
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                string source = _currency.Source.Substring(0, 3).ToUpper();
                string Destination = _currency.Destination.Substring(0, 3).ToUpper();
                result = await apicall.apidata(source, Destination);
                revresult = await apicall.apidata(Destination, source);
                result = Math.Round(result, 2);
                revresult = Math.Round(revresult, 2);
            }
            catch(Exception e)
            {
                return View("Error = ", e.Message);
            }
            string CountryCodeDummySource = _currency.Source.Substring(4, 2).ToLower() ;
            string CountryCodeDummyDestination = _currency.Destination.Substring(4, 2).ToLower();
            
            String SrcUrl = FlagUrl.GetUrl(CountryCodeDummySource);
            String DestUrl = FlagUrl.GetUrl(CountryCodeDummyDestination);

            CurrencyResultViewModel model = new CurrencyResultViewModel()
            {
                currency = _currency,
                Result = result * _currency.Amount,
                ImgSrc = SrcUrl,
                ImgDest = DestUrl,
                RevResult = revresult
            };
            return View("Result", model);
        }
    }
}
