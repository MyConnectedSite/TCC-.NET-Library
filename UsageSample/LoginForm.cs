using System;
using System.Windows.Forms;

using TCC2.API;

using UsageSample.Properties;

namespace UsageSample
{
    public partial class LoginForm : Form
    {
        const int MillisecondsInSecond = 1000;
        Session m_Session;

        public LoginForm()
        {
            InitializeComponent();
        }

        public Session Session
        {
            get
            {
                return m_Session;
            }
        }

        void UpdateOkButtonState()
        {
            bool textBoxesAreFilled = (m_MemberTextBox.Text.Length > 0 && m_OrgTextBox.Text.Length > 0 && m_PasswordTextBox.Text.Length > 0);
            bool serverSelected = (m_ServersComboBox.Text.Length > 0);
            m_OkButton.Enabled = (textBoxesAreFilled && serverSelected);
        }

        private void LoadSettings()
        {
            m_MemberTextBox.Text = Settings.Default.Login;
            m_OrgTextBox.Text = Settings.Default.Organization;
            m_ServersComboBox.Text = Settings.Default.Server;
            m_TimeoutUpDown.Value = Settings.Default.Timeout;
        }

        private void SaveSettings()
        {
            Settings.Default.Login = m_MemberTextBox.Text;
            Settings.Default.Organization = m_OrgTextBox.Text;
            Settings.Default.Server = m_ServersComboBox.Text;
            Settings.Default.Timeout = (int)m_TimeoutUpDown.Value;
            Settings.Default.Save();
        }

        private void OpenSession()
        {
            m_Session = new Session(m_ServersComboBox.Text + "/tcc");
            if (m_TimeoutUpDown.Value == -1)
                m_Session.Timeout = -1;
            else
                m_Session.Timeout = (int)m_TimeoutUpDown.Value * MillisecondsInSecond;

            m_Session.Open(m_MemberTextBox.Text, m_OrgTextBox.Text, m_PasswordTextBox.Text);
        }

        //------------------------------ Event handlers ------------------------------------------

        void LoginForm_Load(object sender, EventArgs e)
        {
            m_ServersComboBox.SelectedIndex = 0;

            LoadSettings();
        }

        void TextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateOkButtonState();
        }

        void ServersComboBox_TextChanged(object sender, EventArgs e)
        {
            UpdateOkButtonState();
        }

        void OkButton_Click(object sender, EventArgs e)
        {
            Cursor cursorBefore = Cursor;

            try
            {
                Cursor = Cursors.WaitCursor;

                SaveSettings();

                OpenSession();

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (System.Exception ex)
            {
                m_Session = null;
                Utils.ShowError(ex);
            }
            finally
            {
                Cursor = cursorBefore;
            }
        }

        void CancelButton_Click(object sender, EventArgs e)
        {
            m_Session = null;
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
