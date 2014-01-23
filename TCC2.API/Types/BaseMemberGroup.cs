using System;
using Newtonsoft.Json;
using TCC2.API.Members;

namespace TCC2.API.Groups
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public abstract class BaseMemberGroup : BaseGroup
    {
        [JsonProperty(PropertyName = "description")]
        public string Description { get; protected set; }

        [JsonProperty(PropertyName = "createTime")]
        public DateTime CreateTime { get; protected set; }

        [JsonProperty(PropertyName = "modifyTime")]
        public DateTime ModifyTime { get; protected set; }
    }
}