using System;
using Newtonsoft.Json;

namespace TCC2.API.Filesystem
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class GetFilespacesResult : ApiCallResult
    {
        protected override void ValidateInstance(IRequestDataProvider provider)
        {
            base.ValidateInstance(provider);

            if (Filespaces == null)
                throw new TccException("Filespaces data is missing in response", false);
        }

        [JsonProperty(PropertyName = "filespaces")]
        public FilespaceData[] Filespaces { get; protected set; }
    }
}
