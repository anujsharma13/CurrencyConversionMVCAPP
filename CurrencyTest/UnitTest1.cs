using CurrencyConversionMVCAPP.Controllers;
using CurrencyConversionMVCAPP.Models;
using CurrencyConversionMVCAPP.Models.Interfaces;
using CurrencyConversionMVCAPP.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
        private readonly CurrencyController controller;
        private readonly Mock<IGetCountryCodes> getCountry;
        private readonly Mock<IGetNames> getNames;
        private readonly Mock<IJsonToList> jsonToList;
        private readonly Mock<ICopyJsonData> copyJsonData;
        private readonly Mock<apicall> apicall;
        public CurrencyTest()
        {
            getCountry = new Mock<IGetCountryCodes>();
            getNames = new Mock<IGetNames>();
            jsonToList = new Mock<IJsonToList>();
            copyJsonData = new Mock<ICopyJsonData>();
            apicall = new Mock<apicall>();
            controller = new CurrencyController(getCountry.Object, getNames.Object, jsonToList.Object, copyJsonData.Object, apicall.Object); ;
        }
        [TestMethod]
        public void Index_GetViewModel()
        {
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName,ignoreCase:true);
        }
        [TestMethod]
        public async void Index_ModelStateIsInvalid()
        {
            controller.ModelState.AddModelError("Test", "Test");
          //  var result = await controller.Result(Mock.Of<Currency>()) as ViewResult;
          //  Assert.AreEqual("Index", result.ViewName, ignoreCase: true );
        }
        [TestMethod]
        public async Task ApiCall()
        {
            double currency = 75;
            apicall.Setup(x => x.apidata("inr", "usd")).ReturnsAsync(currency);
            //var result = await controller.Helper("inr", "usd");
            //Assert.AreEqual(result, currency);
        }
        [TestMethod]
        public void Test_JsonToString()
        {

            string actual = copyJsonData.Object.Convert();
            Assert.IsNotNull(actual);
        }

    
        [TestMethod]
        public void Test_GetNames()
        {
            string json = copyJsonData.Object.Convert();
            var Deserializeobj = jsonToList.Object.Convert(json);
            var list=getNames.Object.get(Deserializeobj);
            Assert.IsNotNull(list);
        }
    }
}
