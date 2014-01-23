using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCC2.API;
using System.Collections.ObjectModel;

namespace FileNotification
{
    class DeleteEvents : ApiCallBase<DeleteEventsResult>
    {

           protected override string Url
        {
            get { return "/app/tcc/vssfilenotification/actions/DeleteEventsAction"; }
        }

        public DeleteEvents(Session session)
            : base(session)
        {
        }

        public DeleteEvents(Session session, IRequest request)
            : base(session, request)
        {
        }

        public void BeginCall(ICollection<string> eventIds, AsyncCallback callback, object state)
        {
            CheckAlreadyCalled();
            foreach (string eventId in eventIds)
                AddParameter("eventid",eventId);
            
            base.BeginCall(callback, state);
        }

        public DeleteEventsResult Call(ICollection<string> eventIds)
        {
            BeginCall(eventIds, null, null);
            return EndCall();
        }
    }
}
