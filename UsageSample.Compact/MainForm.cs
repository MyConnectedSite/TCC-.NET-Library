using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TCC2.API;

namespace UsageSample.Compact
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        void LoginMenuItem_Click(object sender, EventArgs e)
        {
            Enabled = false;
            try
            {
                Uri uri = new Uri(new Uri(m_UrlTextBox.Text), "tcc");
                using (Session session = new Session(uri.ToString()))
                {
                    session.Timeout = 10000;
                    session.Open(m_UserTextBox.Text, m_OrgTextBox.Text, m_PasswordTextBox.Text);
                    using (UploadForm uploadForm = new UploadForm())
                    {
                        uploadForm.CurrentSession = session;
                        uploadForm.ShowDialog();
                    }
                }
            }
            catch (Exception exception)
            {
                Utils.ShowError(exception);
            }
            finally
            {
                Enabled = true;
                Show();
                BringToFront();
            }
        }

        void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}