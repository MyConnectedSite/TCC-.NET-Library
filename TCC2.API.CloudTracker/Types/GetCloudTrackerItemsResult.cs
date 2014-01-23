using System;
using Newtonsoft.Json;

namespace TCC2.API.CloudTracker
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class GetCloudTrackerItemsResult : ApiCallResult
    {
        [JsonProperty(PropertyName = "items")]
        public CloudTrackerItem[] Items { get; protected set; }

        [JsonProperty(PropertyName = "total")]
        public int Total { get; protected set; }

        [JsonProperty(PropertyName = "lastFilterTime")]
        public DateTime LastFilterTime { get; protected set; }

        protected override void ValidateInstance(IRequestDataProvider provider)
        {
            base.ValidateInstance(provider);
            ValidateHasValue(Items, "items");
        }
    }
}