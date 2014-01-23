using System;
using System.Collections.Generic;

namespace TCC2.API.Filesystem
{
    public partial class DirResult
    {
        private class FileEntry : BaseEntry, IDirFile
        {
            public FileEntry(SerializableDirEntry entry)
                : base(entry)
            {
                Aspects = entry.Aspects;
                MimeType = entry.MimeType;
                CheckOutMemberId = entry.CheckOutMemberId;
                CheckOutMemberDisplayName = entry.CheckOutMemberDisplayName;
                CheckedOutPairPath = entry.CheckedOutPairPath;
                Size = entry.Size.Value;
                Versionable = entry.Versionable.Value;
                IsWorkingCopy = entry.IsWorkingCopy.Value;
            }

            public IEnumerable<string> Aspects { get; protected set; }
            public string MimeType { get; protected set; }
            public string CheckOutMemberDisplayName { get; protected set; }
            public string CheckOutMemberId { get; protected set; }
            public string CheckedOutPairPath { get; protected set; }
            public long Size { get; protected set; }
            public bool Versionable { get; protected set; }
            public bool IsWorkingCopy { get; protected set; }
        }
    }
}