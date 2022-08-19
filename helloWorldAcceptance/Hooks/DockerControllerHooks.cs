using System.Net;
using BoDi;
using Ductus.FluentDocker.Builders;
using Ductus.FluentDocker.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestPlatform.Common.Interfaces;
using TechTalk.SpecFlow;

namespace helloWorldAcceptance.Hooks
{
    [Binding]
    public sealed class DockerControllerHooks
    {
        private static IContainerService _compositeService;
        private IObjectContainer _objectContainer;

 
        public DockerControllerHooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }



        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        [BeforeTestRun]
        public static void DockerUp()
        {
            _compositeService = new Builder()
                .UseContainer()
                .UseImage("helloworldapi:latest")
                .ExposePort(8080, 80)
                .ExposePort(8081, 443)
                .WaitForPort("80/tcp", 30000)
                .Build();

            _compositeService.Start();
        }

        [AfterTestRun]
        public static void DockerDown()
        {
            _compositeService.Stop();
            _compositeService.Dispose();
        }

        [BeforeScenario]
        public void AddHttpClient()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:8080/")
            };
            _objectContainer.RegisterInstanceAs(httpClient);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
        }
    }
}