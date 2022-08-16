using helloWorldApi.Controllers;
using Microsoft.Extensions.Logging;
using Moq;

namespace helloWorldApiTest
{
    public class HelloWorldApiTest
    {
        

        [Fact]
        public void Test1()
        {
            //mock dependencies for unit tests
            var mockLogger = Mock.Of<ILogger<WeatherForecastController>>();
           
            //instantiate the object
            var controller = new WeatherForecastController(mockLogger);

            //call the method
            var results = controller.Get();
            Assert.NotNull(results);
            Assert.NotEmpty(results);
            Assert.True(results.Count() == 5);

        }
    }
}