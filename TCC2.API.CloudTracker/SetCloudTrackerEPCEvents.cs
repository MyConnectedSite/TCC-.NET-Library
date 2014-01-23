using System;
using System.Collections.Generic;
using System.Linq;

namespace TCC2.API.CloudTracker
{
    public struct CloudTrackerEPCEventEntry
    {
        public CloudTrackerEPCEvent Event { get; set; }
        public bool DoAddressLookup { get; set; }
    }

    public class SetCloudTrackerEPCEvents : ApiCallBase<SetCloudTrackerEPCEventsResult>
    {
        public SetCloudTrackerEPCEvents(Session session)
            : base(session)
        {
        }

        public void BeginCall(IEnumerable<CloudTrackerEPCEventEntry> entries, AsyncCallback callback, object state)
        {
            CheckAlreadyCalled();

            if (entries == null)
                throw new ArgumentNullException("entries");

            if (!entries.Any())
                throw new ArgumentException("Entries is empty");

            foreach (CloudTrackerEPCEventEntry entry in entries)
            {
                AddParameterOrEmptyPlaceholder("itemId", entry.Event.ItemId);
                AddParameterOrEmptyPlaceholder("epc", entry.Event.EPC);
                AddParameterOrEmptyPlaceholder("comment", entry.Event.Comment);
                AddParameterOrEmptyPlaceholder("readername", entry.Event.ReaderName);
                AddParameterOrEmptyPlaceholder("antenna", entry.Event.Antenna);
                AddParameterOrEmptyPlaceholder("lastsightingtime", entry.Event.LastSightingTime);
                AddParameterOrEmptyPlaceholder("latitude", entry.Event.Latitude);
                AddParameterOrEmptyPlaceholder("longitude", entry.Event.Longitude);
                AddParameterOrEmptyPlaceholder("elevation", entry.Event.Elevation);
                AddParameterOrEmptyPlaceholder("location", entry.Event.Location);
                AddParameterOrEmptyPlaceholder("lookupaddress", entry.Event.LookupAddress);
                AddParameter("dolookupaddress", entry.DoAddressLookup);
            }

            BeginCall(callback, state);
        }

        public SetCloudTrackerEPCEventsResult Call(IEnumerable<CloudTrackerEPCEventEntry> entries)
        {
            BeginCall(entries, null, null);
            return EndCall();
        }

        protected override string Url
        {
            get { return "setcloudtrackerepcevents"; }
        }

        protected override IRequest GetDefaultRequest()
        {
            return Session.CreatePostRequest();
        }
    }
}