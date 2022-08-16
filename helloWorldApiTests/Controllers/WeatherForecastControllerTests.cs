using Microsoft.VisualStudio.TestTools.UnitTesting;
using helloWorldApi.Controllers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace helloWorldApi.Controllers.Tests
{
    [TestClass()]
    public class WeatherForecastControllerTests
    {
        [TestMethod()]
        public void WeatherForecastControllerTest()
        {
            var mockLogger = NSubstitute.Substitute.For<ILogger<WeatherForecastController>>();
            var controller = new WeatherForecastController(mockLogger);
            Assert.IsNotNull(controller);
        }

        [TestMethod()]
        public void GetTest()
        {
            var mockLogger = NSubstitute.Substitute.For<ILogger<WeatherForecastController>>();
            var controller = new WeatherForecastController(mockLogger);
            var results = controller.Get();
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count() > 0);
            Assert.IsTrue(results.Count() == 5);
        }
    }
}