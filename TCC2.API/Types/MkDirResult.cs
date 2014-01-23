using System;
using System.Linq;
using Newtonsoft.Json;

namespace TCC2.API.Filesystem
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class MkDirResult : MkDirEntry, IApiCallResult
    {
        [JsonProperty(PropertyName = "success", Required = Required.Always)]
        bool m_Success = false;

        [JsonProperty(PropertyName = "errorid")]
        string m_ErrorId = null;

        [JsonProperty(PropertyName = "message")]
        string m_Message = null;

        [JsonProperty(PropertyName = "entries")]
        public MkDirEntry[] Entries { get; private set; }

        public bool IsSingleEntry
        {
            get { return Entries == null; }
        }

        static void ValidateEntry(MkDirEntry entry)
        {
            if (String.IsNullOrEmpty(entry.Path))
                throw new TccException("Invalid path returned in response", true);

            if (String.IsNullOrEmpty(entry.EntryId))
                throw new TccException("Invalid entry ID returned in response", true);
        }

        void IApiCallResult.Validate(IRequestDataProvider provider)
        {
            ApiCallResult.Validate(provider, m_Success, m_ErrorId, m_Message);

            int expectedEntriesCount = provider.GetParametersCount("path");

            if (expectedEntriesCount == 1 && IsSingleEntry)
                ValidateEntry(this);
            else if (EntryId == null && Path == null)
            {
                if (expectedEntriesCount != Entries.Length)
                    throw new TccException("Invalid entries count in response", true);

                for (int i = 0; i < Entries.Length; i++)
                {
                    ValidateEntry(Entries[i]);
                }
            }
            else
                throw new TccException("Invalid response format", true);
        }
    }
}
