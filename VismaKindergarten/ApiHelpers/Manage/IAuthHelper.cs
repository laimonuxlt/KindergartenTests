using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace VismaKindergarten.ApiHelpers.Manage
{
    public interface IAuthHelper
    {

        CookieContainer CookieJar { get; }
        public string Url { set; get; }

        public void Login(string onBelhafOf, string birthNumber);
    }
}
