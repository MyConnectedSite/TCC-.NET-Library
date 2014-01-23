using System;
using System.Net;
using System.Text;
using System.Collections.Generic;

namespace TCC2.API
{
    public sealed partial class Session
    {
        sealed class GetRequest : Request
        {
            protected internal override HttpWebRequest CreateWebRequest()
            {
                StringBuilder sb = new StringBuilder();
               
                if(m_DataProvider.Url.StartsWith("/"))
                {
                    int lastSlash=m_Session.m_Url.LastIndexOf("/");
                    sb.Append(m_Session.m_Url, 0,lastSlash);
                    sb.Append(m_DataProvider.Url);
                }
                else
                    sb.Append(m_Session.m_Url).Append('/').Append(m_DataProvider.Url);

                string parameters = EncodeUrlParameters(m_DataProvider.Parameters);
                if (!String.IsNullOrEmpty(parameters))
                    sb.Append("?" + parameters);

                HttpWebRequest result = (HttpWebRequest)WebRequest.Create(new Uri(sb.ToString()));
                result.Method = "GET";
                return result;
            }

            protected override void Begin()
            {
                RequestLogHelper.LogRequestURL("GET", m_WebRequest.RequestUri);
                m_WebRequest.BeginGetResponse(GetSafeCallback(RequestSent), null);
            }

            public GetRequest(Session session)
                : base(session)
            {
            }
        }
    }
}