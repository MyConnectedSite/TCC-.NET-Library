using System;
using System.Collections.Generic;

namespace TCC2.API.Filesystem
{
    public interface IDirFolder : IDirBaseEntry
    {
        bool IsEmpty { get; }
        bool HasACL { get; }
        bool HasNotifications { get; }
        IEnumerable<IDirBaseEntry> Entries { get; }
        IEnumerable<IDirFile> Files { get; }
        IEnumerable<IDirFolder> Folders { get; }
    }
}