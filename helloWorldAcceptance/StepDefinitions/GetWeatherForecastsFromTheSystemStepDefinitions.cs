using System;
using System.Net.Http.Json;
using helloWorldAcceptance.NewFolder;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace helloWorldAcceptance.StepDefinitions
{
    [Binding]
    public class GetWeatherForecastsFromTheSystemStepDefinitions
    {
        private readonly HttpClient _httpClient;
        private readonly ScenarioContext _scenarioContext;

        public GetWeatherForecastsFromTheSystemStepDefinitions(HttpClient httpClient, ScenarioContext context)
        {
            _httpClient = httpClient;
            _scenarioContext = context;
        }

        [When(@"I ask for weather forecasts from the system")]
        public async Task WhenIAskForWeatherForecastsFromTheSystem()
        {
            var response = await _httpClient.GetAsync("WeatherForecast");
            var results = await response.Content.ReadFromJsonAsync<List<WeatherForecast>>();
            _scenarioContext.Add("results", results);
        }

        [Then(@"I receive (.*) weather forecasts from the system")]
        public void ThenIReceiveWeatherForecastsFromTheSystem(int p0)
        {
            var results = _scenarioContext.Get<List<WeatherForecast>>("results");
            Assert.IsNotEmpty(results);
            Assert.IsTrue(results.Count == p0);
        }
    }
}
