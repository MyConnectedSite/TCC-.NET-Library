using System;
using System.Globalization;
using System.Collections.Generic;

namespace TCC2.API.Filesystem
{
    public class SetFilespace : FilesystemApiCall<SetFilespaceResult>
    {
        protected override string Url
        {
            get { return "setfilespace"; }
        }

        public SetFilespace(Session session)
            : base(session)
        {
        }

        public SetFilespace(Session session, IRequest request)
            : base(session, request)
        {
        }

        /// <param name="orgId">The organization ID to create/update the group for</param>
        /// <param name="filespaceId">The filespaceid to update; if blank, that means create a new file space id but the calling member must be an Admin or be a fileSpaceCreator</param>
        /// <param name="shortName">Any alphanumeric (no punctuation or spaces). The shortname of the file space; unique within an organization.</param>
        /// <param name="title">The title of the file space.</param>
        /// <param name="description">The description of the file space.</param>
        /// <param name="filespaceType">The type of filespace. Available values: regular and tripspace</param>
        public void BeginCall(string orgId, string filespaceId, string shortName, string title, string description, string filespaceType, int? deletedFilesMaximumAge, bool? mailInEnabled, IEnumerable<string> acceptableSenders, int? maxVersionAge, int? maxVersionCount, AccessControlList<AccessControlEntry> acl, AsyncCallback callback, object state)
        {
            CheckAlreadyCalled();

            if (String.IsNullOrEmpty(orgId))
                throw new ArgumentException("Organization ID cannot be null or empty", "orgId");

            if (String.IsNullOrEmpty(shortName))
                throw new ArgumentException("Filespace short name cannot be null or empty", "shortName");

            if (String.IsNullOrEmpty(title))
                throw new ArgumentException("Filespace title cannot be null or empty", "title");

            if (deletedFilesMaximumAge.HasValue && deletedFilesMaximumAge.Value < 0)
                throw new ArgumentOutOfRangeException("deletedFilesMaximumAge");

            if (maxVersionAge.HasValue && maxVersionAge.Value < 0)
                throw new ArgumentOutOfRangeException("maxVersionAge");

            if (maxVersionCount.HasValue && maxVersionCount.Value < 0)
                throw new ArgumentOutOfRangeException("maxVersionCount");

            AddParameter("orgid", orgId);
            AddParameter("filespaceid", filespaceId);
            AddParameter("shortname", shortName);
            AddParameter("title", title);
            AddParameter("description", description);
            AddParameter("filespacetype", filespaceType);
            AddParameter("deletedfilesmaximumage", deletedFilesMaximumAge);
            AddParameter("mailinenabled", mailInEnabled);
            AddParameter("maxversionage", maxVersionAge);
            AddParameter("maxversioncount", maxVersionCount);

            if (acl != null)
                AddParameters(acl.ToInputParams());

            if (acceptableSenders != null)
            {
                foreach (string acceptableSender in acceptableSenders)
                {
                    AddParameter("acceptablesenders", acceptableSender);
                }
            }

            BeginCall(callback, state);
        }

        public void BeginCall(string orgId, string filespaceId, string shortName, string title, string description, string filespaceType, AsyncCallback callback, object state)
        {
            BeginCall(orgId, filespaceId, shortName, title, description, filespaceType, null, null, null, null, null, null, callback, state);
        }

        public SetFilespaceResult Call(string orgId, string filespaceId, string shortName, string title, string description, string filespaceType, int? deletedFilesMaximumAge, bool? mailInEnabled, IEnumerable<string> acceptableSenders, int? maxVersionAge, int? maxVersionCount, AccessControlList<AccessControlEntry> acl)
        {
            BeginCall(orgId, filespaceId, shortName, title, description, filespaceType, deletedFilesMaximumAge, mailInEnabled, acceptableSenders, maxVersionAge, maxVersionCount, acl, null, null);
            return EndCall();
        }

        public SetFilespaceResult Call(string orgId, string filespaceId, string shortName, string title, string description, string filespaceType)
        {
            BeginCall(orgId, filespaceId, shortName, title, description, filespaceType, null, null);
            return EndCall();
        }
    }
}