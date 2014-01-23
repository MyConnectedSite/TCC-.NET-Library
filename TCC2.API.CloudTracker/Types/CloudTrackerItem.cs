using System;
using Newtonsoft.Json;

namespace TCC2.API.CloudTracker
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class CloudTrackerItem : BaseCloudTrackerItem
    {
        [JsonProperty(PropertyName = "createMemberDisplayName")]
        public string CreateMemberDisplayName { get; protected set; }

        [JsonProperty(PropertyName = "modifyMemberDisplayName")]
        public string ModifyMemberDisplayName { get; protected set; }

        [JsonProperty(PropertyName = "lastEvent")]
        public CloudTrackerItemEvent LastEvent { get; protected set; }

        public bool IsReferenceOnlyItem
        {
            get
            {
                return ItemId != null &&
                    ActiveEPC == null &&
                    AssetIcon == null &&
                    OrganizationId == null &&
                    OrganizationName == null &&
                    OrganizationShortName == null &&
                    Category == null &&
                    Type == null &&
                    Manufacturer == null &&
                    Model == null &&
                    SerialNumber == null &&
                    !CreateTime.HasValue &&
                    CreateMember == null &&
                    !ModifyTime.HasValue &&
                    ModifyMember == null &&
                    CreateMemberDisplayName == null &&
                    ModifyMemberDisplayName == null &&
                    LastEvent == null;
            }
        }
    }
}