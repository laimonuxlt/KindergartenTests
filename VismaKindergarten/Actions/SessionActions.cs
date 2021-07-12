using System;
using System.Collections.Generic;
using System.Text;
using VismaKindergarten.ApiPages;

namespace VismaKindergarten.Actions
{
    public class SessionActions: BaseManageActions
    { 
        public SessionModel Get()
        {
            return Client.Get("session").As<SessionModel>();
        }

    }
}
