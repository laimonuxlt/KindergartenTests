using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using VismaKindergarten.Pages;

namespace VismaKindergarten
{
    public class MainGuardianPage : BasePage
    {

        private IWebElement btnLogOut => Driver.FindElement(By.XPath("//*[@class='text'][text() ='Logg ut' or text()= 'Sign out']"));
        private IWebElement loggedGuardian => Driver.FindElement(By.XPath("//kid-app/kid-child-list/div/h1[@class ='page-title'][contains(text(),'Laimonas Samalius')]"));
        public MainGuardianPage(IWebDriver driver) : base(driver)
        {
        }

        public string CheckUrlAddress()
        {
            return Driver.Url;
        }

        public bool IsSignOutBtnDisplayed()
        {

            return btnLogOut.Displayed;
        }

        public bool IsLoggedGuardianDisplayed(string guardian)
        {
            return loggedGuardian.Displayed;
        }

    }
}
