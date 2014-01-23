using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCC2.API;
using System.Collections.ObjectModel;

namespace FileNotification
{
    class SetEvents: ApiCallBase<SetEventsResult>
    {
        protected override string Url
        {
            get { return "/app/tcc/vssfilenotification/actions/SetEventsStatusesAction"; }
        }

        public SetEvents(Session session)
            : base(session)
        {
        }

        public SetEvents(Session session, IRequest request)
            : base(session, request)
        {
        }

        public void BeginCall(ICollection<SetEventsParameter> parameters, AsyncCallback callback, object state)
        {
            CheckAlreadyCalled();

            foreach (SetEventsParameter parameter in parameters)
            {
                AddParameter("eventid", parameter.EventId);
                AddParameter("status", parameter.Status);
                AddParameter("statusprovider", parameter.StatusProvider);     
            }
          
            base.BeginCall(callback, state);
        }



        public SetEventsResult Call(ICollection<SetEventsParameter> parameters)
        {
            BeginCall(parameters,null, null);
            return EndCall();
        }

        public SetEventsResult Call(String EventId, String Status, String StatusProvider)
        {
            SetEventsParameter parameter = new SetEventsParameter();
            parameter.EventId = EventId;
            parameter.Status = Status;
            parameter.StatusProvider = StatusProvider;
            LinkedList<SetEventsParameter> list = new LinkedList<SetEventsParameter>();
            list.AddFirst(parameter);
            return Call(list);
        }
    }
    
}
