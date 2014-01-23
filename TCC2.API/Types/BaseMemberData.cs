using System;
using Newtonsoft.Json;

namespace TCC2.API.Members
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class BaseMemberData
    {
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; protected set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; protected set; }

        [JsonProperty(PropertyName = "memberId")]
        public string MemberId { get; protected set; }

        [JsonProperty(PropertyName = "orgId")]
        public string OrgId { get; protected set; }

        [JsonProperty(PropertyName = "orgShortname")]
        public string OrgShortName { get; protected set; }

        [JsonProperty(PropertyName = "shortname")]
        public string ShortName { get; protected set; }

        [JsonProperty(PropertyName = "type")]
        public MemberType MemberType { get; protected set; }
    }
}