//using CurrencyConversionMVCAPP.Models.Crypto;
//using CurrencyConversionMVCAPP.Models.Interfaces;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace CurrencyConversionMVCAPP.Controllers
//{
//    public class CryptoController : Controller
//    { 
//        private readonly ICryptoApiCall apicall;
//        public  CryptoController(ICryptoApiCall apicall)
//        {
//            this.apicall = apicall;
//        }

//        public IActionResult Index()
//        {
//            string json = CryptoCopyJsonData.Convert();
//            var Deserializeobj = CryptoJsonToList.Convert(json);
//            var list = CrypoGetNames.get(Deserializeobj);
//            CryptoCurrencyData currency = new CryptoCurrencyData()
//            {
//                Source = "",
//                Destination = "",
//                CurrencyNames = list
//            };
//            return View("Index", currency);
//        }
//        [HttpPost]
//        public async Task<IActionResult> Result(CryptoCurrencyData _currency)
//        {
//            _currency.Source = _currency.Source.ToUpper();
//            _currency.Destination = _currency.Destination.ToUpper();
//            string json = CryptoCopyJsonData.Convert();
//            var Deserializeobj = CryptoJsonToList.Convert(json);
//            var list = CrypoGetNames.get(Deserializeobj);

//            string source = _currency.Source, Destination =_currency.Destination;

//            try
//            {
              
//                JsonResult obj = await apicall.apidata(source, Destination);
                
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//            }
//            ////string CountryCodeDummySource = _currency.Source.Substring(4, 2).ToLower() ;
//            ////string CountryCodeDummyDestination = _currency.Destination.Substring(4, 2).ToLower();
//            //CurrencyData SourceCurr = getCountryCodes.Convert(Deserializeobj, source.ToUpper());
//            //CurrencyData DestCurr = getCountryCodes.Convert(Deserializeobj, Destination.ToUpper());

//            //string SrcUrl = FlagUrl.GetUrl(SourceCurr.countryCode.ToLower());
//            //string DestUrl = FlagUrl.GetUrl(DestCurr.countryCode.ToLower());

//            ////string countrysource = GetCountryNames.Convert(Deserializeobj, CountryCodeDummySource.ToUpper());
//            ////string countryDest = GetCountryNames.Convert(Deserializeobj, CountryCodeDummyDestination.ToUpper());

//            //CurrencyResultViewModel model = new CurrencyResultViewModel()
//            //{
//            //    currency = _currency,
//            //    Result = result * _currency.Amount,
//            //    ImgSrc = SrcUrl,
//            //    ImgDest = DestUrl,
//            //    RevResult = revresult * _currency.Amount,
//            //    oneResult = result,
//            //    oneRevResult = revresult,
//            //    SourceCurrencyData = SourceCurr,
//            //    DestinationCurrencyData = DestCurr
//            //};
//            //var jsonModel = JsonConvert.SerializeObject(model);
//            //return Json(jsonModel);
//            return View();
//        }
//    }
//}
