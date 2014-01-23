using System;
using Newtonsoft.Json;

namespace TCC2.API
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ApplicationInformation : ApiCallResult
    {
        [JsonProperty(PropertyName = "currentversion")]
        public ApplicationVersion CurrentVersion { get; protected set; }
    }
}
