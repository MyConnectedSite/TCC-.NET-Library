using System;
using System.IO;
using System.Net;

namespace TCC2.API
{
    public abstract class ApiCallBase<T> : ApiCallBase where T : IApiCallResult
    {
        protected override Stream CreateResultStream()
        {
#if PocketPC
            return new AsyncMemoryStream();
#else
            return new MemoryStream();
#endif
        }

        protected ApiCallBase(Session session)
            : base(session)
        {
        }

        protected ApiCallBase(Session session, IRequest request)
            : base(session, request)
        {
        }

        public virtual T EndCall()
        {
            try
            {
                End();
                T result = ProcessResponseAsText<T>();
                Validate(result);
                return result;
            }
            catch (TccException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new TccException(GetType().Name + " API call failed", e);
            }
        }

        public string EndCallAndGetResponseText()
        {
            try
            {
                End();
                return GetResponseAsText();
            }
            catch (TccException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new TccException(GetType().Name + " API call failed", e);
            }
        }
    }
}