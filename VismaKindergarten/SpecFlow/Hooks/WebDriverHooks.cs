using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace VismaKindergarten.SpecFlow.Hooks
{
    [Binding]
    public sealed class WebDriverHooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        private readonly IObjectContainer _container;
        const string ChromeDriverPath = @"C:\selenium-drivers";

        public WebDriverHooks(IObjectContainer container)
        {
            _container = container;
        }



        [BeforeScenario]
        public void BeforeScenario()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            ChromeDriver webDriver = new ChromeDriver(ChromeDriverPath, chromeOptions);

            _container.RegisterInstanceAs<IWebDriver>(webDriver);

        }

        public ChromeOptions CreateChromeOptions()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--start-maximized");
            chromeOptions.AddArguments("--lang=en-US");
            chromeOptions.AddArguments("--test-type");
            chromeOptions.AddArguments("--disable-popup-blocking");
            chromeOptions.AddArgument("--ignore-certificate-errors");
            return chromeOptions;
        }




        [AfterScenario]
        public void AfterScenario()
        {


            var driver = _container.Resolve<IWebDriver>();
            driver.Quit();




        }
    }
}
