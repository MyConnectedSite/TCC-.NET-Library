using System;
using System.Collections.Generic;
using System.Linq;

namespace TCC2.API.Filesystem
{
    public partial class DirResult
    {
        private class FolderEntry : BaseEntry, IDirFolder
        {
            public FolderEntry(SerializableDirEntry entry)
                : base(entry)
            {
                IsEmpty = entry.IsEmpty.Value;
                HasACL = entry.HasACL.Value;
                HasNotifications = entry.HasNotifications.Value;

                List<IDirFile> files = new List<IDirFile>();
                List<IDirFolder> folders = new List<IDirFolder>();
                if (entry.Entries != null)
                {
                    foreach (SerializableDirEntry item in entry.Entries)
                    {
                        if (item.IsFolder.Value)
                            folders.Add(new FolderEntry(item));
                        else
                            files.Add(new FileEntry(item));
                    }
                }
                Files = files;
                Folders = folders;
            }

            public bool IsEmpty { get; protected set; }
            public bool HasACL { get; protected set; }
            public bool HasNotifications { get; protected set; }
            public IEnumerable<IDirFile> Files { get; protected set; }
            public IEnumerable<IDirFolder> Folders { get; protected set; }

            public IEnumerable<IDirBaseEntry> Entries
            {
                get
                {
                    var fileEntries = Files.Cast<IDirBaseEntry>();
                    var folderEntries = Folders.Cast<IDirBaseEntry>();
                    return folderEntries.Concat(fileEntries);
                }
            }
        }
    }
}