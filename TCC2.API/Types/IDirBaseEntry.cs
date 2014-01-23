using System;

namespace TCC2.API.Filesystem
{
    public interface IDirBaseEntry
    {
        string CreateMember { get; }
        string CreateMemberDisplayName { get; }
        string Id { get; }
        string Name { get; }
        string ModifyMember { get; }
        string ModifyMemberDisplayName { get; }
        string IconClass { get; }
        DateTime CreateTime { get; }
        DateTime ModifyTime { get; }
        bool Hidden { get; }
        bool IsFolder { get; }
    }
}
