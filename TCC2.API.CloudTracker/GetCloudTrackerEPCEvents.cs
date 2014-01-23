using System;
using System.Collections.Generic;

namespace TCC2.API.CloudTracker
{
    public class GetCloudTrackerEPCEvents : ApiCallBase<GetCloudTrackerEPCEventsResult>
    {
        public GetCloudTrackerEPCEvents(Session session)
            : base(session)
        {
        }

        public GetCloudTrackerEPCEvents(Session session, IRequest request)
            : base(session, request)
        {
        }

        public void BeginCall(string itemId, PageableResponseParameters pageableParams, AsyncCallback callback, object state)
        {
            CheckAlreadyCalled();

            if (String.IsNullOrEmpty(itemId))
                throw new ArgumentException("Item ID is not specified", "itemId");

            AddParameter("itemId", itemId);

            if (pageableParams != null)
            {
                foreach (KeyValuePair<string, string> param in pageableParams.GetParameters())
                {
                    AddParameter(param.Key, param.Value);
                }
            }

            BeginCall(callback, state);
        }

        public GetCloudTrackerEPCEventsResult Call(string itemId, PageableResponseParameters pageableParams)
        {
            BeginCall(itemId, pageableParams, null, null);
            return EndCall();
        }

        protected override string Url
        {
            get { return "getcloudtrackerepcevents"; }
        }
    }
}