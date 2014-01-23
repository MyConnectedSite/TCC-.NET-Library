using System;
using Newtonsoft.Json;

namespace TCC2.API.Members
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class LoginAccountData
    {
        [JsonProperty(PropertyName = "isCommunityAdmin")]
        bool m_IsCommunityAdmin = false;

        [JsonProperty(PropertyName = "communityAdmin")]
        bool m_CommunityAdmin = false;

        [JsonProperty(PropertyName = "orgAdmin")]
        bool m_OrgAdmin = false;

        [JsonProperty(PropertyName = "isOrgAdmin")]
        bool m_IsOrgAdmin = false;

        public bool IsCommunityAdmin
        {
            get { return m_CommunityAdmin || m_IsCommunityAdmin; }
        }

        public bool IsOrgAdmin
        {
            get { return m_OrgAdmin || m_IsOrgAdmin; }
        }

        [JsonProperty(PropertyName = "orgId")]
        public string OrgId { get; protected set; }

        [JsonProperty(PropertyName = "orgShortname")]
        public string OrgShortName { get; protected set; }

        [JsonProperty(PropertyName = "orgTitle")]
        public string OrgTitle { get; protected set; }

        [JsonProperty(PropertyName = "loginEnabled")]
        public bool LoginEnabled { get; protected set; }

        [JsonProperty(PropertyName = "type")]
        public MemberType MemberType { get; protected set; }

        [JsonProperty(PropertyName = "timeZone")]
        public string TimeZone { get; protected set; }

        [JsonProperty(PropertyName = "createTime")]
        public string CreateTime { get; protected set; }

        [JsonProperty(PropertyName = "createMember")]
        public string CreateMember { get; protected set; }

        [JsonProperty(PropertyName = "modifyTime")]
        public string ModifyTime { get; protected set; }

        [JsonProperty(PropertyName = "modifyMember")]
        public string ModifyMember { get; protected set; }

        [JsonProperty(PropertyName = "shortname")]
        public string ShortName { get; protected set; }

        [JsonProperty(PropertyName = "authorizeAnonymousAccess")]
        public bool AuthorizeAnonymousAccess { get; protected set; }

        [JsonProperty(PropertyName = "siteCreator")]
        public bool SiteCreator { get; protected set; }

        [JsonProperty(PropertyName = "pageCreator")]
        public bool PageCreator { get; protected set; }

        [JsonProperty(PropertyName = "fileSpaceCreator")]
        public bool FileSpaceCreator { get; protected set; }

        [JsonProperty(PropertyName = "forumCreator")]
        public bool ForumCreator { get; protected set; }

        [JsonProperty(PropertyName = "calendarCreator")]
        public bool CalendarCreator { get; protected set; }

        [JsonProperty(PropertyName = "tagListCreator")]
        public bool TagListCreator { get; protected set; }

        [JsonProperty(PropertyName = "manageGroups")]
        public bool ManageGroups { get; protected set; }

        [JsonProperty(PropertyName = "addmembers")]
        public bool AddMembers { get; protected set; }

        [JsonProperty(PropertyName = "editmembers")]
        public bool EditMembers { get; protected set; }

        [JsonProperty(PropertyName = "removemembers")]
        public bool RemoveMembers { get; protected set; }

        [JsonProperty(PropertyName = "expirationtime")]
        public string ExpirationTime { get; protected set; }

        [JsonProperty(PropertyName = "disabletime")]
        public string DisableTime { get; protected set; }

        [JsonProperty(PropertyName = "deletetime")]
        public string DeleteTime { get; protected set; }

        [JsonProperty(PropertyName = "spacemanagement")]
        public bool SpaceManagement { get; protected set; }

        [JsonProperty(PropertyName = "themecreator")]
        public bool ThemeCreator { get; protected set; }

        [JsonProperty(PropertyName = "organizationCreator")]
        public bool OrganizationCreator { get; protected set; }

        [JsonProperty(PropertyName = "customApplicationManager")]
        public bool CustomApplicationManager { get; protected set; }

        [JsonProperty(PropertyName = "quickShare")]
        public bool QuickShare { get; protected set; }

        [JsonProperty(PropertyName = "changepasswordonnextlogin")]
        public bool ChangePasswordOnNextLogin { get; protected set; }

        [JsonProperty(PropertyName = "devicemanager")]
        public bool DeviceManager { get; protected set; }

        [JsonProperty(PropertyName = "mountpointmanager")]
        public bool MountpointManager { get; protected set; }

        [JsonProperty(PropertyName = "ntripserver")]
        public bool NtripServer { get; protected set; }

        [JsonProperty(PropertyName = "statusupdateretentioninterval")]
        public string StatusUpdateRetentionInterval { get; protected set; }

        [JsonProperty(PropertyName = "lastLoginMethod")]
        public string LastLoginMethod { get; protected set; }

        [JsonProperty(PropertyName = "lastLoginTime")]
        public DateTime? LastLoginTime { get; protected set; }

        [JsonProperty(PropertyName = "timezoneOffset")]
        public int TimezoneOffset { get; protected set; }
    }
}
