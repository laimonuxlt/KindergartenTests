using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace VismaKindergarten.Tests.RestSharpTests
{
    public class RestHelper
    {
        private RestClient _restClient;
        private string baseUrl = "https://api.manage.barnehage.testaws.visma.com";

        public RestHelper()
        {
            _restClient = new RestClient(baseUrl);
        }


        public IRestResponse Post(string resourse, object bodyObj)
        {
            var request = new RestRequest(resourse, Method.POST);
            request.AddHeader("Requested-by", "XMLHttpRequest");
            request.AddJsonBody(bodyObj);
            var response = _restClient.Execute(request);
            return response;
        }

        public IRestResponse Get(string resourse, IList<RestResponseCookie> cookies)
        {
            var request = new RestRequest(resourse, Method.GET);
            request.AddHeader("Requested-by", "XMLHttpRequest");
           
        }



    }
}
