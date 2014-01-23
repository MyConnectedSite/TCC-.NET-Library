using System;
using System.IO;
using System.Windows.Forms;

using TCC2.API;
using TCC2.API.Filesystem;

namespace UsageSample
{
    class UploadForm : ProgressFormBase
    {
        internal class UploadEventArgs : EventArgs
        {
            public readonly bool Success;
            public readonly string FilespaceId;
            public readonly string TargetFolder;

            public UploadEventArgs(bool success, string filespaceId, string targetFolder)
            {
                Success = success;
                FilespaceId = filespaceId;
                TargetFolder = targetFolder;
            }
        }

        Session m_Session;
        PutFile m_PutFile;

        string m_LocalPath;
        string m_FilespaceId;
        string m_TargetFolder;
        string m_TargetFile;

        public UploadForm(Session session, string localPath, string filespaceId, string targetFolder, string targetFile)
        {
            m_Session = session;

            m_LocalPath = localPath;
            m_FilespaceId = filespaceId;
            m_TargetFolder = targetFolder;
            m_TargetFile = targetFile;

            Text = "Upload progress";
            m_InformationLabel.Text = "Upload to " + TargetPath;
        }

        public event EventHandler<UploadEventArgs> Finished;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            m_PutFile = new PutFile(m_Session);
            m_PutFile.UploadProgressChanged += OnProgressChanged;

            PutFileItem file = PutFileItem.FromFile(m_LocalPath, m_FilespaceId, TargetPath);
            file.Replace = true;

            m_PutFile.BeginCall(file, null, null, OnEndPutFile, null);
        }

        protected override void OnClosed(EventArgs e)
        {
            //m_Session.Abort(m_PutFile);

            //m_Session.EndPutFile(m_PutFile);
            m_PutFile.UploadProgressChanged -= OnProgressChanged;

            base.OnClosed(e);
        }

        string TargetPath
        {
            get
            {
                return Path.Combine(m_TargetFolder, m_TargetFile)
                           .Replace(Path.DirectorySeparatorChar, '/');
            }
        }

        void OnEndPutFile(IAsyncResult ar)
        {
            if (!ar.IsCompleted)
                return;

            try
            {
                m_Session.EndPutFile(ar);

                NotifyAboutFinish(true);

                MessageBox.Show("File was successfully uploaded to " + TargetPath);
            }
            catch (Exception ex)
            {
                NotifyAboutFinish(false);

                string message = "Can't upload file: " + ex.Message;
                string details = (ex.InnerException != null) ? ex.InnerException.Message : string.Empty;
                Utils.ShowError(message + "\n" + details);
            }
            finally
            {
                Close();
            }
        }

        void NotifyAboutFinish(bool success)
        {
            if (Finished != null)
                Finished(this, new UploadEventArgs(success, m_FilespaceId, m_LocalPath));
        }
    }
}
