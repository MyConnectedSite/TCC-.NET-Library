using System;
#if !PocketPC
using System.Security.Permissions;
using System.Runtime.Serialization;
#endif

namespace TCC2.API
{
    [Serializable]
    public class TccException : Exception
    {
        public TccException()
        {
        }

        public TccException(string message)
            : this(message, false)
        {
        }

        public TccException(string message, bool isApiError)
            : base(message)
        {
            IsApiError = isApiError;
        }

        public TccException(string message, Exception innerException)
            : base(message == null ? "TCC API call failed" : message, innerException)
        {
            IsApiError = false;
        }

        public TccException(string message, string errorId)
            : base(message)
        {
            IsApiError = true;
            ErrorId = errorId;
        }

#if !PocketPC
        protected TccException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            ErrorId = info.GetString("ErrorId");
            IsApiError = info.GetBoolean("IsApiError");
        }
#endif

        public string ErrorId { get; private set; }
        public bool IsApiError { get; private set; }

#if !PocketPC
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("ErrorId", ErrorId);
            info.AddValue("IsApiError", IsApiError);
        }
#endif
    }
}
