using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TCC2.API;
using TCC2.API.Filesystem;

namespace UsageSample.Compact
{
    public partial class UploadForm : Form
    {
        public UploadForm()
        {
            InitializeComponent();
        }

        public Session CurrentSession { get; set; }

        void LogoutMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        void UploadMenuItem_Click(object sender, EventArgs e)
        {
            m_ProgressBar.Value = 0;
            SetControlsState(false);
            m_StatusBar.Text = "Uploading file...";

            try
            {
                string destinationFileName = "/" + Path.GetFileName(m_OpenFileDialog.FileName);
                PutFileItem fileToUpload = PutFileItem.FromFile(m_OpenFileDialog.FileName, (string)m_FilespaceComboBox.SelectedValue, destinationFileName);
                fileToUpload.Replace = true;

                PutFile putFileCall = new PutFile(CurrentSession);
                putFileCall.Timeout = 20000; // this will override default session timeout
                putFileCall.UploadProgressChanged += new EventHandler<ProgressEventArgs>(UploadProgressHandler).BindTo(this);
                putFileCall.BeginCall(fileToUpload, null, null, new AsyncCallback(PutFileHandler).BindTo(this), fileToUpload.Data);
            }
            catch (TccException exception)
            {
                Utils.ShowError(exception);
                SetControlsState(true);
                m_StatusBar.Text = "Upload failed";
            }
        }

        void BrowseButton_Click(object sender, EventArgs e)
        {
            if (m_OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                m_FileTextBox.Text = m_OpenFileDialog.FileName;
                m_UploadMenuItem.Enabled = true;
            }
        }

        void UploadForm_Activated(object sender, EventArgs e)
        {
            Activated -= UploadForm_Activated;
            if (CurrentSession != null)
            {
                m_StatusBar.Text = "Getting filespaces...";
                CurrentSession.BeginGetFilespaces(null, null, new AsyncCallback(GetFilespacesHandler).BindTo(this), null);
            }
        }

        void GetFilespacesHandler(IAsyncResult ar)
        {
            try
            {
                GetFilespacesResult apiResult = CurrentSession.EndGetFilespaces(ar);
                if (apiResult.Filespaces.Length > 0)
                {
                    m_FilespaceComboBox.DataSource = apiResult.Filespaces;
                    m_FilespaceComboBox.Enabled = true;
                    m_BrowseButton.Enabled = true;
                    m_StatusBar.Text = "Done";
                }
                else m_StatusBar.Text = "No filespaces available";
            }
            catch (TccException e)
            {
                Utils.ShowError(e);
                DialogResult = DialogResult.Abort;
            }
        }

        void UploadProgressHandler(object sender, ProgressEventArgs e)
        {
            m_ProgressBar.Value = (int)e.Percent;
        }

        void PutFileHandler(IAsyncResult ar)
        {
            try
            {
                ((Stream)ar.AsyncState).Close(); // close file stream
                CurrentSession.EndPutFile(ar);
                m_StatusBar.Text = "Upload complete";
            }
            catch (TccException e)
            {
                Utils.ShowError(e);
                m_StatusBar.Text = "Upload failed";
            }
            SetControlsState(true);
        }

        void SetControlsState(bool value)
        {
            m_LogoutMenuItem.Enabled = value;
            m_UploadMenuItem.Enabled = value;
            m_BrowseButton.Enabled = value;
            m_FilespaceComboBox.Enabled = value;
            m_ProgressBar.Visible = !value;
        }
    }
}