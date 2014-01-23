using System;

namespace TCC2.API.Organizations
{
    public static class OrganizationsApi
    {
        #region GetOrganizations

        public static IAsyncResult BeginGetOrganizations(this Session session, bool includeCurrentMemberOrg, bool partnersOnly, AsyncCallback callback, object state)
        {
            GetOrganizations getOrganizations = new GetOrganizations(session);
            getOrganizations.BeginCall(includeCurrentMemberOrg, partnersOnly, callback, state);
            return getOrganizations;
        }

        public static IAsyncResult BeginGetOrganizations(this Session session, AsyncCallback callback, object state)
        {
            return session.BeginGetOrganizations(true, false, callback, state);
        }

        public static GetOrganizationsResult EndGetOrganizations(this Session session, IAsyncResult ar)
        {
            if (session == null)
                throw new ArgumentNullException("session");

            if (ar == null)
                throw new ArgumentNullException("ar");

            return ((GetOrganizations)ar).EndCall();
        }

        public static GetOrganizationsResult GetOrganizations(this Session session, bool includeCurrentMemberOrg, bool partnersOnly)
        {
            return new GetOrganizations(session).Call(includeCurrentMemberOrg, partnersOnly);
        }

        public static GetOrganizationsResult GetOrganizations(this Session session)
        {
            return session.GetOrganizations(true, false);
        }

        #endregion

        #region GetOrganization

        public static IAsyncResult BeginGetOrganization(this Session session, string orgId, AsyncCallback callback, object state)
        {
            GetOrganization getOrganization = new GetOrganization(session);
            getOrganization.BeginCall(orgId, callback, state);
            return getOrganization;
        }

        public static GetOrganizationResult EndGetOrganization(this Session session, IAsyncResult ar)
        {
            if (session == null)
                throw new ArgumentNullException("session");

            if (ar == null)
                throw new ArgumentNullException("ar");

            return ((GetOrganization)ar).EndCall();
        }

        public static GetOrganizationResult GetOrganization(this Session session, string orgId)
        {
            return new GetOrganization(session).Call(orgId);
        }

        #endregion
    }
}