using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TCC2.API
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class DetailedAccessControlEntry : AccessControlEntry
    {
        public DetailedAccessControlEntry()
            : base()
        {
        }

        [JsonProperty(PropertyName = "ACLEntryDescription")]
        public string Description { get; protected set; }

        [JsonProperty(PropertyName = "ACLEntryDisplayName")]
        public string DisplayName { get; protected set; }

        [JsonProperty(PropertyName = "devicetype")]
        public string DeviceType { get; protected set; }

        [JsonProperty(PropertyName = "ACLEntryFirstName")]
        public string FirtsName { get; protected set; }

        [JsonProperty(PropertyName = "iconCls")]
        public string IconClass { get; protected set; }

        [JsonProperty(PropertyName = "ACLEntryLastName")]
        public string LastName { get; protected set; }

        [JsonProperty(PropertyName = "ACLEntryShortname")]
        public string ShortName { get; protected set; }

        [JsonProperty(PropertyName = "ACLEntryOrgId")]
        public string OrganizationId { get; protected set; }

        [JsonProperty(PropertyName = "ACLEntryOrgDisplayName")]
        public string OrganizationDisplayName { get; protected set; }

        [JsonProperty(PropertyName = "ACLEntryOrgShortname")]
        public string OrganizationShortName { get; protected set; }
    }
}