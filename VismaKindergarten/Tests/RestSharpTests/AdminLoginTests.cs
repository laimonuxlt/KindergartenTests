using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using VismaKindergarten.Tests.RestSharpTests.Models;

namespace VismaKindergarten.Tests.RestSharpTests
{
    public class AdminLoginTests
    {
        private string resourse = "/localaccount/signin";        
        private string baseUrl = "https://api.manage.barnehage.testaws.visma.com";

        //private string baseUrl = "https://api.barnehage.testaws.visma.com";
        //private string url = "https://api.barnehage.testaws.visma.com/localaccount/signin";
        
        IList<RestResponseCookie> receivedCookies;
        private RestHelper _restHelper;

        public AdminLoginTests()
        {
            _restHelper = new RestHelper();
        }


        [Test, Order(1)]
        public void AdminLogin()
        {

            var loginModel= new LoginBodyModel();
            var loginBody = loginModel.CreateClientBody();

            //TODO pass the resourse  and loginBody to RestHelpers's Post method
            //public IRestResponse Post(resourse, loginObject, ?cookies?);
            //
            
            var response = _restHelper.Post(resourse, loginBody);
            receivedCookies = response.Cookies;
            var receivedStatus = response.StatusCode; 



            //var loginRequest = CreateRestRequest(resourse, Method.POST);
            //loginRequest.AddHeader("Requested-by", "XMLHttpRequest");
            //loginRequest.AddJsonBody(clientLoginObject.CreateClientBody());

            //var response = SendRequest(loginRequest);
            //receivedCookies = response.Cookies;           

            //var receivedStatus = response.StatusCode;

            Assert.AreEqual(HttpStatusCode.OK, receivedStatus);

        }

        [Test, Order(2)]
        public void CheckSession()
        {
            
            
            
            var sessionRequest = CreateRestRequest("/session", Method.GET);
            sessionRequest.AddHeader("Requested-by", "XMLHttpRequest");

            var sessionResponse = SendRequest(sessionRequest, receivedCookies);

            var sessionData = JsonConvert.DeserializeObject<SessionDataModel>(sessionResponse.Content);

           
            
            var sessionStatus = sessionResponse.StatusCode;
            var firstName = sessionData.FirstName;
            var lastName = sessionData.LastName;

            Assert.AreEqual(HttpStatusCode.OK, sessionStatus);             
            Assert.AreEqual("Laimonas", firstName);
            Assert.AreEqual("Samalius", lastName);
        }



        public RestRequest CreateRestRequest(string resourse, Method method)
        {
            var restRequest = new RestRequest
            {
                Resource = resourse,
                Method = method,
                RequestFormat = DataFormat.Json
            };

            return restRequest;
        }

        public IRestResponse SendRequest(RestRequest request, IList<RestResponseCookie> cookies = null)
        {
            var client = new RestClient(baseUrl);

            client.CookieContainer = new CookieContainer();


            if (cookies != null)
            {
                foreach (var cookie in cookies)
                {
                    var gsIdCookie = new Cookie(cookie.Name, cookie.Value)
                    { Domain = "api.manage.barnehage.testaws.visma.com" };

                    client.CookieContainer.Add(gsIdCookie);

                }
            }

            var requestResponse = client.Execute(request);
            return requestResponse;
        }

    }

    public class SessionDataModel
    {

        public string PersonID { get; set; }
        public string LanguageCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string OrganizationName { get; set; }

        public string OrganizationId { get; set; }


    }

}