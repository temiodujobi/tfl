using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace UIAutomationTests.Hooks
{
    [Binding]
    public sealed class BrowserContext
    {
        public IWebDriver Driver;

        public void LaunchApplication()
        {
            var baseUrl = Configuration().GetSection("BaseUrl").Value;
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(baseUrl);
        }

        public void ShutDownApplication()
        {
            Driver?.Dispose();
        }

        private IConfigurationRoot Configuration()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            return configuration;
        }
    }
}
