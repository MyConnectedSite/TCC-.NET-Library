using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TCC2.API.Filesystem
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    class SerializableDirResult : SerializableDirEntry
    {
        [JsonProperty(PropertyName = "success", Required = Required.Always)]
        public bool Success { get; protected set; }

        [JsonProperty(PropertyName = "errorid")]
        public string ErrorId { get; protected set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; protected set; }

        [JsonProperty(PropertyName = "filespacePermissionLevel")]
        public string FilespacePermissionLevel { get; protected set; }

        [JsonProperty(PropertyName = "fileSpaceShortName")]
        public string FilespaceShortName { get; protected set; }

        [JsonProperty(PropertyName = "fileSpaceTitle")]
        public string FilespaceTitle { get; protected set; }

        [JsonProperty(PropertyName = "orgShortname")]
        public string OrgShortName { get; protected set; }

        [JsonProperty(PropertyName = "orgTitle")]
        public string OrgTitle { get; protected set; }

        public override bool IsValidFile
        {
            get
            {
                return !IsFolder.HasValue &&
                    !Type.HasValue &&
                    Entries != null &&
                    Entries.Length == 1 &&
                    Entries[0].IsValidFile;
            }
        }
    }
}