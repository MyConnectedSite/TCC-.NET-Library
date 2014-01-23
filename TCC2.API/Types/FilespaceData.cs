using System;
using Newtonsoft.Json;

namespace TCC2.API.Filesystem
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class FilespaceData
    {
        [JsonProperty(PropertyName = "ACLAnonymousAccess")]
        public bool AclAnonymousAccess { get; protected set; }

        [JsonProperty(PropertyName = "orgId")]
        public string OrgId { get; protected set; }

        [JsonProperty(PropertyName = "orgShortname")]
        public string OrgShortName { get; protected set; }

        [JsonProperty(PropertyName = "orgDisplayName")]
        public string OrgDisplayName { get; protected set; }

        [JsonProperty(PropertyName = "fileSpaceId")]
        public string FilespaceId { get; protected set; }

        [JsonProperty(PropertyName = "filespacetype")]
        public string FilespaceType { get; protected set; }

        [JsonProperty(PropertyName = "ftppath")]
        public string FtpPath { get; protected set; }

        [JsonProperty(PropertyName = "shortname")]
        public string ShortName { get; protected set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; protected set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; protected set; }

        [JsonProperty(PropertyName = "authority")]
        public string Authority { get; protected set; }

        public override bool Equals(object obj)
        {
            FilespaceData filespaceData = obj as FilespaceData;
            if (filespaceData == null)
                return false;

            return OrgId.Equals(filespaceData.OrgId) &&
                   OrgShortName.Equals(filespaceData.OrgShortName) &&
                   OrgDisplayName.Equals(filespaceData.OrgDisplayName) &&
                   FilespaceId.Equals(filespaceData.FilespaceId) &&
                   FtpPath.Equals(filespaceData.FtpPath) &&
                   ShortName.Equals(filespaceData.ShortName) &&
                   Title.Equals(filespaceData.Title) &&
                   Description.Equals(filespaceData.Description) &&
                   Authority.Equals(filespaceData.Authority);
        }

        public override int GetHashCode()
        {
            return OrgId.GetHashCode() ^ ~FilespaceId.GetHashCode() ^ ShortName.GetHashCode();
        }
    }
}