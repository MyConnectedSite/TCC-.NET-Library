using System;
using Newtonsoft.Json;

namespace TCC2.API.Members
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class GetMemberResult : ApiCallResult
    {
        [JsonProperty(PropertyName = "data")]
        public MemberData Data { get; protected set; }

        [JsonProperty(PropertyName = "globalSettings")]
        public GlobalTccSettings GlobalSettings { get; protected set; }

        protected override void ValidateInstance(IRequestDataProvider provider)
        {
            base.ValidateInstance(provider);

            if (Data == null)
                throw new TccException("Member data is missing in response", true);

            if (GlobalSettings == null)
                throw new TccException("Global settings data is missing in response", true);
        }
    }
}
