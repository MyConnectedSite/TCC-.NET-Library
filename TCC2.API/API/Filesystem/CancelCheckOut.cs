using System;

namespace TCC2.API.Filesystem
{
    public class CancelCheckOut : FileOperationApiCall
    {
        protected override string Url
        {
            get { return "cancelcheckout"; }
        }

        public CancelCheckOut(Session session)
            : base(session)
        {
        }

        public CancelCheckOut(Session session, IRequest request)
            : base(session, request)
        {
        }
    }
}