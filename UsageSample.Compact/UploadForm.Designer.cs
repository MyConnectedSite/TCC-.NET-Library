namespace UsageSample.Compact
{
    partial class UploadForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu m_MainMenu;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_MainMenu = new System.Windows.Forms.MainMenu();
            this.m_UploadMenuItem = new System.Windows.Forms.MenuItem();
            this.m_LogoutMenuItem = new System.Windows.Forms.MenuItem();
            this.m_FilespaceLabel = new System.Windows.Forms.Label();
            this.m_FilespaceComboBox = new System.Windows.Forms.ComboBox();
            this.m_FileLabel = new System.Windows.Forms.Label();
            this.m_FileTextBox = new System.Windows.Forms.TextBox();
            this.m_OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.m_BrowseButton = new System.Windows.Forms.Button();
            this.m_StatusBar = new System.Windows.Forms.StatusBar();
            this.m_ProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // m_MainMenu
            // 
            this.m_MainMenu.MenuItems.Add(this.m_UploadMenuItem);
            this.m_MainMenu.MenuItems.Add(this.m_LogoutMenuItem);
            // 
            // m_UploadMenuItem
            // 
            this.m_UploadMenuItem.Enabled = false;
            this.m_UploadMenuItem.Text = "Upload";
            this.m_UploadMenuItem.Click += new System.EventHandler(this.UploadMenuItem_Click);
            // 
            // m_LogoutMenuItem
            // 
            this.m_LogoutMenuItem.Text = "Logout";
            this.m_LogoutMenuItem.Click += new System.EventHandler(this.LogoutMenuItem_Click);
            // 
            // m_FilespaceLabel
            // 
            this.m_FilespaceLabel.Location = new System.Drawing.Point(3, 9);
            this.m_FilespaceLabel.Name = "m_FilespaceLabel";
            this.m_FilespaceLabel.Size = new System.Drawing.Size(62, 20);
            this.m_FilespaceLabel.Text = "Filespace";
            // 
            // m_FilespaceComboBox
            // 
            this.m_FilespaceComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_FilespaceComboBox.DisplayMember = "ShortName";
            this.m_FilespaceComboBox.Enabled = false;
            this.m_FilespaceComboBox.Location = new System.Drawing.Point(3, 28);
            this.m_FilespaceComboBox.Name = "m_FilespaceComboBox";
            this.m_FilespaceComboBox.Size = new System.Drawing.Size(234, 22);
            this.m_FilespaceComboBox.TabIndex = 1;
            this.m_FilespaceComboBox.ValueMember = "FilespaceId";
            // 
            // m_FileLabel
            // 
            this.m_FileLabel.Location = new System.Drawing.Point(3, 61);
            this.m_FileLabel.Name = "m_FileLabel";
            this.m_FileLabel.Size = new System.Drawing.Size(28, 20);
            this.m_FileLabel.Text = "File";
            // 
            // m_FileTextBox
            // 
            this.m_FileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_FileTextBox.Location = new System.Drawing.Point(3, 80);
            this.m_FileTextBox.Name = "m_FileTextBox";
            this.m_FileTextBox.ReadOnly = true;
            this.m_FileTextBox.Size = new System.Drawing.Size(177, 21);
            this.m_FileTextBox.TabIndex = 3;
            // 
            // m_BrowseButton
            // 
            this.m_BrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_BrowseButton.Enabled = false;
            this.m_BrowseButton.Location = new System.Drawing.Point(181, 80);
            this.m_BrowseButton.Name = "m_BrowseButton";
            this.m_BrowseButton.Size = new System.Drawing.Size(56, 20);
            this.m_BrowseButton.TabIndex = 4;
            this.m_BrowseButton.Text = "Browse";
            this.m_BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // m_StatusBar
            // 
            this.m_StatusBar.Location = new System.Drawing.Point(0, 246);
            this.m_StatusBar.Name = "m_StatusBar";
            this.m_StatusBar.Size = new System.Drawing.Size(240, 22);
            // 
            // m_ProgressBar
            // 
            this.m_ProgressBar.Location = new System.Drawing.Point(3, 107);
            this.m_ProgressBar.Name = "m_ProgressBar";
            this.m_ProgressBar.Size = new System.Drawing.Size(234, 13);
            this.m_ProgressBar.Visible = false;
            // 
            // UploadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.m_ProgressBar);
            this.Controls.Add(this.m_StatusBar);
            this.Controls.Add(this.m_BrowseButton);
            this.Controls.Add(this.m_FileTextBox);
            this.Controls.Add(this.m_FileLabel);
            this.Controls.Add(this.m_FilespaceComboBox);
            this.Controls.Add(this.m_FilespaceLabel);
            this.Menu = this.m_MainMenu;
            this.Name = "UploadForm";
            this.Text = "File upload demo";
            this.Activated += new System.EventHandler(this.UploadForm_Activated);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem m_UploadMenuItem;
        private System.Windows.Forms.MenuItem m_LogoutMenuItem;
        private System.Windows.Forms.Label m_FilespaceLabel;
        private System.Windows.Forms.ComboBox m_FilespaceComboBox;
        private System.Windows.Forms.Label m_FileLabel;
        private System.Windows.Forms.TextBox m_FileTextBox;
        private System.Windows.Forms.OpenFileDialog m_OpenFileDialog;
        private System.Windows.Forms.Button m_BrowseButton;
        private System.Windows.Forms.StatusBar m_StatusBar;
        private System.Windows.Forms.ProgressBar m_ProgressBar;
    }
}