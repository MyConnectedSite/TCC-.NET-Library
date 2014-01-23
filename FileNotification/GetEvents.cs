using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCC2.API;

namespace FileNotification
{
    class GetEvents : ApiCallBase<GetEventsResult>
    {
        protected override string Url
        {
            get { return "/app/tcc/vssfilenotification/actions/GetEventsAction"; }
        }

        public GetEvents(Session session)
            : base(session)
        {
        }

        public GetEvents(Session session, IRequest request)
            : base(session, request)
        {
        }

        public void BeginCall(string status, int limit, AsyncCallback callback, object state)
        {
            CheckAlreadyCalled();
            AddParameter("status", status);
            AddParameter("limit", limit);

            base.BeginCall(callback, state);
        }

        public void BeginCall(string status, int limit, DateTime maximumEndStatusDate, AsyncCallback callback, object state)
        {
            CheckAlreadyCalled();          
            AddParameter("status", status);
            AddParameter("limit", limit);
            AddParameter("endstatusdate", maximumEndStatusDate.ToString("yyyy-MM-dd HH:mm:ss"));

            base.BeginCall(callback, state);
        }


        public GetEventsResult Call(string status, int limit)
        {
            BeginCall(status, limit, null, null);
            return EndCall();
        }

        public GetEventsResult Call(string status, int limit, DateTime maximumEndStatusDate)
        {
            BeginCall(status, limit, maximumEndStatusDate, null, null);
            return EndCall();
        }
    }
}

