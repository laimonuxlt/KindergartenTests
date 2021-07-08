using NUnit.Framework;
using System;

namespace VismaKindergarten.PomTests
{
    public class LoginGuardianTests : FlytKindergartenBaseTest
    {

        
        private string guardianLoginUrl = "https://barnehage.testaws.visma.com/SeleniumTestAutomation";
        private string guardian = "Laimonas Samalius";
        //private string guardianUrl = "https://barnehage.testaws.visma.com/children/list";
        readonly string warnGuardianIsRequired = "Feltet må fylles inn.";


        [SetUp]
        public void NavigateToGuardianURL()
        {
            WebDriver.Navigate().GoToUrl(guardianLoginUrl);
            WebDriver.Manage().Window.Maximize();
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }

        [Test]
        public void LogInAsGuardian()
        {
            loginPageGuardian.SelectGuardian(guardian);
            
            var guardianPage = loginPageGuardian.ClickLoginBtn();
            var signOutBtnDisplayed = guardianPage.IsSignOutBtnDisplayed();

            Assert.IsTrue(signOutBtnDisplayed);

        }
        [Test]
        public void LogInWithoutSelectingGuardian()
        {
            loginPageGuardian.ClickLoginBtn();
            string displayedWarningText = loginPageGuardian.ReadWarningText();
           
            Assert.AreEqual(warnGuardianIsRequired, displayedWarningText);
            // Assert.IsFalse(signOutBtnDisplayed);


        }
    }
}
