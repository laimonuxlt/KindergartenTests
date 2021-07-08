using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using VismaKindergarten.Pages;

namespace VismaKindergarten
{
    public class LoginGuardianPage : BasePage
    {

        public LoginGuardianPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement btnLoginGuard => Driver.FindElement(By.XPath("//button[@title='Sign in'  or @title='Logg inn']"));

        private IWebElement ddlGuardian => Driver.FindElement(By.XPath("//select[@id='employee']"));

        //private IWebElement btnLogin => _driver.FindElement(By.XPath("//button[@class='btn green']"));
        private IWebElement warning => Driver.FindElement(By.XPath("//kid-validation-message/span"));


        public void SelectGuardian(string guardian)
        {

            SelectElement ddlSelection = new SelectElement(ddlGuardian);
            ddlSelection.SelectByText(guardian);

        }

        

        public MainGuardianPage ClickLoginBtn()
        {

            btnLoginGuard.Click();
            Thread.Sleep(1000);

            //WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            //wait.Until(Driver => Driver.FindElement(By.XPath("//*[@class='text'][text() ='Logg ut' or text()= 'Sign out']")).Displayed);

            return new MainGuardianPage(Driver);

        }



        public string ReadWarningText()
        {
            string warningText = warning.Text;
            return warningText;
        }

    }
}
