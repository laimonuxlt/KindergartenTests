using System;
using System.Collections.Generic;
using System.Text;

namespace VismaKindergarten.Tests.RestSharpTests.Models
{
    public class LoginBodyModel
    {

        public string OnBehalfOf { get; set; }
        public string LanguageCode { get; set; }
        public string IdentityNumber { get; set; }

        public LoginBodyModel CreateClientBody()
        {
            var clientBodyModel = new LoginBodyModel
            {
                OnBehalfOf = "SeleniumTestAutomation",
                LanguageCode = "en-US",
                IdentityNumber = "03101885525"
            };


            return clientBodyModel;
        }



    }
}
