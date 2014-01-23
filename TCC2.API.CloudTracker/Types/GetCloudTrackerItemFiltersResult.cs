using System;
using Newtonsoft.Json;

namespace TCC2.API.CloudTracker
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class GetCloudTrackerItemFiltersResult : ApiCallResult
    {
        [JsonProperty(PropertyName = "organizations")]
        public CloudTrackerOrgAccessPermission[] Organizations { get; protected set; }

        [JsonProperty(PropertyName = "categories")]
        public string[] Categories { get; protected set; }

        [JsonProperty(PropertyName = "types")]
        public string[] Types { get; protected set; }

        [JsonProperty(PropertyName = "locations")]
        public string[] Locations { get; protected set; }

        protected override void ValidateInstance(IRequestDataProvider provider)
        {
            base.ValidateInstance(provider);
            ValidateHasValue(Organizations, "organizations");
            ValidateHasValue(Categories, "categories");
            ValidateHasValue(Categories, "types");
            ValidateHasValue(Categories, "locations");
        }
    }
}