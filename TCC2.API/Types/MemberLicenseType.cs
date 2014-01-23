namespace TCC2.API.Members
{
    public enum MemberLicenseType
    {
        [EnumFieldAlias("not_licensed")]
        NotLicensed,

        [EnumFieldAlias("visualization_license")]
        Visualization,

        [EnumFieldAlias("collaboration_license")]
        Collaboration
    }
}