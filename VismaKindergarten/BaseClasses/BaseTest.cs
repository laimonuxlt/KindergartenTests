using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace VismaKindergarten.Pages
{

    public abstract class BaseTest
    {
        public IWebDriver WebDriver;
        const string ChromeDriverPath = @"C:\selenium-drivers";

        

        [SetUp, Order(1)]
        public void CreateDriver()

        {
            ChromeOptions chromeOptions = new ChromeOptions();
            WebDriver = new ChromeDriver(ChromeDriverPath, chromeOptions);
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


       [TearDown]
        public void CloseBrowser()
        {
            WebDriver.Quit();
           
        }
    }

}
