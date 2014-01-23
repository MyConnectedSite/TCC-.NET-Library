using System;
using Newtonsoft.Json;

namespace TCC2.API.Groups
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class SetGroupResult : ApiCallResult
    {
        [JsonProperty(PropertyName = "groupId")]
        public string GroupId { get; protected set; }

        protected override void ValidateInstance(IRequestDataProvider provider)
        {
            base.ValidateInstance(provider);

            const string displayName = "group ID";
            ValidateHasValue(GroupId, displayName);
            ValidateValueMatchesInputParam(GroupId, provider, "groupid", displayName);
        }
    }
}
