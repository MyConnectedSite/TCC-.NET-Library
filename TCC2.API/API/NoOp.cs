using System;
using System.Collections.Generic;
using System.Text;

namespace TCC2.API
{
    public class NoOp : ApiCallBase<ApiCallResult>
    {
        protected override string Url
        {
            get { return "noop"; }
        }

        public NoOp(Session session)
            : base(session)
        {
        }

        public NoOp(Session session, IRequest request)
            : base(session, request)
        {
        }

        public void BeginCall(int timeout, AsyncCallback callback, object state)
        {
            CheckAlreadyCalled();
            AddParameter("timeout", timeout);
            BeginCall(callback, state);
        }

        public void Call(int timeout)
        {
            BeginCall(timeout, null, null);
            EndCall();
        }
    }
}
