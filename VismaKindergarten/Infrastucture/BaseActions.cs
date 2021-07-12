using System;
using System.Collections.Generic;
using System.Text;

namespace VismaKindergarten.Infrastucture
{
    public abstract class BaseActions
    {
        protected readonly RestSharpClient Client;

        protected BaseActions()
        {
            Client = new RestSharpClient();
        }
    }
}
