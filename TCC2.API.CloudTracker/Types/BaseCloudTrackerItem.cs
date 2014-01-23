using System;
using Newtonsoft.Json;

namespace TCC2.API.CloudTracker
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class BaseCloudTrackerItem
    {
        [JsonProperty(PropertyName = "itemId")]
        public string ItemId { get; protected set; }

        [JsonProperty(PropertyName = "orgId")]
        public string OrganizationId { get; protected set; }

        [JsonProperty(PropertyName = "orgName")]
        public string OrganizationName { get; protected set; }

        [JsonProperty(PropertyName = "orgShortname")]
        public string OrganizationShortName { get; protected set; }

        [JsonProperty(PropertyName = "activeEPC")]
        public string ActiveEPC { get; protected set; }

        [JsonProperty(PropertyName = "assetIcon")]
        public string AssetIcon { get; protected set; }

        [JsonProperty(PropertyName = "category")]
        public string Category { get; protected set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; protected set; }

        [JsonProperty(PropertyName = "manufacturer")]
        public string Manufacturer { get; protected set; }

        [JsonProperty(PropertyName = "model")]
        public string Model { get; protected set; }

        [JsonProperty(PropertyName = "serialnumber")]
        public string SerialNumber { get; protected set; }

        [JsonProperty(PropertyName = "createTime")]
        public DateTime? CreateTime { get; protected set; }

        [JsonProperty(PropertyName = "createMember")]
        public string CreateMember { get; protected set; }

        [JsonProperty(PropertyName = "modifyTime")]
        public DateTime? ModifyTime { get; protected set; }

        [JsonProperty(PropertyName = "modifyMember")]
        public string ModifyMember { get; protected set; }
    }
}