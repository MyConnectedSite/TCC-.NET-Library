using Newtonsoft.Json;

namespace TCC2.API.CloudTracker
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class CloudTrackerItemEvent
    {
        [JsonProperty(PropertyName = "eventId")]
        public string EventId { get; protected set; }

        [JsonProperty(PropertyName = "latitude")]
        public double? Latitude { get; protected set; }

        [JsonProperty(PropertyName = "longitude")]
        public double? Longitude { get; protected set; }

        [JsonProperty(PropertyName = "location")]
        public string Location { get; protected set; }

        [JsonProperty(PropertyName = "lookupAddress")]
        public string LookupAddress { get; protected set; }
    }
}