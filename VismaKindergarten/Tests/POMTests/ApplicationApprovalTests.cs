using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace VismaKindergarten.PomTests
{
    public class ApplicationApprovalTests : FlytKindergartenBaseTest
    {
        private string employeeLoginUrl = "https://manage.barnehage.testaws.visma.com/SeleniumTestAutomation";
        private string employee = "Laimonas Samalius";

        private string childDateOfBirth = "01.01.2020";
        private string childName = "Web";
        private string childSurname = "Weber";
        private string childPostalCode = "7950 ABELVÆR";
        private string childStreet = "Winter St 2020";
        private string applicantName = "August";
        private string applicantSurname = "Augustin";
        private string applicantStreet = "Winter St 2020";
        private string applicantPostalCode = "7950 ABELVÆR";
        //private string applicantEmail = "august@test.com";
        private string coApplicantName = "May";
        private string coApplicantSurname = "Mayer";
        private string coApplicantStreet = "Spring St 2020";
        private string coApplicantPostalCode = "7318 AGDENES";

        private IWebElement btnLogin => WebDriver.FindElement(By.XPath("//button[@class='btn green']"));
        
        private IWebElement ddlEmployee => WebDriver.FindElement(By.XPath("//*[@id='employee']"));
        private IWebElement addmitionTab => WebDriver.FindElement(By.XPath("//a[@data-sel-id = 'menu-admission']"));
        private IWebElement forApprovalTab => WebDriver.FindElement(By.XPath("//a[@data-sel-id = 'menu-admission-approval-list']"));
        private IWebElement displayedChildFullName => WebDriver.FindElement(By.XPath("//kdg-approval-list/div/div[2]/div/div[1]/table/tbody/tr[5]/td[2]"));
        //private IWebElement btnApprove => _driver.FindElement(By.XPath("//kdg-approval-list-details-deviations/div/button[@class='btn green']"));
        
        //private IWebElement closePopUp => _driver.FindElement(By.XPath("//*[@title='Close Survey']"));
        //private IWebElement tabDocumentation => _driver.FindElement(By.XPath("//kdg-approval-list-details/kdg-tab-strip/div/ul/kdg-tab[1]/li/a"));
        //private IWebElement tabDeviations => _driver.FindElement(By.XPath("//kdg-approval-list-details/kdg-tab-strip/div/ul/kdg-tab[2]/li/a"));
        //private IWebElement tabNotes => _driver.FindElement(By.XPath("//kdg-approval-list-details/kdg-tab-strip/div/ul/kdg-tab[3]/li/a"));
        //private IWebElement tabActivityLog => _driver.FindElement(By.XPath("//kdg-approval-list-details/kdg-tab-strip/div/ul/kdg-tab[4]/li/a"));
        //private IWebElement applicantAddress => _driver.FindElement(By.XPath("//kdg-contact-card[1]/div/div[5]/span"));
        //private IWebElement tabDocumentationChilFullName => _driver.FindElement(By.XPath("//kdg-contact-card[2]/div/div[2]/span"));
        //private IWebElement activityLogTime => _driver.FindElement(By.XPath("//kdg-approval-list-details-activity/div/div/table/tbody/tr[1]/td[1]"));
        //private IWebElement openedTab => _driver.FindElement(By.XPath("//kdg-approval-list-details/ui-view/kdg-approval-list-details-activity/div/div/table/tbody/tr[1]/td[3]"));

        [SetUp]
        public void Setup()
        {
            WebDriver.Navigate().GoToUrl(employeeLoginUrl);
            WebDriver.Manage().Window.Maximize();           
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            SelectElement ddlSelection = new SelectElement(ddlEmployee);
            ddlSelection.SelectByText(employee);

            btnLogin.Click();            
            addmitionTab.Click();           
            forApprovalTab.Click();
            

            Actions action = new Actions(WebDriver);
            action.DoubleClick(displayedChildFullName).Perform();
          
        }

        [Test]
        public void IsDocumentationTabDataDisplayedCorrecty()
        {

            string expectedApplicantFullName = $"{applicantName} {applicantSurname}";
            string retrievedApplicantFullName = documentationTabPage.ReadApplicantFullName();
            Assert.AreEqual(expectedApplicantFullName, retrievedApplicantFullName);

            string expectedApplicantFullAddress = $"{applicantStreet}, {applicantPostalCode}";
            string displayedApplicantAddress = documentationTabPage.ReadApplicantAddress();
            Assert.That(expectedApplicantFullAddress, Does.Contain(displayedApplicantAddress));

            
            string expectedChildFullName = $"{childName} {childSurname}";
            string retrievedChildFullName = documentationTabPage.ReadChildFullName();
            Assert.AreEqual(expectedChildFullName, retrievedChildFullName);

            string retrievedChildDoB = documentationTabPage.ReadChildDoB();
            Assert.AreEqual(childDateOfBirth, retrievedChildDoB);

            string expectedCoApplicantFullName = $"{coApplicantName} {coApplicantSurname}";
            string retrievedCoAplicantFullName = documentationTabPage.ReadCoApplicantFullName();
            Assert.AreEqual(expectedCoApplicantFullName, retrievedCoAplicantFullName);

            string expectedChildFullAddress = $"{childStreet}, {childPostalCode}";
            string retrievedChildAddress = documentationTabPage.ReadChildAddress();
            Assert.That(expectedChildFullAddress, Does.Contain(retrievedChildAddress));

            string expectedCoApplicantFullAddress = $"{coApplicantStreet}, {coApplicantPostalCode}";
            string displayedCoApplicantAddress = documentationTabPage.ReadCoApplicantAddress();
            Assert.That(expectedCoApplicantFullAddress, Does.Contain(displayedCoApplicantAddress));

        }

        [Test]
        public void SolveDeviations()
        {
            int deviationNumber = 0;
            deviationsTabPage.ResolveDeviations();
            int activeDeviationNumber = deviationsTabPage.DeviationNumberCount();
            Assert.AreEqual(deviationNumber, activeDeviationNumber);

        }

        [Test]
        public void ActivityLogTabRegisterEvent()
        {

            bool data = activityLogTabPage.IsActivityLogTabRegisteringEvents();
            Assert.IsTrue(data);

        }
    }
}