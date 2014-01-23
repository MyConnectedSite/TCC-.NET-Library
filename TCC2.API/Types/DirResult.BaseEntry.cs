using System;

namespace TCC2.API.Filesystem
{
    public partial class DirResult
    {
        private class BaseEntry : IDirBaseEntry
        {
            protected BaseEntry(SerializableDirEntry entry)
            {
                CreateMember = entry.CreateMember;
                CreateMemberDisplayName = entry.CreateMemberDisplayName;
                Id = entry.EntryId;
                Name = entry.EntryName;
                ModifyMember = entry.ModifyMember;
                ModifyMemberDisplayName = entry.ModifyMemberDisplayName;
                IconClass = entry.IconClass;
                CreateTime = entry.CreateTime.Value;
                ModifyTime = entry.ModifyTime.Value;
                Hidden = entry.Hidden.Value;
                IsFolder = entry.IsFolder.Value;
            }

            public string CreateMember { get; protected set; }
            public string CreateMemberDisplayName { get; protected set; }
            public string Id { get; protected set; }
            public string Name { get; protected set; }
            public string ModifyMember { get; protected set; }
            public string ModifyMemberDisplayName { get; protected set; }
            public string IconClass { get; protected set; }
            public DateTime CreateTime { get; protected set; }
            public DateTime ModifyTime { get; protected set; }
            public bool Hidden { get; protected set; }
            public bool IsFolder { get; protected set; }
        }
    }
}