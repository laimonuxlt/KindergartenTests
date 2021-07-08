
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace VismaKindergarten.Pages
{
    public abstract class BasePage
    {
        public IWebDriver Driver;
        
        public BasePage(IWebDriver driver) 
        {
            Driver = driver;
            
        }

    }
}
