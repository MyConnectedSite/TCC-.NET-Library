using System;
using System.Globalization;

namespace TCC2.API
{
    public partial class Session
    {
        private class Login : ApiCallBase<LogonResult>
        {
            protected override string Url
            {
                get { return "login"; }
            }

            protected override bool LoginRequired
            {
                get { return false; }
            }

            public Login(Session session)
                : base(session)
            {
            }

            public void BeginCall(string userName, string orgName, string password, string appKey, SessionOpenMode? mode, string redirUrl, bool? forceGmt, AsyncCallback callback, object state)
            {
                CheckAlreadyCalled();

                if (String.IsNullOrEmpty(userName))
                    throw new ArgumentException("User name cannot be null or empty string", "userName");

                if (String.IsNullOrEmpty(orgName))
                    throw new ArgumentException("Org name cannot be null or empty string", "orgName");

                if (password == null)
                    throw new ArgumentNullException("password");

                if (mode.HasValue)
                    AddParameter("mode", mode.Value.ToString().ToLower(CultureInfo.InvariantCulture));

                AddParameter("username", userName);
                AddParameter("orgname", orgName);
                AddParameter("password", password);
                AddParameter("applicationkey", appKey);
                AddParameter("redir", redirUrl);
                AddParameter("forcegmt", forceGmt);
                BeginCall(callback, state);
            }

            protected override IRequest GetDefaultRequest()
            {
                return Session.CreatePostRequest();
            }
        }
    }
}