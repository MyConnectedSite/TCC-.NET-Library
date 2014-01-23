using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TCC2.API.Filesystem
{
    public class MkDir : ApiCallBase<MkDirResult>
    {
        protected override string Url
        {
            get { return "mkdir"; }
        }

        public MkDir(Session session)
            : base(session)
        {
        }

        public MkDir(Session session, IRequest request)
            : base(session, request)
        {
        }

        public void BeginCall(string filespaceId, IEnumerable<string> paths, bool force, bool hidden, string clientType, AsyncCallback callback, object state)
        {
            CheckAlreadyCalled();

            if (String.IsNullOrEmpty(filespaceId))
                throw new ArgumentException("Filespace ID value cannot be null or empty", "filespaceId");

            if (paths == null)
                throw new ArgumentNullException("paths");

            if (!paths.Any())
                throw new ArgumentException("No path specified");

            int pathsCount = 0;
            foreach (string path in paths)
            {
                AddParameter("path", path);
                pathsCount++;
            }

            AddParameter("filespaceid", filespaceId);
            AddParameter("force", force);
            AddParameter("hidden", hidden);
            AddParameter("clienttype", clientType);
            BeginCall(callback, state);
        }

        public MkDirResult Call(string filespaceId, IEnumerable<string> paths, bool force, bool hidden, string clientType)
        {
            BeginCall(filespaceId, paths, force, hidden, clientType, null, null);
            return EndCall();
        }

        protected override IRequest GetDefaultRequest()
        {
            return Session.CreatePostRequest();
        }
    }
}