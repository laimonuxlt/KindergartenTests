using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using VismaKindergarten.Pages;
using VismaKindergarten.Pages.AdminPages;

namespace VismaKindergarten
{
    class ForApprovalTest
    {

        IWebDriver chromeDriver;

        readonly string pathToCromeDriver = @"C:\selenium-drivers";

        readonly string employeeLoginUrl = "https://manage.barnehage.testaws.visma.com/SeleniumTestAutomation";
        readonly string employee = "Laimonas Samalius";

        readonly string childDateOfBirth = "01.01.2020";
        readonly string childName = "Web";
        readonly string childSurname = "Weber";
        readonly string childPostalCode = "7950 ABELVÆR";
        readonly string childStreet = "Winter St 2020";
        readonly string applicantName = "August";
        readonly string applicantSurname = "Augustin";
        readonly string applicantStreet = "Winter St 2020";
        readonly string applicantPostalCode = "7950 ABELVÆR";
        //readonly string applicantEmail = "august@test.com";
        readonly string coapplicantName = "May";
        readonly string coapplicantSurname = "Mayer";
        readonly string coapplicantStreet = "Spring St 2020";
        readonly string coapplicantPostalCode = "7318 AGDENES";

        IWebElement btnLogin => chromeDriver.FindElement(By.XPath("//button[@class='btn green']"));
        IWebElement btnApprove => chromeDriver.FindElement(By.XPath("//kdg-approval-list-details-deviations/div/button[@class='btn green']"));
        IWebElement ddlEmployee => chromeDriver.FindElement(By.XPath("//*[@id='employee']"));
        IWebElement addmitionTab => chromeDriver.FindElement(By.XPath("//a[@data-sel-id = 'menu-admission']"));
        IWebElement forApprovalTab => chromeDriver.FindElement(By.XPath("//a[@data-sel-id = 'menu-admission-approval-list']"));
        IWebElement displayedChildFullName => chromeDriver.FindElement(By.XPath("//kdg-approval-list/div/div[2]/div/div[1]/table/tbody/tr[5]/td[2]"));
        IWebElement childAddress => chromeDriver.FindElement(By.XPath("//kdg-contact-card[2]/div/div[5]/span"));
        IWebElement displayedChildDoB => chromeDriver.FindElement(By.XPath("//kdg-contact-card[2]/div/div[4]/span"));
        IWebElement tabDocumentation => chromeDriver.FindElement(By.XPath("//kdg-approval-list-details/kdg-tab-strip/div/ul/kdg-tab[1]/li/a"));
        IWebElement tabDeviations => chromeDriver.FindElement(By.XPath("//kdg-approval-list-details/kdg-tab-strip/div/ul/kdg-tab[2]/li/a"));
        IWebElement tabNotes => chromeDriver.FindElement(By.XPath("//kdg-approval-list-details/kdg-tab-strip/div/ul/kdg-tab[3]/li/a"));
        IWebElement tabActivityLog => chromeDriver.FindElement(By.XPath("//kdg-approval-list-details/kdg-tab-strip/div/ul/kdg-tab[4]/li/a"));
        IWebElement applicantFullName => chromeDriver.FindElement(By.XPath("//kdg-contact-card[1]/div/div[2]/span"));
        IWebElement applicantAddress => chromeDriver.FindElement(By.XPath("//kdg-contact-card[1]/div/div[5]/span"));
        IWebElement coapplicatFullName => chromeDriver.FindElement(By.XPath("//kdg-contact-card[3]/div/div[2]/span"));
        IWebElement coapplicantAddress => chromeDriver.FindElement(By.XPath("//kdg-contact-card[3]/div/div[5]/span"));
        IWebElement tabDocumentationChilFullName => chromeDriver.FindElement(By.XPath("//kdg-contact-card[2]/div/div[2]/span"));
        IWebElement activityLogTime => chromeDriver.FindElement(By.XPath("//kdg-approval-list-details-activity/div/div/table/tbody/tr[1]/td[1]"));
        IWebElement openedTab => chromeDriver.FindElement(By.XPath("//kdg-approval-list-details/ui-view/kdg-approval-list-details-activity/div/div/table/tbody/tr[1]/td[3]"));
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
        public void IsChildForApprovalDisplayed()
        {

            string childFullName = $"{childName} {childSurname}";
            string displayedChild = displayedChildFullName.Text;
            Console.WriteLine(displayedChild);
            Assert.AreEqual(childFullName, displayedChild);


        }




