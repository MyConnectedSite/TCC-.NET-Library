using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TCC2.API
{
    public sealed partial class Session
    {
        sealed partial class PostRequest
        {
            class UrlEncodedContent : Content
            {
                public UrlEncodedContent(PostRequest request)
                    : base(request)
                {
                }

                public override string ContentType
                {
                    get { return "application/x-www-form-urlencoded"; }
                }

                public override long ContentLength
                {
                    get { return Encoding.ASCII.GetByteCount(GetBody()); }
                }

                public override void Write()
                {
                    string body = GetBody();

                    RequestLogHelper.LogRequestParameter(body);

                    byte[] bodyData = Encoding.ASCII.GetBytes(body);
                    m_Request.m_Uploader.BeginWrite(bodyData, 0, bodyData.Length, m_Request.GetSafeCallback(m_Request.FinishRequest), null);
                }

                string GetBody()
                {
                    return EncodeUrlParameters(m_Request.m_DataProvider.Parameters);
                }
            }
        }
    }
}