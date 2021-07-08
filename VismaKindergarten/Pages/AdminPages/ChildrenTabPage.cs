using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using VismaKindergarten.Pages;

namespace VismaKindergarten
{
    public class ChildrenTabPage : BasePage
    {
        
        
        public ChildrenTabPage (IWebDriver driver) : base(driver)
        {
            
        }

        public string CheckUrlAddress()
        {
            return Driver.Url;
        }
    }
}
