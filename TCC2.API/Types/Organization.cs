using System;
using Newtonsoft.Json;
using TCC2.API.Members;

namespace TCC2.API.Organizations
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Organization : OrganizationBase
    {
        [JsonProperty(PropertyName = "comments")]
        public string Comments { get; protected set; }

        [JsonProperty(PropertyName = "defaulttimezone")]
        public string TimeZone { get; protected set; }

        [JsonProperty(PropertyName = "deletedfilesmaximumage")]
        public int? DeletedFilesMaximumAge { get; protected set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; protected set; }

        [JsonProperty(PropertyName = "guestCount")]
        public int GuestCount { get; protected set; }

        [JsonProperty(PropertyName = "guestCountLimit")]
        public int? GuestCountLimit { get; protected set; }

        [JsonProperty(PropertyName = "guestsCanLogin")]
        public bool GuestsCanLogin { get; protected set; }

        [JsonProperty(PropertyName = "guestRegistrationEnabled")]
        public bool GuestRegistrationEnabled { get; protected set; }

        [JsonProperty(PropertyName = "guestnotificationemail")]
        public string GuestNotificationEmail { get; protected set; }

        [JsonProperty(PropertyName = "membercount")]
        public int MemberCount { get; protected set; }

        [JsonProperty(PropertyName = "devicecount")]
        public int DeviceCount { get; protected set; }

        [JsonProperty(PropertyName = "devicelicenseused")]
        public int DeviceLicenceUsed { get; protected set; }

        [JsonProperty(PropertyName = "servercount")]
        public int ServerCount { get; protected set; }

        [JsonProperty(PropertyName = "deviceCountLimit")]
        public int DeviceCountLimit { get; protected set; }

        [JsonProperty(PropertyName = "readonly")]
        public bool ReadOnly { get; protected set; }

        [JsonProperty(PropertyName = "visualizationlicensecount")]
        public int VisualizationLicenseCount { get; protected set; }

        [JsonProperty(PropertyName = "collaborationlicensecount")]
        public int CollaborationLicenseCount { get; protected set; }

        [JsonProperty(PropertyName = "visualizationlicenseused")]
        public int VisualizationLicenseUsed { get; protected set; }

        [JsonProperty(PropertyName = "collaborationlicenseused")]
        public int CollaborationLicenseUsed { get; protected set; }

        [JsonProperty(PropertyName = "minimumpasswordlength")]
        public int MinimumPasswordLength { get; protected set; }

        [JsonProperty(PropertyName = "minimumpasswordnumbers")]
        public int MinimumPasswordNumbers { get; protected set; }

        [JsonProperty(PropertyName = "minimumpasswordpunctuation")]
        public int MinimumPasswordPunctuation { get; protected set; }

        [JsonProperty(PropertyName = "orgAdminsCanLogin")]
        public bool OrgAdminsCanLogin { get; protected set; }

        [JsonProperty(PropertyName = "gizmoExpansion")]
        public bool GizmoExpansion { get; protected set; }

        [JsonProperty(PropertyName = "usersCanLogin")]
        public bool UsersCanLogin { get; protected set; }

        [JsonProperty(PropertyName = "maxsyncfolders")]
        public int MaxSyncFolders { get; protected set; }

        [JsonProperty(PropertyName = "serveridnumber")]
        public int ServerIdNumber { get; protected set; }

        [JsonProperty(PropertyName = "maxversionage")]
        [JsonConverter(typeof(EmptyStringToIntConverter))]
        public int? MaxVersionAge { get; protected set; }

        [JsonProperty(PropertyName = "maxversioncount")]
        [JsonConverter(typeof(EmptyStringToIntConverter))]
        public int? MaxVersionCount { get; protected set; }

        [JsonProperty(PropertyName = "statusupdateretentioninterval")]
        [JsonConverter(typeof(EmptyStringToIntConverter))]
        public int? StatusUpdateRetentionInterval { get; protected set; }

        [JsonProperty(PropertyName = "expirationdate")]
        public DateTime? ExpirationDate { get; protected set; }

        [JsonProperty(PropertyName = "orglicensetype")]
        public OrganizationLicenseType OrgLicenseType { get; protected set; }

        [JsonProperty(PropertyName = "guestlicensetype")]
        [JsonConverter(typeof(EnumTypeConverter<MemberLicenseType>))]
        public MemberLicenseType? GuestLicenseType { get; protected set; }

        [JsonProperty(PropertyName = "licensingandbillingemail")]
        public string LicenseAndBillingEmail { get; protected set; }

        [JsonProperty(PropertyName = "systemandserviceemail")]
        public string SystemAndServiceEmail { get; protected set; }

        [JsonProperty(PropertyName = "requiretochangepassword")]
        public bool? RequireToChangePassword { get; protected set; }

        [JsonProperty(PropertyName = "devicesminimumpasswordlength")]
        public int? DeviceMinimumPasswordLength { get; protected set; }

        [JsonProperty(PropertyName = "devicesminimumpasswordnumbers")]
        public int? DeviceMinimumPasswordNumbers { get; protected set; }

        [JsonProperty(PropertyName = "devicesminimumpasswordpunctuation")]
        public int? DeviceMinimumPasswordPunctuation { get; protected set; }

        [JsonProperty(PropertyName = "devicerequiretochangepassword")]
        public bool? DeviceRequireToChangePassword { get; protected set; }

        [JsonProperty(PropertyName = "voPublicAccess")]
        public bool VOPublicAccess { get; protected set; }

        [JsonProperty(PropertyName = "orgStatus")]
        public string OrgStatus { get; protected set; }

        [JsonProperty(PropertyName = "helpURL")]
        public string HelpUrl { get; private set; }
    }
}
