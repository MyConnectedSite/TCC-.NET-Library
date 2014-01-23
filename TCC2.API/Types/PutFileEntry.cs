using System;
using Newtonsoft.Json;

namespace TCC2.API.Filesystem
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class PutFileEntry
    {
        [JsonProperty(PropertyName = "entryid")]
        public string EntryId { get; protected set; }

        [JsonProperty(PropertyName = "path")]
        public string Path { get; protected set; }
    }
}