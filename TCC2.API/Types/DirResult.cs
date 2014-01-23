using System;

namespace TCC2.API.Filesystem
{
    public sealed partial class DirResult : IApiCallResult
    {
        const string FileDoesNotExist = "FILE_DOES_NOT_EXIST";

        bool m_Success;
        string m_ErrorId;
        string m_Message;
        IDirBaseEntry m_Content;

        internal DirResult(SerializableDirResult dirResult)
        {
            if (dirResult == null)
                throw new ArgumentNullException("dirResult");

            m_Success = dirResult.Success;
            m_ErrorId = dirResult.ErrorId;
            m_Message = dirResult.Message;

            if (dirResult.ErrorId == FileDoesNotExist)
                Exists = false;
            else
            {
                m_Content = GetContent(dirResult);
                Exists = true;
            }
        }

        public bool Exists { get; private set; }

        public IDirBaseEntry Content
        {
            get
            {
                if (!Exists)
                    throw new InvalidOperationException("File does not exist");

                if (m_Content == null)
                    throw new InvalidOperationException("Entry has invalid format");

                return m_Content;
            }
        }

        public IDirFile ContentAsFile
        {
            get { return Content as IDirFile; }
        }

        public IDirFolder ContentAsFolder
        {
            get { return Content as IDirFolder; }
        }

        static IDirBaseEntry GetContent(SerializableDirResult dirResult)
        {
            if (dirResult.IsValidFile)
                return new FileEntry(dirResult.Entries[0]);

            if (dirResult.IsValidFolder)
                return new FolderEntry(dirResult);

            return null;
        }

        void IApiCallResult.Validate(IRequestDataProvider provider)
        {
            if (Exists)
            {
                ApiCallResult.Validate(provider, m_Success, m_ErrorId, m_Message);
                if (m_Content == null)
                    throw new TccException("Entry has invalid format", true);
            }
        }
    }
}
