using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCC2.API;

namespace Ren
{
        public class Ren : ApiCallBase<ApiCallResult>
        {
            protected override string Url
            {
                get { return "ren"; }
            }

            public Ren(Session session)
                : base(session)
            {
            }

            public Ren(Session session, IRequest request)
                : base(session, request)
            {
            }

            /// <param name="filespaceId">Any valid filespace id.</param>
            /// <param name="path">A path to a file or folder.</param>
            /// <param name="newFilespaceId">Any valid filespace id.</param>
            /// <param name="newPath">The name of the destination file or folder.</param>
            /// <param name="replace">[optional; defaults to false] boolean. Flag indicating if API should replace a file if it already exists. If 'replace' is false and the file already exists, an error is returned.</param>
            /// <param name="merge">[optional; defaults to false] boolean. Flag indicating if API should recursively merge the copy of content of source folder into destination folder.</param>
            public void BeginCall(string filespaceId, string path, string newFilespaceId, string newPath, bool replace, bool? merge, AsyncCallback callback, object state)
            {
                CheckAlreadyCalled();

                if (String.IsNullOrEmpty(filespaceId))
                    throw new ArgumentException("Filespace Id cannot be null or empty", "filespaceId");

                if (path == null)
                    throw new ArgumentException("Path cannot be null", "path");

                if (String.IsNullOrEmpty(newFilespaceId))
                    throw new ArgumentException("New filespace Id cannot be null or empty", "newFilespaceId");

                if (newPath == null)
                    throw new ArgumentException("New path cannot be null", "newPath");

                AddParameter("filespaceId", filespaceId);
                AddParameter("path", path);
                AddParameter("newfilespaceid", newFilespaceId);
                AddParameter("newpath", newPath);
                AddParameter("replace", replace);
                AddParameter("merge", merge);
                
                BeginCall(callback, state);
            }

            public void Call(string filespaceId, string path, string newFilespaceId, string newPath, bool replace, bool? merge)
            {
                BeginCall(filespaceId, path, newFilespaceId, newPath, replace, merge, null, null);
                EndCall();
            }
        }
   
}
