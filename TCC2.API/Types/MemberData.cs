using System;
using Newtonsoft.Json;

namespace TCC2.API.Members
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class MemberData : LoginAccountData
    {
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; protected set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; protected set; }

        [JsonProperty(PropertyName = "memberId")]
        public string MemberId { get; protected set; }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; protected set; }

        [JsonProperty(PropertyName = "bbpin")]
        public string BlackBerryPin { get; protected set; }

        [JsonProperty(PropertyName = "comments")]
        public string Comments { get; protected set; }

        [JsonProperty(PropertyName = "licensetype")]
        [JsonConverter(typeof(EnumTypeConverter<MemberLicenseType>))]
        public MemberLicenseType LicenseType { get; protected set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; protected set; }

        [JsonProperty(PropertyName = "division")]
        public string Division { get; protected set; }

        [JsonProperty(PropertyName = "emailAddress")]
        public string EmailAddress { get; protected set; }

        [JsonProperty(PropertyName = "gmtoffset")]
        public int GmtOffset { get; protected set; }

        [JsonProperty(PropertyName = "homeSite")]
        public string HomeSite { get; protected set; }

        [JsonProperty(PropertyName = "phoneNumbers")]
        public string PhoneNumbers { get; protected set; }

        [JsonProperty(PropertyName = "sms")]
        public string Sms { get; protected set; }
    }
}