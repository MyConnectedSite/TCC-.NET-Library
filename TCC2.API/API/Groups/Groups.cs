using System;
using System.Collections.Generic;

namespace TCC2.API.Groups
{
    public static class GroupsApi
    {
        #region SetGroup

        public static IAsyncResult BeginSetGroup(this Session session, string groupId, string orgId, string groupName, string description, IEnumerable<string> members, AccessControlList<AccessControlEntry> acl, bool isSupportGroup, string supportDisplayName, AsyncCallback callback, object state)
        {
            SetGroup setGroup = new SetGroup(session);
            setGroup.BeginCall(groupId, orgId, groupName, description, members, acl, isSupportGroup, supportDisplayName, callback, state);
            return setGroup;
        }

        public static IAsyncResult BeginSetGroup(this Session session, string orgId, string groupName, string description, IEnumerable<string> members, AsyncCallback callback, object state)
        {
            return session.BeginSetGroup(null, orgId, groupName, description, members, null, false, null, callback, state);
        }

        public static IAsyncResult BeginSetGroup(this Session session, string groupId, string orgId, string groupName, string description, IEnumerable<string> members, AsyncCallback callback, object state)
        {
            return session.BeginSetGroup(groupId, orgId, groupName, description, members, null, false, null, callback, state);
        }

        public static SetGroupResult EndSetGroup(this Session session, IAsyncResult ar)
        {
            if (session == null)
                throw new ArgumentNullException("session");

            if (ar == null)
                throw new ArgumentNullException("ar");

            return ((SetGroup)ar).EndCall();
        }

        public static SetGroupResult SetGroup(this Session session, string groupId, string orgId, string groupName, string description, IEnumerable<string> members, AccessControlList<AccessControlEntry> acl, bool isSupportGroup, string supportDisplayName)
        {
            return new SetGroup(session).Call(groupId, orgId, groupName, description, members, acl, isSupportGroup, supportDisplayName);
        }

        public static SetGroupResult SetGroup(this Session session, string orgId, string groupName, string description, IEnumerable<string> members)
        {
            return new SetGroup(session).Call(null, orgId, groupName, description, members, null, false, null);
        }

        public static SetGroupResult SetGroup(this Session session, string groupId, string orgId, string groupName, string description, IEnumerable<string> members)
        {
            return new SetGroup(session).Call(groupId, orgId, groupName, description, members, null, false, null);
        }

        #endregion

        #region GetGroups

        public static IAsyncResult BeginGetGroups(this Session session, string orgId, AsyncCallback callback, object state)
        {
            GetGroups getGroups = new GetGroups(session);
            getGroups.BeginCall(orgId, callback, state);
            return getGroups;
        }

        public static GetGroupsResult EndGetGroups(this Session session, IAsyncResult ar)
        {
            if (session == null)
                throw new ArgumentNullException("session");

            if (ar == null)
                throw new ArgumentNullException("ar");

            return ((GetGroups)ar).EndCall();
        }

        public static GetGroupsResult GetGroups(this Session session, string orgId)
        {
            return new GetGroups(session).Call(orgId);
        }

        #endregion

        #region GetGroup

        public static IAsyncResult BeginGetGroup(this Session session, string groupId, AsyncCallback callback, object state)
        {
            GetGroup getGroup = new GetGroup(session);
            getGroup.BeginCall(groupId, callback, state);
            return getGroup;
        }

        public static GetGroupResult EndGetGroup(this Session session, IAsyncResult ar)
        {
            if (session == null)
                throw new ArgumentNullException("session");

            if (ar == null)
                throw new ArgumentNullException("ar");

            return ((GetGroup)ar).EndCall();
        }

        public static GetGroupResult GetGroup(this Session session, string groupId)
        {
            return new GetGroup(session).Call(groupId);
        }

        #endregion

        #region DeleteGroup

        public static IAsyncResult BeginDeleteGroup(this Session session, string groupId, AsyncCallback callback, object state)
        {
            DeleteGroup deleteGroup = new DeleteGroup(session);
            deleteGroup.BeginCall(groupId, callback, state);
            return deleteGroup;
        }

        public static void EndDeleteGroup(this Session session, IAsyncResult ar)
        {
            if (session == null)
                throw new ArgumentNullException("session");

            if (ar == null)
                throw new ArgumentNullException("ar");

            ((DeleteGroup)ar).EndCall();
        }

        public static void DeleteGroup(this Session session, string groupId)
        {
            new DeleteGroup(session).Call(groupId);
        }

        #endregion
    }
}