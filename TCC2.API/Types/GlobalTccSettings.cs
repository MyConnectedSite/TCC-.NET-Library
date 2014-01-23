using System;
using Newtonsoft.Json;

namespace TCC2.API.Members
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class GlobalTccSettings
    {
        [JsonProperty(PropertyName = "archiveemaildomain")]
        public string ArchiveEmailDomain { get; protected set; }

        [JsonProperty(PropertyName = "attachmentsemaildomain")]
        public string AttachmentsEmailDomain { get; protected set; }

        [JsonProperty(PropertyName = "emaildomain")]
        public string EmailDomain { get; protected set;}

        [JsonProperty(PropertyName = "externalGoogleGadgets")]
        public string ExternalGoogleGadgets { get; protected set; }

        [JsonProperty(PropertyName = "forumemaildomain")]
        public string ForumEmailDomain { get; protected set; }

        [JsonProperty(PropertyName = "forumemailnotificationaddress")]
        public string ForumEmailNotificationsAddress { get; protected set; }

        [JsonProperty(PropertyName = "notRemovableOrgShortname")]
        public string NotRemovableOrgShortname { get; protected set; }

        [JsonProperty(PropertyName = "orgDeletionDelay")]
        public int OrgDeletionDelay { get; protected set; }
    }
}
