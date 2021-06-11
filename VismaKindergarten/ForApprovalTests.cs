using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace VismaKindergarten
{
    class ForApprovalTest
    {

        IWebDriver chromeDriver;

        string pathToCromeDriver = @"C:\selenium-drivers";

        readonly string employeeLoginUrl = "https://manage.barnehage.testaws.visma.com/SeleniumTestAutomation";
        readonly string employee = "Laimonas Samalius";

        readonly string dateOfBirth = "01/01/2020";
        readonly string childName = "Jan";
        readonly string childSurname = "Januar";
        readonly string childPostalCode = "7950 ABELVÆR";
        readonly string childStreet = "Winter St 2020";
        readonly string fatherName = "August";
        readonly string fatherSurname = "Augustin";
        readonly string fatherStreet = "Summer St 2020";
        readonly string fatherPostalCode = "7950 ABELVÆR";
        readonly string motherName = "May";
        readonly string motherSurname = "Mayer";
        readonly string motherStreet = "Spring St  2020";
        readonly string motherPostalCode = "7318 AGDENES";

        IWebElement btnLogin => chromeDriver.FindElement(By.XPath("//button[@class='btn green']"));
        IWebElement ddlEmployee => chromeDriver.FindElement(By.XPath("//*[@id='employee']"));
        IWebElement addmitionTab => chromeDriver.FindElement(By.XPath("//a[@data-sel-id = 'menu-admission']"));
        IWebElement forApprovalTab => chromeDriver.FindElement(By.XPath("//a[@data-sel-id = 'menu-admission-approval-list']"));
        IWebElement displayedChildFullName => chromeDriver.FindElement(By.XPath("//kdg-approval-list/div/div[2]/div/div[1]/table/tbody/tr[2]/td[2]"));
        IWebElement tabDocumentation => chromeDriver.FindElement(By.XPath("//a[text()= 'Documentation' or text()= 'Dokumentasjon']"));

        IWebElement applicantName => chromeDriver.FindElement(By.XPath("//span[text()='August Augustin']"));
        IWebElement appplicantAddress => chromeDriver.FindElement(By.XPath("//span[contains(text(), 'Summer St 2020')]"));

        [SetUp]
        public void Setup()
        {
            chromeDriver = new ChromeDriver(pathToCromeDriver);

            chromeDriver.Navigate().GoToUrl(employeeLoginUrl);

            chromeDriver.Manage().Window.Maximize();

            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);


            SelectElement ddlSelection = new SelectElement(ddlEmployee);

            ddlSelection.SelectByText(employee);


            btnLogin.Click();

            addmitionTab.Click();

            forApprovalTab.Click();

            Actions action = new Actions(chromeDriver);
            action.DoubleClick(displayedChildFullName).Perform();

        }

        [Test]
        public void DisplayChildForApproval()
        {

            string childFullName = $"{childName} {childSurname}";

            string displayedChild = displayedChildFullName.Text;
            Console.WriteLine(displayedChild);
            Assert.AreEqual(childFullName, displayedChild);

        }

        [Test]
        public void DisplayAprovalPage()
        {

            bool isTabDocumentationDisplayed = tabDocumentation.Displayed;
            Assert.IsTrue(isTabDocumentationDisplayed);

        }
        [Test]
        public void ApplicantNameDisplayed()
        {
            string applicantFullName = $"{fatherName} {fatherSurname}";
            string displayedApplicantName = applicantName.Text;
            Assert.AreEqual(applicantFullName, displayedApplicantName);


        }

        [Test]
        public void ApplicantAddressDispalyed()
        {
            string applicantFullAddress = $"{fatherStreet}, {fatherPostalCode}";
            string displayedAddress = appplicantAddress.Text;
            Assert.That(displayedAddress, Does.Contain(applicantFullAddress));

        }


        [TearDown]
        public void CloseBrowser()
        {
            chromeDriver.Quit();
        }

    }
}

