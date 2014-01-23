using System;
using Newtonsoft.Json;

namespace TCC2.API.CloudTracker
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class SetCloudTrackerEPCEventsResult : ApiCallResult
    {
        [JsonProperty(PropertyName = "events")]
        public SetCloudTrackerEPCEventsResultEntry[] ResultEntries { get; protected set; }
                
        protected override void ValidateInstance(IRequestDataProvider provider)
        {
            base.ValidateInstance(provider);

            ValidateHasValue(ResultEntries, "events");            
        }
    }
}