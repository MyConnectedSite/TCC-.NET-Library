using System;
using Newtonsoft.Json;

namespace TCC2.API.CloudTracker
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class CloudTrackerAccessGroup
    {
        [JsonProperty(PropertyName = "groupId")]
        public string Id { get; protected set; }

        [JsonProperty(PropertyName = "groupName")]
        public string Name { get; protected set; }

        [JsonProperty(PropertyName = "orgId")]
        public string OrganizationId { get; protected set; }

        [JsonProperty(PropertyName = "orgName")]
        public string OrganizationName { get; protected set; }

        [JsonProperty(PropertyName = "orgDisplayName")]
        public string OrganizationDisplayName { get; protected set; }
    }
}