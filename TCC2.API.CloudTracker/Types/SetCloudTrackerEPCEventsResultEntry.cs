using System;
using Newtonsoft.Json;

namespace TCC2.API.CloudTracker
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class SetCloudTrackerEPCEventsResultEntry : ApiCallResult
    {
		[JsonProperty(PropertyName = "itemId")]
        public string ItemId { get; protected set; }
		
        [JsonProperty(PropertyName = "eventId")]
        public string EventId { get; protected set; }
		
		[JsonProperty(PropertyName = "activeEPC")]
        public string ActiveEPC { get; protected set; }
    }
}
