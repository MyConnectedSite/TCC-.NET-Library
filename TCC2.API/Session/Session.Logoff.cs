using System;

namespace TCC2.API
{
    public partial class Session
    {
        private class Logoff : ApiCallBase<ApiCallResult>
        {
            protected override string Url
            {
                get { return "logoff"; }
            }

            public Logoff(Session session)
                : base(session)
            {
            }

            //TODO: remove 'new' modifier when ApiCallBase.BeginCall() method will be renamed
            public new void BeginCall(AsyncCallback callback, object state)
            {
                CheckAlreadyCalled();
                base.BeginCall(callback, state);
            }

            protected override IRequest GetDefaultRequest()
            {
                return Session.CreatePostRequest();
            }
        }
    }
}