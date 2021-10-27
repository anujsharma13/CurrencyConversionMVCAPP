using CurrencyConversionMVCAPP.Models;
using CurrencyConversionMVCAPP.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyTest
{
    [TestClass]
    public class CurrencyTest
    {
        [TestMethod]
        public void Test_JsonToString()
        {
          
           string actual=CopyJsonData.Convert();
            Assert.IsNotNull(actual);
        }

    
        [TestMethod]
        public void Test_GetNames()
        {
            string actual = CopyJsonData.Convert();
            var countries = JsonConvert.DeserializeObject<Countries>(actual);
            var list=GetNames.get(countries);
            Assert.IsNotNull(list);
        }
        [TestMethod]
        public void Test_ApiHelper()
        {
            string source = "";
            string destination = "";
            string data = CopyJsonData.Convert();
            var countries = JsonConvert.DeserializeObject<Countries>(data);
            var list = countries.countries.Select(x => x.currencyCode).ToList();
            Random r = new Random();
            int sourcenumber = r.Next(0, 250); //for ints
            int destinationnumber = r.Next(0, 250);
            source = "INR";
            destination = list[destinationnumber];
            ApiHelper apiHelper = new ApiHelper();
            Task<double> actual = apiHelper.Helper(source, destination);

            var result = actual.Result > 0 ? 1 : 0;
            Assert.AreEqual(result, 1);
        }
    }
}
