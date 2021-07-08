using NUnit.Framework;
using System;


namespace VismaKindergarten.PomTests
{
   public  class LoginAdminTests : FlytKindergartenBaseTest
    {
               
        
        private string adminLoginUrl = "https://manage.barnehage.testaws.visma.com/SeleniumTestAutomation";
        private string adminUrl = "https://manage.barnehage.testaws.visma.com/children/list";
        private string admin = "Laimonas Samalius";       

        [SetUp]
        public void NavigateToAdminPage()
        {
            WebDriver.Navigate().GoToUrl(adminLoginUrl);
            WebDriver.Manage().Window.Maximize();
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }       

                
        [Test]
        public void LogInAsAdmin()
        {
            

            loginPageAdmin.SelectEmployee(admin);
            var childrenTabPage = loginPageAdmin.ClickLoginBtn();
            Assert.AreEqual(adminUrl, childrenTabPage.CheckUrlAddress());

        }

     }
}
