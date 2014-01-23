using System;
using System.Collections.Generic;
using System.Globalization;

namespace TCC2.API.Groups
{
    public class SetGroup : ApiCallBase<SetGroupResult>
    {
        public SetGroup(Session session)
            : base(session)
        {
        }

        public void BeginCall(string groupId, string orgId, string groupName, string description, IEnumerable<string> members, AccessControlList<AccessControlEntry> acl, bool isSupportGroup, string supportDisplayName, AsyncCallback callback, object state)
        {
            CheckAlreadyCalled();

            if (String.IsNullOrEmpty(orgId))
                throw new ArgumentException("Invalid organization ID");

            if (String.IsNullOrEmpty(groupId) && String.IsNullOrEmpty(groupName))
                throw new ArgumentException("Invalid group name");

            AddParameter("groupid", groupId);
            AddParameter("orgid", orgId);
            AddParameter("groupname", groupName);
            AddParameter("description", description);
            AddParameter("supportgroup", isSupportGroup);
            AddParameter("supportDisplayName", supportDisplayName);

            if (members != null)
            {
                foreach (string member in members)
                {
                    AddParameter("members", member);
                }
            }

            if (acl != null)
                AddParameters(acl.ToInputParams());

            BeginCall(callback, state);
        }

        public SetGroupResult Call(string groupId, string orgId, string groupName, string description, IEnumerable<string> members, AccessControlList<AccessControlEntry> acl, bool isSupportGroup, string supportDisplayName)
        {
            BeginCall(groupId, orgId, groupName, description, members, acl, isSupportGroup, supportDisplayName, null, null);
            return EndCall();
        }

        protected override string Url
        {
            get { return "setgroup"; }
        }

        protected override IRequest GetDefaultRequest()
        {
            return Session.CreatePostRequest();
        }
    }
}