using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace VismaKindergarten
{
    public class Tests
    {
        IWebDriver chromeDriver;

        readonly string guardianLoginUrl = "https://barnehage.testaws.visma.com/SeleniumTestAutomation";
        readonly string employeeLoginUrl = "https://manage.barnehage.testaws.visma.com/SeleniumTestAutomation";
        readonly string guardian = "Laimonas Samalius";
        readonly string employee = "Laimonas Samalius";
        readonly string wrnGuardianIsRequired = "Feltet må fylles inn.";

        IWebElement btnLoginGuard => chromeDriver.FindElement(By.XPath("//button[@title='Sign in'  or @title='Logg inn']"));

        IWebElement ddlGuardian => chromeDriver.FindElement(By.XPath("//select[@id='employee']"));

        IWebElement warning => chromeDriver.FindElement(By.XPath("//kid-validation-message/span"));

        IWebElement ddlEmployee => chromeDriver.FindElement(By.XPath("//*[@id='employee']"));

        IWebElement btnLogin => chromeDriver.FindElement(By.XPath("//button[@class='btn green']"));

        [SetUp]
        public void Setup()
        {
            chromeDriver = new ChromeDriver(@"C:\selenium-drivers");

        }

        [Test]
        public void LogInAsGuardian()

        {

            chromeDriver.Navigate().GoToUrl(guardianLoginUrl);

            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);            

            SelectElement ddlSelection = new SelectElement(ddlGuardian);

            ddlSelection.SelectByText(guardian);            


            btnLoginGuard.Click();

            Thread.Sleep(1000);

            string actualUrl = chromeDriver.Url;

            string expectedUrl = "https://barnehage.testaws.visma.com/children/list";


            Assert.AreEqual(expectedUrl, actualUrl);


        }
        [Test]
        public void LogInWithoutSelectingGuardian()
        {

            chromeDriver.Navigate().GoToUrl(guardianLoginUrl);

            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);            

            btnLoginGuard.Click();            

            string displayedWarningText = warning.Text;

            Assert.AreEqual(wrnGuardianIsRequired, displayedWarningText);

        }



        [Test]
        public void LoginSelectedEmployee()
        {

            chromeDriver.Navigate().GoToUrl(employeeLoginUrl);

            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            

            SelectElement ddlSelection = new SelectElement(ddlEmployee);

            ddlSelection.SelectByText(employee);
            


            btnLogin.Click();

            Thread.Sleep(1000);

            string actualUrl = chromeDriver.Url;

            string expectedUrl = "https://manage.barnehage.testaws.visma.com/children/list";

            Assert.AreEqual(expectedUrl, actualUrl);
        }


        [Test]
        public void CreateApplication()
        {
            chromeDriver.Navigate().GoToUrl(employeeLoginUrl);

            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            

            SelectElement ddlSelection = new SelectElement(ddlEmployee);

            ddlSelection.SelectByText(employee);
          

            btnLogin.Click();

            Thread.Sleep(1000);

            chromeDriver.Navigate().GoToUrl("https://manage.barnehage.testaws.visma.com/admission/application");




        }

        [TearDown]
        public void CloseBrowser()
        {
            chromeDriver.Quit();
        }


    }


}