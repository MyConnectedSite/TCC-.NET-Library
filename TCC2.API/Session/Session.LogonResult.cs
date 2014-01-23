using System;
using Newtonsoft.Json;

namespace TCC2.API
{
    public partial class Session
    {
        [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
        private class LogonResult : ApiCallResult
        {
            [JsonProperty(PropertyName = "ticket")]
            public string Ticket { get; protected set; }

            [JsonProperty(PropertyName = "currenttime")]
            public DateTime? CurrentTime { get; protected set; }

            [JsonProperty(PropertyName = "creatorIpAddress")]
            public string CreatorIpAddress { get; protected set; }

            [JsonProperty(PropertyName = "homeSite")]
            public string HomeSite { get; protected set; }

            [JsonProperty(PropertyName = "protocol")]
            public string Protocol { get; protected set; }

            [JsonProperty(PropertyName = "username")]
            public string UserName { get; protected set; }

            [JsonProperty(PropertyName = "orgname")]
            public string OrgName { get; protected set; }

            [JsonProperty(PropertyName = "reason")]
            public string Reason { get; protected set; }

            protected override void ValidateInstance(IRequestDataProvider provider)
            {
                if (!String.IsNullOrEmpty(Reason))
                    throw new TccException("Login failed: " + Reason, ErrorId);

                base.ValidateInstance(provider);

                if (String.IsNullOrEmpty(Ticket))
                    throw new TccException("Invalid ticket value returned", true);
            }
        }
    }
}
