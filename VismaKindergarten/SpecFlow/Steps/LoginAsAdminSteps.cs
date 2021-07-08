using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace VismaKindergarten.SpecFlow.Steps
{
    [Binding]
    public class LoginAsAdminSteps
    {
        private readonly IWebDriver _driver;
        private readonly LoginAdminPage _loginPageAdmin;
        private readonly ChildrenTabPage _childrenTabPage;

        public LoginAsAdminSteps(IWebDriver driver)
        {
            _driver = driver;
            _loginPageAdmin = new LoginAdminPage(driver);
            _childrenTabPage = new ChildrenTabPage(driver);


        }


        [Given(@"login page  (.*) is displayed")]
        public void GivenLoginPageIsDisplayed(string p0)
        {
            _driver.Navigate().GoToUrl(p0);
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }
        
        [When(@"the user selects the (.*) as admin")]
        public void WhenTheUserSelectsTheAsAdmin(string p0)
        {
            _loginPageAdmin.SelectEmployee(p0);
        }
        
        [When(@"the user clicks on login button")]
        public void WhenTheUserClicksOnLoginButton()
        {
            _loginPageAdmin.ClickLoginBtn();
        }
        
        [Then(@"the admin page (.*) is displayed")]
        public void ThenTheAdminPageIsDisplayed(string p0)
        {
            var expectedUrl = _childrenTabPage.CheckUrlAddress();
            var displayedUrl = _childrenTabPage.CheckUrlAddress();
            Assert.AreEqual(expectedUrl, displayedUrl);
        }
    }
}
