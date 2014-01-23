using System;
using Newtonsoft.Json;

namespace TCC2.API.Groups
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class GetGroupResult : ApiCallResult
    {
        [JsonProperty(PropertyName = "data")]
        public MemberGroup Group { get; protected set; }

        protected override void ValidateInstance(IRequestDataProvider provider)
        {
            base.ValidateInstance(provider);
            ValidateHasValue(Group, "member group");
            ValidateValueMatchesInputParam(Group.Id, provider, "groupid", "member group ID");
        }
    }
}
