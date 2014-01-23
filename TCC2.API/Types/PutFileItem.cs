using System;
using System.IO;

namespace TCC2.API.Filesystem
{
    public class PutFileItem
    {
        public PutFileItem(Stream data, long length, string filespaceId, string path)
        {
            if (data == null)
                throw new ArgumentNullException("data");

            if (length < 0)
                throw new ArgumentOutOfRangeException("length");

            if (String.IsNullOrEmpty(filespaceId))
                throw new ArgumentException("Filespace ID cannot be null or empty");

            if (String.IsNullOrEmpty(path))
                throw new ArgumentException("Path cannot be null or empty");

            Data = data;
            Length = length;
            FilespaceId = filespaceId;
            Path = path;
        }

        public PutFileItem(Stream data, long length, string entryId, string filespaceId, string path, long offset, bool commit)
            : this(data, length, filespaceId, path)
        {
            if (offset < 0)
                throw new ArgumentOutOfRangeException("offset");

            EntryId = entryId;
            Offset = offset;
            Commit = commit;
        }

        public Stream Data { get; private set; }
        public string FilespaceId { get; private set; }
        public string Path { get; private set; }
        public string EntryId { get; private set; }
        public bool Replace { get; set; }
        public string MemberId { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? ModifyTime { get; set; }
        public DateTime? VersionTime { get; set; }
        public DateTime? LocalModifyTime { get; set; }
        public bool Hidden { get; set; }
        public long? Offset { get; private set; }
        public bool? Commit { get; private set; }
        public long Length { get; private set; }

        public static PutFileItem FromFile(string file, string filespaceId, string path)
        {
            return FromStream(File.OpenRead(file), filespaceId, path);
        }

        public static PutFileItem FromStream(Stream data, string filespaceId, string path)
        {
            if (data == null)
                throw new ArgumentNullException("data");

            return new PutFileItem(data, data.Length, filespaceId, path);
        }
    }
}