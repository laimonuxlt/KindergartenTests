using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace VismaKindergarten.Pages.AdminPages
{
    public class DocumentationTabPage: BasePage
    {
        
        private IWebElement childAddress => Driver.FindElement(By.XPath("//kdg-contact-card[2]/div/div[5]/span"));
        private IWebElement childDoB => Driver.FindElement(By.XPath("//kdg-contact-card[2]/div/div[4]/span"));
        private IWebElement documentationChildFullName => Driver.FindElement(By.XPath("//kdg-contact-card[2]/div/div[2]/span"));
        private IWebElement applicantFullName => Driver.FindElement(By.XPath("//kdg-contact-card[1]/div/div[2]/span"));
        private IWebElement coApplicantFullName => Driver.FindElement(By.XPath("//kdg-contact-card[3]/div/div[2]/span"));
        private IWebElement coApplicantAddress => Driver.FindElement(By.XPath("//kdg-contact-card[3]/div/div[5]/span"));
        private IWebElement applicantAddress => Driver.FindElement(By.XPath("//kdg-contact-card[1]/div/div[5]/span"));

        public DocumentationTabPage(IWebDriver driver): base (driver)
        {
        }
            


        public string ReadApplicantFullName()
        {

            string retrievedApplicantFullName = applicantFullName.Text;
            return retrievedApplicantFullName;

        }

        public string ReadChildFullName()
        {
            string retrievedChildFullName = documentationChildFullName.Text;
            return retrievedChildFullName;
        }


        public string ReadChildDoB()
        {
            string retrievedChildDoB = childDoB.Text;
            return retrievedChildDoB;
        }

        public string ReadCoApplicantFullName()
        {
            string retrievedCoApplicantFullName = coApplicantFullName.Text;
            return retrievedCoApplicantFullName;
        }

        public string ReadChildAddress()
        {
            string retrievedChildAddress = childAddress.Text;
            return retrievedChildAddress;
        }

        public string ReadCoApplicantAddress()
        {
            string retrievedCoApplicantAddress = coApplicantAddress.Text;
            return retrievedCoApplicantAddress;
        }

        public string ReadApplicantAddress()
        {
            string retrievedChildDoB = applicantAddress.Text;
            return retrievedChildDoB;
        }

    }
}
