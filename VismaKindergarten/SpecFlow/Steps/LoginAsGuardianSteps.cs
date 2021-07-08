using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using VismaKindergarten.Pages;
using BoDi;

namespace VismaKindergarten.PomTests
{
    [Binding]
    public class LoginAsGuardianSteps
    {

        //private string guardianLoginUrl = "https://barnehage.testaws.visma.com/SeleniumTestAutomation";
        //private string guardian = "Laimonas Samalius";
        private readonly IWebDriver _driver;
        private readonly LoginGuardianPage _loginPageGuardian;
        private readonly MainGuardianPage _mainGuardianPage;
        //private FeatureContext _context;

        public LoginAsGuardianSteps(IWebDriver driver)
        {
            _driver = driver;
            _loginPageGuardian = new LoginGuardianPage(driver);
            _mainGuardianPage = new MainGuardianPage(driver);
            //_context = contex;
        }


        [Given(@"Log in page '(.*)' is displayed")]
        public void GivenLogInPageGuardianIsDisplayed(string p0)
        {
            _driver.Navigate().GoToUrl(p0);
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }


        //[Given(@"Log in page for guardian is displayed")]
        //public void GivenLogInPageForGuardianIsDisplayed()
        //{

        //    _driver.Navigate().GoToUrl(guardianLoginUrl);
        //    _driver.Manage().Window.Maximize();
        //    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        //}

        //[When(@"the user selects the guardian")]
        //public void WhenTheUserSelectsTheGuardian()
        //{

        //    _loginPageGuardian.SelectGuardian(guardian);
        //    //_context.Add("guardianName", guardian);

        //}



        [When(@"the user selects '(.*)'  as guardian")]
        public void WhenTheUserSelectsAsGuardian(string p0)
        {
            _loginPageGuardian.SelectGuardian(p0);
        }



        [When(@"the user clicks log in button")]
        public void WhenTheUserClicksLogInButton()
        {

            _loginPageGuardian.ClickLoginBtn();
        }



        [Then(@"the guardian site main page is displayed")]
        public void ThenTheGuardianSiteMainPageIsDisplayed()
        {


            var signOutBtnDisplayed = _mainGuardianPage.IsSignOutBtnDisplayed();
            Assert.IsTrue(signOutBtnDisplayed);


        }


        [Then(@"the logged guardian name '(.*)' is displayed")]
        public void ThenTheLoggedGuardianNameIsDisplayed(string p0)
        {
            var mainGuardianDispalyed = _mainGuardianPage.IsLoggedGuardianDisplayed(p0);
            Assert.IsTrue(mainGuardianDispalyed);

        }



    }
}