        [Test]
        public void IsDocumetationTabDataDisplayedCorrecty()
        {
            string expectedApplicantFullName = $"{applicantName} {applicantSurname}";
            Assert.AreEqual(expectedApplicantFullName, applicantFullName.Text);

            string expectedChildFullName = $"{childName} {childSurname}";
            Assert.AreEqual(expectedChildFullName, tabDocumentationChilFullName.Text);

            Assert.AreEqual(childDateOfBirth, displayedChildDoB.Text);

            string expectedCoapplicantFullName = $"{coapplicantName} {coapplicantSurname}";
            Assert.AreEqual(expectedCoapplicantFullName, coapplicatFullName.Text);


            string expectedChildFullAddress = $"{childStreet}, {childPostalCode}";
            string displayedChildAddress = childAddress.Text;
            Assert.That(expectedChildFullAddress, Does.Contain(displayedChildAddress));

            string expectedApplicantFullAddress = $"{applicantStreet}, {applicantPostalCode}";
            string displayedApplicantAddress = applicantAddress.Text;
            Assert.That(expectedApplicantFullAddress, Does.Contain(displayedApplicantAddress));

            string expectedCoapplicantFullAddress = $"{coapplicantStreet}, {coapplicantPostalCode}";
            string displayedCoapplicantAddress = coapplicantAddress.Text;
            Assert.That(expectedCoapplicantFullAddress, Does.Contain(displayedCoapplicantAddress));



        }

        [Test]
        public void IsNotesTabDisplayed()
        {
            bool isTabNotesDisplayed = tabNotes.Displayed;
            Assert.IsTrue(isTabNotesDisplayed);

        }
        [Test]
        public void AreDeviationTabDeviationsResolved()
        {
            bool isTabDeviationsDisplayed = tabDeviations.Displayed;
            Assert.IsTrue(isTabDeviationsDisplayed);

            tabDeviations.Click();
            Thread.Sleep(1000);


            IReadOnlyCollection<IWebElement> icons = chromeDriver.FindElements(By.XPath("//table//button[@class='icon-button'][@title='Godkjenn'][not(@disabled)]"));
            var number = icons.Count;
            Console.WriteLine(number);
            foreach (IWebElement icon in icons)
            {

                var notSolvedDeviation = chromeDriver.FindElement(By.XPath("//table//button[@class='icon-button'][@title='Godkjenn'][not(@disabled)]"));
                notSolvedDeviation.Click();
                Thread.Sleep(1000);

            }
            IReadOnlyCollection<IWebElement> markedIcons = chromeDriver.FindElements(By.XPath("//table//button[@class='icon-button'][@title='Godkjenn'][not(@disabled)]"));
            var markedIconNumber = markedIcons.Count;
            var expectedMarkedIconNumber = 0;
            Assert.AreEqual(expectedMarkedIconNumber, markedIconNumber);


        }

        [Test]
        public void IsActivityLogTabRegisteringEvents()
        {
            tabActivityLog.Click();
            tabDocumentation.Click();



            DateTime dt = DateTime.Now;
            DateTime utcTime = dt.ToUniversalTime();
            TimeZoneInfo timeInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Europe Standard Time");
            DateTime dtConverted = TimeZoneInfo.ConvertTimeFromUtc(utcTime, timeInfo);

            string capturedTime = dtConverted.ToString("dd.MM.yyyy HH:mm");
            Console.WriteLine(capturedTime);
            tabActivityLog.Click();
            string displayedTime = activityLogTime.Text;
            string displayedOpenedTab = openedTab.Text;

            Assert.AreEqual(capturedTime, displayedTime);
            Assert.AreEqual(tabDocumentation.Text, displayedOpenedTab);


        }

        [Test]
        public void ActivityLogTabRegisterEvent()
        {
            var activityLogTabPage = new ActivityLogTabPage(chromeDriver);
            bool data = activityLogTabPage.IsActivityLogTabRegisteringEvents();
            Assert.IsTrue(data);

        }


        [TearDown]
        public void CloseBrowser()
        {
            chromeDriver.Quit();
        }

    }
}

