using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TCC2.API
{
    public sealed partial class Session
    {
        sealed partial class PostRequest
        {
            class FormDataContent : Content
            {
                IEnumerator<ApiParameter> m_ParametersEnumerator;
                IEnumerator<BinaryAttachment> m_AttachmentsEnumerator;

                byte[] m_Buffer;
                string m_Boundary;
                string m_NewLine = String.Empty;

                const string AttachmentContentType = "Content-Type: application/octet-stream\r\n\r\n";

                public FormDataContent(PostRequest request)
                    : base(request)
                {
                    m_Boundary = Guid.NewGuid().ToString("N");
                }

                public override string ContentType
                {
                    get { return String.Format(CultureInfo.InvariantCulture, "multipart/form-data; boundary=\"{0}\"", m_Boundary); }
                }

                public override long ContentLength
                {
                    get
                    {
                        IRequestDataProvider dataProvider = m_Request.m_DataProvider;
                        if (dataProvider == null)
                            throw new InvalidOperationException("IRequestDataProvider is not set for this instance");

                        long result = 0L;
                        int boundary = Encoding.UTF8.GetByteCount(String.Format(CultureInfo.InvariantCulture, "--{0}\r\n", m_Boundary));
                        int paramsCount = 0, attachmentsCount = 0;

                        foreach (BinaryAttachment attachment in dataProvider.Attachments)
                        {
                            string header = GetContentDispositionForAttachment(attachment) + AttachmentContentType;
                            result += Encoding.UTF8.GetByteCount(header) + attachment.Length;
                            attachmentsCount++;
                        }

                        foreach (ApiParameter parameter in dataProvider.Parameters)
                        {
                            string header = GetContentDispositionForParameter(parameter);
                            result += Encoding.UTF8.GetByteCount(header);
                            paramsCount++;
                        }

                        if ((attachmentsCount == 0) && (paramsCount == 0))
                            return 0L;

                        result += boundary * (paramsCount + attachmentsCount + 1) + Encoding.UTF8.GetByteCount("--") + attachmentsCount * Encoding.UTF8.GetByteCount("\r\n");
                        return result;
                    }
                }

                public override void Write()
                {
                    m_ParametersEnumerator = m_Request.m_DataProvider.Parameters.GetEnumerator();
                    m_AttachmentsEnumerator = m_Request.m_DataProvider.Attachments.GetEnumerator();

                    m_Buffer = new byte[8192];
                    WriteParameter(null);
                }

                void WriteParameter(IAsyncResult state)
                {
                    if (state != null)
                        m_Request.m_Uploader.EndWrite(state);

                    if (m_ParametersEnumerator.MoveNext())
                    {
                        ApiParameter current = m_ParametersEnumerator.Current;
                        string paramDataString = String.Format(CultureInfo.InvariantCulture, "--{0}\r\n", m_Boundary) + GetContentDispositionForParameter(current);

                        RequestLogHelper.LogRequestParameter(paramDataString);

                        byte[] paramData = Encoding.UTF8.GetBytes(paramDataString);
                        m_Request.m_Uploader.BeginWrite(paramData, 0, paramData.Length, m_Request.GetSafeCallback(WriteParameter), null);
                    }
                    else
                        WriteAttachmentPreamble(null);
                }

                void WriteAttachmentPreamble(IAsyncResult state)
                {
                    if (state != null)
                        m_Request.m_Uploader.EndWrite(state);

                    if (m_AttachmentsEnumerator.MoveNext())
                    {
                        BinaryAttachment current = m_AttachmentsEnumerator.Current;
                        string preambleString = new StringBuilder()
                                            .Append(m_NewLine)
                                            .Append("--")
                                            .Append(m_Boundary)
                                            .Append("\r\n")
                                            .Append(GetContentDispositionForAttachment(current))
                                            .Append(AttachmentContentType)
                                            .ToString();

                        RequestLogHelper.LogRequestParameter(preambleString);
                        byte[] preamble = Encoding.UTF8.GetBytes(preambleString);
                        m_Request.m_Uploader.BeginWrite(preamble, 0, preamble.Length, m_Request.GetSafeCallback(ReadAttachmentChunk), null);
                    }
                    else
                    {
                        byte[] tail = Encoding.UTF8.GetBytes(String.Format(CultureInfo.InvariantCulture, "{0}--{1}--\r\n", m_NewLine, m_Boundary));
                        m_Request.m_Uploader.BeginWrite(tail, 0, tail.Length, m_Request.GetSafeCallback(m_Request.FinishRequest), null);
                    }
                }

                void ReadAttachmentChunk(IAsyncResult state)
                {
                    m_Request.m_Uploader.EndWrite(state);
                    m_AttachmentsEnumerator.Current.BeginRead(m_Buffer, 0, m_Buffer.Length, m_Request.GetSafeCallback(WriteAttachmentChunk), null);
                }

                void WriteAttachmentChunk(IAsyncResult state)
                {
                    int bytesRead = m_AttachmentsEnumerator.Current.EndRead(state);
                    if (bytesRead == 0)
                    {
                        m_NewLine = "\r\n";
                        WriteAttachmentPreamble(null);
                        return;
                    }
                    m_Request.m_Uploader.BeginWrite(m_Buffer, 0, bytesRead, m_Request.GetSafeCallback(ReadAttachmentChunk), null);
                }

                static string GetContentDispositionForParameter(ApiParameter parameter)
                {
                    return String.Format(CultureInfo.InvariantCulture,
                        "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}\r\n", parameter.Name, parameter.Value);
                }

                static string GetContentDispositionForAttachment(BinaryAttachment attachment)
                {
                    return String.Format(CultureInfo.InvariantCulture,
                        "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n", attachment.Name, attachment.FileName);
                }
            }
        }
    }
}