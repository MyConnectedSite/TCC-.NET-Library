using System;
using Newtonsoft.Json;

namespace TCC2.API.CloudTracker
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class GetCloudTrackerSettingsResult : ApiCallResult
    {
        [JsonProperty(PropertyName = "viewGroup")]
        public CloudTrackerAccessGroup ViewerGroup { get; protected set; }

        [JsonProperty(PropertyName = "addEventGroup")]
        public CloudTrackerAccessGroup EventDepositorGroup { get; protected set; }

        [JsonProperty(PropertyName = "editGroup")]
        public CloudTrackerAccessGroup EditorGroup { get; protected set; }

        protected override void ValidateInstance(IRequestDataProvider provider)
        {
            base.ValidateInstance(provider);

            ValidateGroup(ViewerGroup, "viewer");
            ValidateGroup(EventDepositorGroup, "event depositor");
            ValidateGroup(EditorGroup, "editor");
        }

        static void ValidateGroup(CloudTrackerAccessGroup group, string groupName)
        {
            if (group != null)
            {
                ValidateHasValue(group.Id, groupName + " group ID");
                ValidateHasValue(group.Name, groupName + " group name");
            }
        }
    }
}