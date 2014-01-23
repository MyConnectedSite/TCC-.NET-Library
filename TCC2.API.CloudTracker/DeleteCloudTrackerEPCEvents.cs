using System;
using System.Collections.Generic;
using System.Linq;

namespace TCC2.API.CloudTracker
{
    public class DeleteCloudTrackerEPCEvents : CloudTrackerItemOperation<ApiCallResult>
    {
        public DeleteCloudTrackerEPCEvents(Session session)
            : base(session)
        {
        }

        public void BeginCall(IEnumerable<string> eventIds, AsyncCallback callback, object state)
        {
            CheckAlreadyCalled();

            if (eventIds == null)
                throw new ArgumentNullException("eventIds");

            if (!eventIds.Any())
                throw new ArgumentException("Event IDs collection is empty", "eventIds");

            foreach (string eventId in eventIds)
            {
                AddParameter("eventid", eventId);
            }
            
            BeginCall(callback, state);
        }

        public void Call(string itemId)
        {
            BeginCall(itemId, null, null);
            EndCall();
        }

        public void Call(IEnumerable<string> eventIds)
        {
            BeginCall(eventIds, null, null);
            EndCall();
        }

        protected override string Url
        {
            get { return "deletecloudtrackerepcevents"; }
        }

        protected override IRequest GetDefaultRequest()
        {
            return Session.CreatePostRequest();
        }
    }
}