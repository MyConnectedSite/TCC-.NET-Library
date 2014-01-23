using System;
using Newtonsoft.Json;

namespace TCC2.API.Organizations
{
    public enum OrganizationLicenseType
    {
        [EnumFieldAlias("trial")]
        Trial,

        [EnumFieldAlias("licensed")]
        Licensed
    }
}