using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace VismaKindergarten.Infrastucture
{


    public interface IRequestClient
    {
        IRequest Post(string resourse);
    }

    public interface IRequest
    {

        IRequest WithBody<T>(T body);
        IRequest WithArgument(string key, object obj);
        T As<T>();


    }
    public class RestClient
    {

    }

    public class RestSharpRequest : IRequest
    {
        private readonly RestRequest _restRequest;

        public RestSharpRequest(string resource, Method httpMethod)
        {
            _restRequest = new RestRequest(resource, httpMethod, DataFormat.Json);
        }



        public IRequest WithArgument(string key, object obj)
        {
            _restRequest.AddParameter(key, obj);
            return this;
        }

        public IRequest WithBody<T>(T body)
        {

            _restRequest.AddJsonBody(body);
            return this;
        }

        public T As<T>()
        {
            throw new NotImplementedException();
        }

    }

}


