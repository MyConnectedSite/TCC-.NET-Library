using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;

namespace TCC2.API
{
    public enum AccessLevel
    {
        [EnumFieldAlias("NONE")]
        None,

        [EnumFieldAlias("VIEWER")]
	    Viewer,

        [EnumFieldAlias("DEPOSITOR")]
	    Depositor,

        [EnumFieldAlias("EDITOR")]
        Editor,

        [EnumFieldAlias("OWNER")]
	    Owner
    }

    public enum ACEType
    {
        [EnumFieldAlias("device")]
        Device,

        [EnumFieldAlias("member")]
        Member,

        [EnumFieldAlias("group")]
        Group
    }

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class AccessControlEntry
    {
        public AccessControlEntry(string id, AccessLevel level, ACEType type)
        {
            if (String.IsNullOrEmpty(id))
                throw new ArgumentException("Id value cannot be null or empty", "id");

            if (!Enum.IsDefined(typeof(AccessLevel), level))
                throw new ArgumentException("Undefined access level: " + level);

            if (!Enum.IsDefined(typeof(ACEType), type))
                throw new ArgumentException("Undefined access level: " + level);

            Id = id;
            Level = level;
            EntryType = type;
        }

        protected AccessControlEntry()
        {
        }

        [JsonProperty(PropertyName = "ACLEntry")]
        public string Id { get; protected set; }

        [JsonProperty(PropertyName = "ACLEntryLevel")]
        public AccessLevel Level { get; protected set; }

        [JsonProperty(PropertyName = "ACLEntryType")]
        public ACEType EntryType { get; protected set; }

        public IEnumerable<ApiParameter> ToInputParams()
        {
            return new ApiParameter[]
                {
                    new ApiParameter("aclentry", Id),
                    new ApiParameter("aclentrylevel", Level.ToString().ToLower(CultureInfo.InvariantCulture)),
                    new ApiParameter("aclentrytype", EntryType.ToString().ToLower(CultureInfo.InvariantCulture))
                };
        }
    }
}