using CurrencyConversionMVCAPP.Models;
using CurrencyConversionMVCAPP.Models.Interfaces;
using CurrencyConversionMVCAPP.Repository;
using CurrencyConversionMVCAPP.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        public IActionResult Output()
        {
            return View("Result");
        }
        [HttpGet]
        public async Task<IActionResult> Result(Currency _currency)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            _currency.Source = _currency.Source.ToUpper();
            _currency.Destination = _currency.Destination.ToUpper();
            string json = copyJsonData.Convert();
            var Deserializeobj = jsonToList.Convert(json);
            var list = getNames.get(Deserializeobj);
            double result=1,revresult=1;
            string source="", Destination="";
            
            try
            {
                 source = _currency.Source.Substring(0, 3).ToUpper();
                 Destination = _currency.Destination.Substring(0, 3).ToUpper();
                // result = await apicall.apidata(source, Destination);
                // revresult = await apicall.apidata(Destination, source);
                result = await helper(source,Destination);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //string CountryCodeDummySource = _currency.Source.Substring(4, 2).ToLower() ;
            //string CountryCodeDummyDestination = _currency.Destination.Substring(4, 2).ToLower();
            CurrencyData SourceCurr = getCountryCodes.Convert(Deserializeobj, source.ToUpper());
            CurrencyData DestCurr = getCountryCodes.Convert(Deserializeobj, Destination.ToUpper());

            string SrcUrl = FlagUrl.GetUrl(SourceCurr.countryCode.ToLower());
            string DestUrl = FlagUrl.GetUrl(DestCurr.countryCode.ToLower());

            //string countrysource = GetCountryNames.Convert(Deserializeobj, CountryCodeDummySource.ToUpper());
            //string countryDest = GetCountryNames.Convert(Deserializeobj, CountryCodeDummyDestination.ToUpper());

            CurrencyResultViewModel model = new CurrencyResultViewModel()
            {
                currency = _currency,
                Amount=_currency.Amount,
                Result = result * _currency.Amount,
                ImgSrc = SrcUrl,
                ImgDest = DestUrl,
                RevResult = revresult*_currency.Amount,
                oneResult=result,
                oneRevResult=revresult,
                SourceCurrencyData = SourceCurr,
                DestinationCurrencyData=DestCurr
            };
            CurrencyCache.Add(model);
            var jsonModel = JsonConvert.SerializeObject(model);
            return Json(jsonModel);
        }
        public IActionResult History()
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            string json = copyJsonData.Convert();
            var Deserializeobj = jsonToList.Convert(json);
            var list = getNames.get(Deserializeobj);
            Currency currency = new Currency()
            {
                Source = "",
                Destination = "",
                CurrencyNames = list
            };
            return View("History", currency);
        }
        public async Task<double> helper(string src,string dest)
        {
            var result = await apicall.apidata(src,dest);
            return result;
        }
    }
}
