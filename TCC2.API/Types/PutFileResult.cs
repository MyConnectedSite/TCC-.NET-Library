using System;
using System.Linq;
using Newtonsoft.Json;

namespace TCC2.API.Filesystem
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class PutFileResult : PutFileEntry, IApiCallResult
    {
        IRequestDataProvider m_DataProvider;

        [JsonProperty(PropertyName = "success", Required = Required.Always)]
        bool m_Success = false;

        [JsonProperty(PropertyName = "errorid")]
        string m_ErrorId = null;

        [JsonProperty(PropertyName = "message")]
        string m_Message = null;

        [JsonProperty(PropertyName = "data")]
        public PutFileEntry[] Data { get; private set; }

        public bool IsSingleEntry
        {
            get { return Data == null; }
        }

        public PutFileItem CreateNextPutFileItem(long partLength, bool isLast)
        {
            if (m_DataProvider == null)
                throw new InvalidOperationException("Data provider is not set for this instance");

            if (m_DataProvider.Attachments.Take(2).Count() > 1 || !IsSingleEntry)
                throw new InvalidOperationException("This method cannot be called for response to multiple files upload");

            bool committed = m_DataProvider.GetParameterValue<bool>("commit");
            if (committed)
                throw new InvalidOperationException("Corresponding file already uploaded");

            string filespaceId = m_DataProvider.GetParameterValue<string>("filespaceid");
            string path = m_DataProvider.GetParameterValue<string>("path");
            long offset = m_DataProvider.GetParameterValue<long>("startPosition");
            BinaryAttachment previousPart = m_DataProvider.Attachments.First();

            return new PutFileItem(previousPart, partLength, EntryId, filespaceId, path, offset + previousPart.Length, isLast);
        }

        static void ValidateEntry(PutFileEntry entry)
        {
            if (String.IsNullOrEmpty(entry.EntryId))
                throw new TccException("Invalid entry ID returned in response", true);

            if (String.IsNullOrEmpty(entry.Path))
                throw new TccException("Invalid path returned in response", true);
        }

        void IApiCallResult.Validate(IRequestDataProvider provider)
        {
            ApiCallResult.Validate(provider, m_Success, m_ErrorId, m_Message);

            int attachmentsCount = provider.Attachments.Count();
            if (attachmentsCount == 1 && IsSingleEntry)
                ValidateEntry(this);
            else if (EntryId == null && Path == null)
            {
                if (attachmentsCount != Data.Length)
                    throw new TccException("Invalid entries count in response", true);

                for (int i = 0; i < Data.Length; i++)
                {
                    ValidateEntry(Data[i]);
                }
            }
            else
                throw new TccException("Invalid response format", true);

            m_DataProvider = provider;
        }
    }
}
