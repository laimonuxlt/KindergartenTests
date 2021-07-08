using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace VismaKindergarten.Infrastucture
{
    public static class RestApiHelper
    {
        public static IRestResponse<T> Execute<T>(RestRequest request)
        {


            var restClient = new RestClient
            {

                BaseUrl = new Uri("https://api.manage.barnehage.testaws.visma.com")
            };

            request.AddHeader("Requested-by", "XMLHttpRequest");
            var response = restClient.Execute<T>(request);
            return response;
        }

    }
}
