using System;
using Newtonsoft.Json;

namespace TCC2.API.Organizations
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class GetOrganizationsResult : ApiCallResult
    {
        [JsonProperty(PropertyName = "organizations")]
        public OrganizationBase[] Organizations { get; protected set; }

        protected override void ValidateInstance(IRequestDataProvider provider)
        {
            base.ValidateInstance(provider);

            if (Organizations == null)
                throw new TccException("Organizations data is missing in response", true);
        }
    }
}