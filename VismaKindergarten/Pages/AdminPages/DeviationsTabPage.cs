using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace VismaKindergarten.Pages.AdminPages
{
    public class DeviationsTabPage : BasePage
    {
        public DeviationsTabPage(IWebDriver driver) : base(driver)
        {
        }



        public int DeviationNumberCount()
        {
            IReadOnlyCollection<IWebElement> icons = Driver.FindElements(By.XPath("//table//button[@class='icon-button'][@title='Godkjenn'][not(@disabled)]"));
            var deviationNumber = icons.Count;
            return deviationNumber;


        }

        public void ResolveDeviations()
        {
            IReadOnlyCollection<IWebElement> icons = Driver.FindElements(By.XPath("//table//button[@class='icon-button'][@title='Godkjenn'][not(@disabled)]"));
            foreach (IWebElement icon in icons)
            {

                var notSolvedDeviation = Driver.FindElement(By.XPath("//table//button[@class='icon-button'][@title='Godkjenn'][not(@disabled)]"));
                notSolvedDeviation.Click();

            }
        }



    }
}
