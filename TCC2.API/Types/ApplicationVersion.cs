using System;
using Newtonsoft.Json;

namespace TCC2.API
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ApplicationVersion
    {
        [JsonProperty(PropertyName = "version")]
        public string Version { get; protected set; }

        [JsonProperty(PropertyName = "buildNumber")]
        public string BuildNumber { get; protected set; }

        [JsonProperty(PropertyName = "buildTime")]
        public string BuildTime { get; protected set; }

        [JsonProperty(PropertyName = "releaseNotesUrl")]
        public string ReleaseNotesUrl { get; protected set; }

        [JsonProperty(PropertyName = "installUrl")]
        public string InstallUrl { get; protected set; }
    }
}
