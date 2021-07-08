using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using VismaKindergarten.Pages;

namespace VismaKindergarten
{
    public class LoginAdminPage : BasePage
    {

        private IWebElement ddlEmployee => Driver.FindElement(By.XPath("//*[@id='employee']"));

        private IWebElement btnLogin => Driver.FindElement(By.XPath("//button[@class='btn green']"));



        public LoginAdminPage(IWebDriver driver) : base(driver)
        {
        }
        public ChildrenTabPage ClickLoginBtn()
        {

            btnLogin.Click();
            Thread.Sleep(1000);
            
            return new ChildrenTabPage(Driver);

        }

        public void SelectEmployee(string employee)
        {

            SelectElement ddlSelection = new SelectElement(ddlEmployee);
            ddlSelection.SelectByText(employee);


        }

    }
}
