using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TCC2.API.Filesystem
{
    enum DirEntryType
    {
        [EnumFieldAlias("file")]
        File,

        [EnumFieldAlias("folder")]
        Folder
    }

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    class SerializableDirEntry
    {
        [JsonProperty(PropertyName = "entryId")]
        public string EntryId { get; set; }

        [JsonProperty(PropertyName = "entryName")]
        public string EntryName { get; set; }

        [JsonProperty(PropertyName = "isFolder")]
        public bool? IsFolder { get; set; }

        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(EnumTypeConverter<DirEntryType>))]
        public DirEntryType? Type { get; set; }

        [JsonProperty(PropertyName = "createTime")]
        public DateTime? CreateTime { get; set; }

        [JsonProperty(PropertyName = "modifyTime")]
        public DateTime? ModifyTime { get; set; }

        [JsonProperty(PropertyName = "attrHidden")]
        public bool? Hidden { get; set; }

        [JsonProperty(PropertyName = "createMember")]
        public string CreateMember { get; set; }

        [JsonProperty(PropertyName = "createMemberDisplayName")]
        public string CreateMemberDisplayName { get; set; }

        [JsonProperty(PropertyName = "modifyMember")]
        public string ModifyMember { get; set; }

        [JsonProperty(PropertyName = "modifyMemberdisplayname")]
        public string ModifyMemberDisplayName { get; set; }

        [JsonProperty(PropertyName = "leaf")]
        public bool? IsEmpty { get; set; }

        [JsonProperty(PropertyName = "iconCls")]
        public string IconClass { get; set; }

        [JsonProperty(PropertyName = "notifications")]
        public bool? HasNotifications { get; set; }

        [JsonProperty(PropertyName = "acl")]
        public bool? HasACL { get; set; }

        [JsonProperty(PropertyName = "entries")]
        public SerializableDirEntry[] Entries { get; set; }

        [JsonProperty(PropertyName = "size")]
        public long? Size { get; set; }

        [JsonProperty(PropertyName = "versionable")]
        public bool? Versionable { get; set; }

        [JsonProperty(PropertyName = "mimetype")]
        public string MimeType { get; set; }

        [JsonProperty(PropertyName = "workingcopy")]
        public bool? IsWorkingCopy { get; set; }

        [JsonProperty(PropertyName = "checkoutmemberid")]
        public string CheckOutMemberId { get; set; }

        [JsonProperty(PropertyName = "checkoutmemberdisplayname")]
        public string CheckOutMemberDisplayName { get; set; }

        [JsonProperty(PropertyName = "checkedoutPairPath")]
        public string CheckedOutPairPath { get; set; }

        [JsonProperty(PropertyName = "aspect")]
        public IEnumerable<string> Aspects { get; set; }

        public virtual bool IsValidFolder
        {
            get
            {
                bool valid = Type.HasValue &&
                    Type.Value == DirEntryType.Folder &&
                    IsFolder.HasValue &&
                    IsFolder.Value &&
                    Entries != null;

                if (valid)
                {
                    foreach (SerializableDirEntry entry in Entries)
                    {
                        valid &= entry.IsValidEntry;
                    }
                }
                return valid;
            }
        }

        public virtual bool IsValidFile
        {
            get
            {
                return Type.HasValue &&
                    Type.Value == DirEntryType.File &&
                    IsFolder.HasValue &&
                    !IsFolder.Value;
            }
        }

        public bool IsValidEntry
        {
            get { return IsValidFile || IsValidFolder; }
        }
    }
}