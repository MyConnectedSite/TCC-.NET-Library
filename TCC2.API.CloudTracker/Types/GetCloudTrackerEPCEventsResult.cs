using System;
using Newtonsoft.Json;

namespace TCC2.API.CloudTracker
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class GetCloudTrackerEPCEventsResult : ApiCallResult
    {
        [JsonProperty(PropertyName = "events")]
        public CloudTrackerEPCEvent[] Events { get; protected set; }

        protected override void ValidateInstance(IRequestDataProvider provider)
        {
            base.ValidateInstance(provider);
            ValidateHasValue(Events, "events");
        }
    }
}