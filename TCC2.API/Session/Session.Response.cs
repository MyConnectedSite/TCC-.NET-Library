using System;
using System.IO;
using System.Net;
using System.Text;

namespace TCC2.API
{
    public sealed partial class Session
    {
        internal class Response : IResponse
        {
            HttpWebResponse m_WebResponse;

            public Response(HttpWebResponse response, bool isError)
            {
                if (response == null)
                    throw new ArgumentNullException("response");

                IsError = isError;
                m_WebResponse = response;
#if PocketPC
                Data = new AsyncStream(response.GetResponseStream());
#else
                Data = response.GetResponseStream();
#endif
            }

            public Stream Data { get; private set; }
            public bool IsError { get; private set; }

            public WebHeaderCollection Headers
            {
                get { return m_WebResponse.Headers; }
            }

            public Encoding GetDataEncoding()
            {
                try
                {
                    if (String.IsNullOrEmpty(m_WebResponse.CharacterSet))
                        return Encoding.ASCII;
                    else
                        return Encoding.GetEncoding(m_WebResponse.CharacterSet);
                }
                catch (ArgumentException)
                {
                    return Encoding.ASCII;
                }
            }
        }
    }
}