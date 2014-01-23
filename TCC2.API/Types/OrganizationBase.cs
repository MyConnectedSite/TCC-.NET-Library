using System;
using Newtonsoft.Json;

namespace TCC2.API.Organizations
{
    public enum OrganizationType
    {
        Customer,
        Dealer,
        Partner,
        Internal
    }

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class OrganizationBase
    {
        [JsonProperty(PropertyName = "orgId")]
        public string Id { get; protected set; }

        [JsonProperty(PropertyName = "orgtype")]
        public OrganizationType OrganizationType { get; protected set; }

        [JsonProperty(PropertyName = "shortname")]
        public string ShortName { get; protected set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; protected set; }
    }
}