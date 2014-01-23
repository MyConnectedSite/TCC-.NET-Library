using System;
using System.Windows.Forms;

using TCC2.API;
using TCC2.API.Filesystem;

namespace UsageSample
{
    class DownloadForm : ProgressFormBase
    {
        Session m_Session;
        GetFile m_GetFile;

        string m_LocalPath;
        string m_FilespaceId;
        string m_RemoteFilePath;

        public DownloadForm(Session session, string localPath, string filespaceId, string remoteFilePath)
        {
            m_Session = session;

            m_LocalPath = localPath;
            m_FilespaceId = filespaceId;
            m_RemoteFilePath = remoteFilePath;

            Text = "Download progress";
            m_InformationLabel.Text = "Download to " + localPath;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            m_GetFile = new GetFile(m_Session);
            m_GetFile.DownloadProgressChanged += OnProgressChanged;
            m_GetFile.BeginCall(m_LocalPath, m_FilespaceId, m_RemoteFilePath, null, null, null, OnEndGetFile, null);
        }

        protected override void OnClosed(EventArgs e)
        {
            //m_Session.Abort(m_GetFile);

            //m_Session.EndGetFile(m_GetFile);
            m_GetFile.DownloadProgressChanged -= OnProgressChanged;

            base.OnClosed(e);
        }

        void OnEndGetFile(IAsyncResult ar)
        {
            if (!ar.IsCompleted)
                return;

            try
            {
                m_Session.EndGetFile(ar);

                MessageBox.Show("File was successfully downloaded to " + m_LocalPath);
            }
            catch (Exception ex)
            {
                string message = "Can't download file: " + ex.Message;
                string details = (ex.InnerException != null) ? ex.InnerException.Message : string.Empty;
                Utils.ShowError(message + "\n" + details);
            }
            finally
            {
                Close();
            }
        }
    }
}
