using System;
using Newtonsoft.Json;

namespace TCC2.API.CloudTracker
{
    public enum CloudTrackerOrgAccessLevel
    {
        [EnumFieldAlias("VIEWER")]
        Viewer,

        [EnumFieldAlias("EVENT_DEPOSITOR")]
        EventDepositor,

        [EnumFieldAlias("EDITOR")]
        Editor
    }

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class CloudTrackerOrgAccessPermission
    {
        [JsonProperty(PropertyName = "orgId")]
        public string OrganizationID { get; protected set; }

        [JsonProperty(PropertyName = "orgName")]
        public string OrganizationName { get; protected set; }

        [JsonProperty(PropertyName = "orgShortname")]
        public string OrganizationShortName { get; protected set; }

        [JsonProperty(PropertyName = "access")]
        [JsonConverter(typeof(EnumTypeConverter<CloudTrackerOrgAccessLevel>))]
        public CloudTrackerOrgAccessLevel AccessLevel { get; protected set; }
    }
}