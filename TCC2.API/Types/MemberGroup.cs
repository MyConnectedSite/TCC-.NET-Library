using System;
using Newtonsoft.Json;
using TCC2.API.Members;

namespace TCC2.API.Groups
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class MemberGroup : BaseMemberGroup
    {
        [JsonProperty(PropertyName = "groups")]
        public NestedMemberGroup[] NestedGroups { get; private set; }

        [JsonProperty(PropertyName = "members")]
        public BaseMemberData[] Members { get; protected set; }

        [JsonProperty(PropertyName = "createMember")]
        public string CreateMember { get; protected set; }

        [JsonProperty(PropertyName = "modifyMember")]
        public string ModifyMember { get; protected set; }
    }
}