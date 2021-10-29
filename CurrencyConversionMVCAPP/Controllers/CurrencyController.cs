using CurrencyConversionMVCAPP.Models;
using CurrencyConversionMVCAPP.Models.Interfaces;
using CurrencyConversionMVCAPP.Repository;
using CurrencyConversionMVCAPP.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CurrencyConversionMVCAPP.Controllers
{
    public class CurrencyController : Controller
    {
        private IGetCountryCodes getCountry;
        private readonly IGetNames getNames;
        private readonly IJsonToList jsonToList;
        private readonly ICopyJsonData copyJsonData;
        private readonly apicall apicall;

        public CurrencyController(IGetCountryCodes getCountryCodes,IGetNames getNames,IJsonToList jsonToList, ICopyJsonData copyJsonData,apicall apicall)
        {
            this.getCountry = getCountryCodes;
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
            return View(currency);
         
        }
        [HttpPost]
        public async Task<IActionResult> Index(Currency _currency)
        {
            string json = copyJsonData.Convert();
            var Deserializeobj = jsonToList.Convert(json);
            var list = getNames.get(Deserializeobj);
            double result;
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                string source = _currency.Source.Substring(0, 3);
                string Destination = _currency.Destination.Substring(0, 3);
                result = await Helper(_currency.Source, _currency.Destination);
            }
            catch(Exception e)
            {
                return View("Error = ", e.Message);
            }
            string CountryCodeDummySource = _currency.Source.Substring(4, 2).ToLower() ;
            string CountryCodeDummyDestination = _currency.Destination.Substring(4, 2).ToLower();
            //string CountryCodeSource = getCountry.Convert(Deserializeobj, CountryCodeDummySource);
            //string CountryCodeDestination = getCountry.Convert(Deserializeobj, CountryCodeDummyDestination);
            String SrcUrl = FlagUrl.GetUrl(CountryCodeDummySource);
            String DestUrl = FlagUrl.GetUrl(CountryCodeDummyDestination);

            CurrencyResultViewModel model = new CurrencyResultViewModel()
            {
                currency = _currency,
                Result =result*_currency.Amount,
                ImgSrc=SrcUrl,
                ImgDest=DestUrl
            };
            return View("Result", model);
        }

        public async Task<double> Helper(string source, string destination)
        {
            double result;
            try
            {
              result=await apicall.apidata(source, destination);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return result;
        }
    }
}
