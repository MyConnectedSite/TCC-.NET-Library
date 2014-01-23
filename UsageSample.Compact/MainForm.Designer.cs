namespace UsageSample.Compact
{
    partial class MainForm
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
            this.m_LoginMenuItem = new System.Windows.Forms.MenuItem();
            this.m_ExitMenuItem = new System.Windows.Forms.MenuItem();
            this.m_UrlLabel = new System.Windows.Forms.Label();
            this.m_UrlTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_UserTextBox = new System.Windows.Forms.TextBox();
            this.m_OrgTextBox = new System.Windows.Forms.TextBox();
            this.m_PasswordTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // m_MainMenu
            // 
            this.m_MainMenu.MenuItems.Add(this.m_LoginMenuItem);
            this.m_MainMenu.MenuItems.Add(this.m_ExitMenuItem);
            // 
            // m_LoginMenuItem
            // 
            this.m_LoginMenuItem.Text = "Login";
            this.m_LoginMenuItem.Click += new System.EventHandler(this.LoginMenuItem_Click);
            // 
            // m_ExitMenuItem
            // 
            this.m_ExitMenuItem.Text = "Exit";
            this.m_ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // m_UrlLabel
            // 
            this.m_UrlLabel.Location = new System.Drawing.Point(3, 8);
            this.m_UrlLabel.Name = "m_UrlLabel";
            this.m_UrlLabel.Size = new System.Drawing.Size(69, 20);
            this.m_UrlLabel.Text = "TCC server";
            // 
            // m_UrlTextBox
            // 
            this.m_UrlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_UrlTextBox.Location = new System.Drawing.Point(3, 27);
            this.m_UrlTextBox.Name = "m_UrlTextBox";
            this.m_UrlTextBox.Size = new System.Drawing.Size(234, 21);
            this.m_UrlTextBox.TabIndex = 1;
            this.m_UrlTextBox.Text = "https://www.myconnectedsite.com";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.Text = "User name";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.Text = "Organization";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.Text = "Password";
            // 
            // m_UserTextBox
            // 
            this.m_UserTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_UserTextBox.Location = new System.Drawing.Point(3, 78);
            this.m_UserTextBox.Name = "m_UserTextBox";
            this.m_UserTextBox.Size = new System.Drawing.Size(234, 21);
            this.m_UserTextBox.TabIndex = 5;
            // 
            // m_OrgTextBox
            // 
            this.m_OrgTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_OrgTextBox.Location = new System.Drawing.Point(3, 129);
            this.m_OrgTextBox.Name = "m_OrgTextBox";
            this.m_OrgTextBox.Size = new System.Drawing.Size(234, 21);
            this.m_OrgTextBox.TabIndex = 6;
            // 
            // m_PasswordTextBox
            // 
            this.m_PasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_PasswordTextBox.Location = new System.Drawing.Point(3, 180);
            this.m_PasswordTextBox.Name = "m_PasswordTextBox";
            this.m_PasswordTextBox.PasswordChar = '*';
            this.m_PasswordTextBox.Size = new System.Drawing.Size(234, 21);
            this.m_PasswordTextBox.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.m_PasswordTextBox);
            this.Controls.Add(this.m_OrgTextBox);
            this.Controls.Add(this.m_UserTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_UrlTextBox);
            this.Controls.Add(this.m_UrlLabel);
            this.Menu = this.m_MainMenu;
            this.Name = "MainForm";
            this.Text = "TCC2 API library usage sample";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label m_UrlLabel;
        private System.Windows.Forms.TextBox m_UrlTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox m_UserTextBox;
        private System.Windows.Forms.TextBox m_OrgTextBox;
        private System.Windows.Forms.TextBox m_PasswordTextBox;
        private System.Windows.Forms.MenuItem m_LoginMenuItem;
        private System.Windows.Forms.MenuItem m_ExitMenuItem;
    }
}

