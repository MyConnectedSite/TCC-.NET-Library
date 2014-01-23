using System;
using Newtonsoft.Json;

namespace TCC2.API.Filesystem
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class SetFilespaceResult : ApiCallResult
    {
        [JsonProperty(PropertyName = "fileSpaceId")]
        public string FilespaceId { get; protected set; }

        protected override void ValidateInstance(IRequestDataProvider provider)
        {
            base.ValidateInstance(provider);
            if (String.IsNullOrEmpty(FilespaceId))
                throw new TccException("Invalid filespace ID returned in response", true);
        }
    }
}
