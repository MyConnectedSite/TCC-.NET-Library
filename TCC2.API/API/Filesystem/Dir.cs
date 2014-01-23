using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;

namespace TCC2.API.Filesystem
{
    public enum FileMaskRelation
    {
        Or,
        And
    }

    public class Dir : ApiCallBase<DirResult>
    {
        protected override string Url
        {
            get { return "dir"; }
        }

        public Dir(Session session)
            : base(session)
        {
        }

        public Dir(Session session, IRequest request)
            : base(session, request)
        {
        }

        public void BeginCall(string filespaceId, string path, bool recursive, IEnumerable<string> fileMaskList, FileMaskRelation? fileMaskRelation, bool? filterFolders, bool wantAspects, bool wantHidden, AsyncCallback callback, object state)
        {
            CheckAlreadyCalled();

            if (String.IsNullOrEmpty(filespaceId))
                throw new ArgumentException("Filespace ID value cannot be null or empty", "filespaceId");

            if (String.IsNullOrEmpty(path))
                throw new ArgumentException("Path not specified", "path");

            AddParameter("filespaceid", filespaceId);
            AddParameter("path", path);
            AddParameter("recursive", recursive);
            AddParameter("filterfolders", filterFolders);
            AddParameter("wantaspects", wantAspects);
            AddParameter("wanthidden", wantHidden);

            if (fileMaskList != null)
            {
                foreach (string fileMask in fileMaskList)
                {
                    AddParameter("filemasklist", fileMask);
                }
            }

            if (fileMaskRelation.HasValue)
                AddParameter("filemaskrelation", fileMaskRelation.Value.ToString().ToLower(CultureInfo.InvariantCulture));

            BeginCall(callback, state);
        }

        public DirResult Call(string filespaceId, string path, bool recursive, IEnumerable<string> fileMaskList, FileMaskRelation? fileMaskRelation, bool? filterFolders, bool wantAspects, bool wantHidden)
        {
            BeginCall(filespaceId, path, recursive, fileMaskList, fileMaskRelation, filterFolders, wantAspects, wantHidden, null, null);
            return EndCall();
        }

        public override DirResult EndCall()
        {
            try
            {
                End();
                DirResult result = new DirResult(ProcessResponseAsText<SerializableDirResult>());
                Validate(result);
                return result;
            }
            catch (TccException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new TccException("Dir API call failed", e);
            }
        }
    }
}