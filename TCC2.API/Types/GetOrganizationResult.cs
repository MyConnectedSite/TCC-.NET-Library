using System;
using Newtonsoft.Json;

namespace TCC2.API.Organizations
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class GetOrganizationResult : ApiCallResult
    {
        [JsonProperty(PropertyName = "data")]
        public Organization Data { get; protected set; }

        protected override void ValidateInstance(IRequestDataProvider provider)
        {
            base.ValidateInstance(provider);

            if (Data == null)
                throw new TccException("Organization data is missing in response", true);
        }
    }
}