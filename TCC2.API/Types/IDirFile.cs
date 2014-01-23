using System;
using System.Collections.Generic;

namespace TCC2.API.Filesystem
{
    public interface IDirFile : IDirBaseEntry
    {
        IEnumerable<string> Aspects { get; }
        string MimeType { get; }
        string CheckOutMemberDisplayName { get; }
        string CheckOutMemberId { get; }
        string CheckedOutPairPath { get; }
        long Size { get; }
        bool Versionable { get; }
        bool IsWorkingCopy { get; }
    }
}