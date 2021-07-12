using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace VismaKindergarten.ApiHelpers.Manage
{
    public class ManageAuthHelper : IAuthHelper
    {
        public string Url { set; get; }


        private readonly RestClient _restClient;
        public CookieContainer CookieJar => _restClient.CookieContainer;

        public ManageAuthHelper()
        {
            _restClient = new RestClient
            {
                BaseUrl = new Uri("https://api.manage.barnehage.testaws.visma.com"),
                CookieContainer = new CookieContainer()

            };

            var apiUrl = new Uri("https://api.manage.barnehage.testaws.visma.com" + "");
            Url = apiUrl.AbsoluteUri;
        }
        public void Login(string onBelhafOf, string birthNumber)
        {
            // TODO login
            //save cookies in cookieJar
        }
    }
}
