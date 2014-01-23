using System;

namespace TCC2.API.Filesystem
{
    public class CheckIn : FileOperationApiCall
    {
        protected override string Url
        {
            get { return "checkin"; }
        }

        public CheckIn(Session session)
            : base(session)
        {
        }

        public CheckIn(Session session, IRequest request)
            : base(session, request)
        {
        }
    }
}