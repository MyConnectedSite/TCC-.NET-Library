using System;
using Newtonsoft.Json;

namespace TCC2.API.Filesystem
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class MkDirEntry
    {
        [JsonProperty(PropertyName = "path")]
        public string Path { get; protected set; }

        [JsonProperty(PropertyName = "entryId")]
        public string EntryId { get; protected set; }
    }
}