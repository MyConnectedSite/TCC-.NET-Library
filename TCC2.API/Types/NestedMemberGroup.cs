using System;
using Newtonsoft.Json;

namespace TCC2.API.Groups
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class NestedMemberGroup : BaseGroup
    {
        [JsonProperty(PropertyName = "orgDisplayName")]
        public string OrgDisplayName { get; protected set; }

        [JsonProperty(PropertyName = "orgShortname")]
        public string OrgShortName { get; protected set; }
    }
}
