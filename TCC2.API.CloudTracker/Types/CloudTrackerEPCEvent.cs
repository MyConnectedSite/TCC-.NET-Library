using System;
using Newtonsoft.Json;

namespace TCC2.API.CloudTracker
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class CloudTrackerEPCEvent
    {
        [JsonProperty(PropertyName = "activeEPC")]
        public string EPC { get; set; }

        [JsonProperty(PropertyName = "eventid")]
        public string EventId { get; set; }

        [JsonProperty(PropertyName = "comment")]
        public string Comment { get; set; }

        [JsonProperty(PropertyName = "itemId")]
        public string ItemId { get; set; }

        [JsonProperty(PropertyName = "readerName")]
        public string ReaderName { get; set; }

        [JsonProperty(PropertyName = "antenna")]
        public string Antenna { get; set; }

        [JsonProperty(PropertyName = "lastSightingTime")]
        public DateTime? LastSightingTime { get; set; }

        [JsonProperty(PropertyName = "latitude")]
        public double? Latitude { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public double? Longitude { get; set; }

        [JsonProperty(PropertyName = "elevation")]
        public double? Elevation { get; set; }

        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }

        [JsonProperty(PropertyName = "lookupAddress")]
        public string LookupAddress { get; set; }
    }
}