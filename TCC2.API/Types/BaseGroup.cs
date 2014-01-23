using System;
using Newtonsoft.Json;
using TCC2.API.Members;

namespace TCC2.API.Groups
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public abstract class BaseGroup
    {
        [JsonProperty(PropertyName = "groupId")]
        public string Id { get; protected set; }

        [JsonProperty(PropertyName = "groupName")]
        public string Name { get; protected set; }

        [JsonProperty(PropertyName = "groupType")]
        public string GroupType { get; protected set; }

        [JsonProperty(PropertyName = "orgId")]
        public string OrganizationId { get; protected set; }
    }
}