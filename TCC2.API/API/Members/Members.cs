using System;

namespace TCC2.API.Members
{
    public static class MembersApi
    {
        #region GetMember

        public static IAsyncResult BeginGetMember(this Session session, string memberId, AsyncCallback callback, object state)
        {
            GetMember getMember = new GetMember(session);
            getMember.BeginCall(memberId, callback, state);
            return getMember;
        }

        public static GetMemberResult EndGetMember(this Session session, IAsyncResult ar)
        {
            if (session == null)
                throw new ArgumentNullException("session");

            if (ar == null)
                throw new ArgumentNullException("ar");

            return ((GetMember)ar).EndCall();
        }

        public static GetMemberResult GetMember(this Session session, string memberId)
        {
            return new GetMember(session).Call(memberId);
        }

        #endregion
    }
}