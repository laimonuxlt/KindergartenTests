using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace VismaKindergarten.Pages
{
    public class ActivityLogTabPage : BasePage
    {

        private IWebElement activityLogTime => Driver.FindElement(By.XPath("//kdg-approval-list-details-activity/div/div/table/tbody/tr[1]/td[1]"));
        private IWebElement tabActivityLog => Driver.FindElement(By.XPath("//kdg-approval-list-details/kdg-tab-strip/div/ul/kdg-tab[4]/li/a"));
        private IWebElement tabDocumentation => Driver.FindElement(By.XPath("//kdg-approval-list-details/kdg-tab-strip/div/ul/kdg-tab[1]/li/a"));
        //private IWebElement openedTab => Driver.FindElement(By.XPath("//kdg-approval-list-details/ui-view/kdg-approval-list-details-activity/div/div/table/tbody/tr[1]/td[3]"));
       
        public ActivityLogTabPage(IWebDriver driver) :base (driver)
        {

        }

        public bool IsActivityLogTabRegisteringEvents()
        {

            tabActivityLog.Click();
            //Thread.Sleep(1000);
            //Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            tabDocumentation.Click();
            //Thread.Sleep(1000);
            //Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            DateTime dt = DateTime.Now;
            DateTime utcTime = dt.ToUniversalTime();
            TimeZoneInfo timeInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Europe Standard Time");
            DateTime dtConverted = TimeZoneInfo.ConvertTimeFromUtc(utcTime, timeInfo);
            string capturedTime = dtConverted.ToString("dd.MM.yyyy HH:mm");
            Console.WriteLine(capturedTime);

            tabActivityLog.Click();
            //Thread.Sleep(1000);
            //Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            string displayedTime = activityLogTime.Text; 
            bool isDataDisplayed = String.Equals(capturedTime, displayedTime);
            return isDataDisplayed;

        }
    }
}
