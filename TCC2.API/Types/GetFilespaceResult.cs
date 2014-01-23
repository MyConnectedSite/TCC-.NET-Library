using System;
using Newtonsoft.Json;

namespace TCC2.API.Filesystem
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class GetFilespaceResult : ApiCallResult
    {
        [JsonProperty(PropertyName = "filespaceid")]
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

        [JsonProperty(PropertyName = "orgid")]
        public string OrgId { get; protected set; }

        [JsonProperty(PropertyName = "orgtitle")]
        public string OrgTitle { get; protected set; }

        [JsonProperty(PropertyName = "orgshortname")]
        public string OrgShortName { get; protected set; }

        [JsonProperty(PropertyName = "DeletedFilesMaximumAge")]
        public int? DeletedFilesMaximumAge { get; protected set; }

        [JsonProperty(PropertyName = "mailinenabled")]
        public bool? MailInEnabled { get; protected set; }

        [JsonProperty(PropertyName = "acceptablesenders")]
        public string[] AcceptableSenders { get; protected set; }

        [JsonProperty(PropertyName = "access")]
        public string Access { get; protected set; }

        [JsonProperty(PropertyName = "createTime")]
        public DateTime? CreateTime { get; protected set; }

        [JsonProperty(PropertyName = "createMember")]
        public string CreateMember { get; protected set; }

        [JsonProperty(PropertyName = "modifyTime")]
        public DateTime? ModifyTime { get; protected set; }

        [JsonProperty(PropertyName = "modifyMember")]
        public string ModifyMember { get; protected set; }

        [JsonProperty(PropertyName = "tripsCount")]
        public int TripsCount { get; protected set; }

        [JsonProperty(PropertyName = "maxversionage")]
        [JsonConverter(typeof(EmptyStringToIntConverter))]
        public int? MaxVersionAge { get; protected set; }

        [JsonProperty(PropertyName = "maxversioncount")]
        [JsonConverter(typeof(EmptyStringToIntConverter))]
        public int? MaxVersionCount { get; protected set; }

        protected override void ValidateInstance(IRequestDataProvider provider)
        {
            base.ValidateInstance(provider);

            if (String.IsNullOrEmpty(FilespaceId))
                throw new TccException("Invalid filespace ID returned in response", true);
        }
    }
}
