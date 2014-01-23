using System;
using Newtonsoft.Json;
using TCC2.API;

namespace TCC2.API.Trips
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class SetTripResult : ApiCallResult
    {
        [JsonProperty(PropertyName = "tripid")]
        public string TripId { get; protected set; }

        [JsonProperty(PropertyName = "tripresourcefolderpath")]
        public string TripResourceFolderPath { get; protected set; }
    }
}