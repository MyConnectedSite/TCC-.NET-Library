using System;
using Newtonsoft.Json;

namespace TCC2.API.Groups
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class GetGroupsResult : ApiCallResult
    {
        [JsonProperty(PropertyName = "groups")]
        public ShortMemberGroup[] Groups { get; protected set; }

        protected override void ValidateInstance(IRequestDataProvider provider)
        {
            base.ValidateInstance(provider);
            ValidateHasValue(Groups, "member groups");
        }
    }
}
