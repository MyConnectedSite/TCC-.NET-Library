using System;
using System.Collections.Generic;
using System.Globalization;

namespace TCC2.API.CloudTracker
{
    public struct CloudTrackerItemLastEventPair
    {
        public string ItemId { get; set; }
        public string LastEventId { get; set; }
    }

    public class GetCloudTrackerItems : ApiCallBase<GetCloudTrackerItemsResult>
    {
        public GetCloudTrackerItems(Session session)
            : base(session)
        {
        }

        public void BeginCall(string orgId, IEnumerable<string> categories, IEnumerable<string> types, IEnumerable<string> locations, PageableResponseParameters pageableParams, DateTime? lastFilterTime, IEnumerable<CloudTrackerItemLastEventPair> itemLastEvents, AsyncCallback callback, object state)
        {
            CheckAlreadyCalled();

            AddParameter("orgId", orgId);
            AddParameter("lastFilterTime", lastFilterTime);

            if (categories != null)
            {
                foreach (string category in categories)
                {
                    AddParameter("category", category);
                }
            }

            if (types != null)
            {
                foreach (string type in types)
                {
                    AddParameter("types", type);
                }
            }

            if (locations != null)
            {
                foreach (string location in locations)
                {
                    AddParameter("locations", location);
                }
            }

            if (pageableParams != null)
            {
                foreach (KeyValuePair<string, string> param in pageableParams.GetParameters())
                {
                    AddParameter(param.Key, param.Value);
                }
            }

            if (itemLastEvents != null)
            {
                foreach (var itemLastEvent in itemLastEvents)
                {
                    AddParameterOrEmptyPlaceholder("itemid", itemLastEvent.ItemId);
                    AddParameterOrEmptyPlaceholder("eventid", itemLastEvent.LastEventId);
                }
            }

            BeginCall(callback, state);
        }

        public GetCloudTrackerItemsResult Call(string orgId, IEnumerable<string> categories, IEnumerable<string> types, IEnumerable<string> locations, PageableResponseParameters pageableParams, DateTime? lastFilterTime, IEnumerable<CloudTrackerItemLastEventPair> itemLastEvents)
        {
            BeginCall(orgId, categories, types, locations, pageableParams, lastFilterTime, itemLastEvents, null, null);
            return EndCall();
        }

        protected override string Url
        {
            get { return "getcloudtrackeritems"; }
        }

        protected override IRequest GetDefaultRequest()
        {
            return Session.CreatePostRequest();
        }
    }
}