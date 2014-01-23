using System;
using Newtonsoft.Json;

namespace TCC2.API.Groups
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ShortMemberGroup : BaseMemberGroup
    {
        [JsonProperty(PropertyName = "orgName")]
        public string OrganizationName { get; protected set; }

        [JsonProperty(PropertyName = "orgDisplayName")]
        public string OrganizationDisplayName { get; protected set; }
    }
}