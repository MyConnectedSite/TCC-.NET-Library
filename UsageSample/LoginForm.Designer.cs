namespace UsageSample
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            this.m_MemberTextBox = new System.Windows.Forms.TextBox();
            this.m_OrgTextBox = new System.Windows.Forms.TextBox();
            this.m_PasswordTextBox = new System.Windows.Forms.TextBox();
            this.m_ServersComboBox = new System.Windows.Forms.ComboBox();
            this.m_MemberLabel = new System.Windows.Forms.Label();
            this.m_OrgLabel = new System.Windows.Forms.Label();
            this.m_PasswordLabel = new System.Windows.Forms.Label();
            this.m_ServersLabel = new System.Windows.Forms.Label();
            this.m_OkButton = new System.Windows.Forms.Button();
            this.m_CancelButton = new System.Windows.Forms.Button();
            this.m_TimeoutLabel = new System.Windows.Forms.Label();
            this.m_TimeoutUpDown = new System.Windows.Forms.NumericUpDown();
            this.m_TimeoutTooltip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.m_TimeoutUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // m_MemberTextBox
            // 
            this.m_MemberTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_MemberTextBox.Location = new System.Drawing.Point(113, 20);
            this.m_MemberTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.m_MemberTextBox.Name = "m_MemberTextBox";
            this.m_MemberTextBox.Size = new System.Drawing.Size(280, 22);
            this.m_MemberTextBox.TabIndex = 0;
            this.m_MemberTextBox.Text = "tccadmin";
            this.m_MemberTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // m_OrgTextBox
            // 
            this.m_OrgTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_OrgTextBox.Location = new System.Drawing.Point(113, 55);
            this.m_OrgTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.m_OrgTextBox.Name = "m_OrgTextBox";
            this.m_OrgTextBox.Size = new System.Drawing.Size(280, 22);
            this.m_OrgTextBox.TabIndex = 1;
            this.m_OrgTextBox.Text = "tcc";
            this.m_OrgTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // m_PasswordTextBox
            // 
            this.m_PasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_PasswordTextBox.Location = new System.Drawing.Point(113, 91);
            this.m_PasswordTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.m_PasswordTextBox.Name = "m_PasswordTextBox";
            this.m_PasswordTextBox.PasswordChar = '*';
            this.m_PasswordTextBox.Size = new System.Drawing.Size(280, 22);
            this.m_PasswordTextBox.TabIndex = 2;
            this.m_PasswordTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // m_ServersComboBox
            // 
            this.m_ServersComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ServersComboBox.FormattingEnabled = true;
            this.m_ServersComboBox.Items.AddRange(new object[] {
            "https://qa.myconnectedsite.com/",
            "http://localhost/"});
            this.m_ServersComboBox.Location = new System.Drawing.Point(113, 138);
            this.m_ServersComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.m_ServersComboBox.Name = "m_ServersComboBox";
            this.m_ServersComboBox.Size = new System.Drawing.Size(280, 24);
            this.m_ServersComboBox.TabIndex = 3;
            this.m_ServersComboBox.SelectionChangeCommitted += new System.EventHandler(this.ServersComboBox_TextChanged);
            this.m_ServersComboBox.TextChanged += new System.EventHandler(this.ServersComboBox_TextChanged);
            // 
            // m_MemberLabel
            // 
            this.m_MemberLabel.AutoSize = true;
            this.m_MemberLabel.Location = new System.Drawing.Point(55, 28);
            this.m_MemberLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_MemberLabel.Name = "m_MemberLabel";
            this.m_MemberLabel.Size = new System.Drawing.Size(49, 17);
            this.m_MemberLabel.TabIndex = 4;
            this.m_MemberLabel.Text = "Name:";
            // 
            // m_OrgLabel
            // 
            this.m_OrgLabel.AutoSize = true;
            this.m_OrgLabel.Location = new System.Drawing.Point(13, 64);
            this.m_OrgLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_OrgLabel.Name = "m_OrgLabel";
            this.m_OrgLabel.Size = new System.Drawing.Size(93, 17);
            this.m_OrgLabel.TabIndex = 5;
            this.m_OrgLabel.Text = "Organization:";
            // 
            // m_PasswordLabel
            // 
            this.m_PasswordLabel.AutoSize = true;
            this.m_PasswordLabel.Location = new System.Drawing.Point(31, 100);
            this.m_PasswordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_PasswordLabel.Name = "m_PasswordLabel";
            this.m_PasswordLabel.Size = new System.Drawing.Size(73, 17);
            this.m_PasswordLabel.TabIndex = 6;
            this.m_PasswordLabel.Text = "Password:";
            // 
            // m_ServersLabel
            // 
            this.m_ServersLabel.AutoSize = true;
            this.m_ServersLabel.Location = new System.Drawing.Point(50, 141);
            this.m_ServersLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_ServersLabel.Name = "m_ServersLabel";
            this.m_ServersLabel.Size = new System.Drawing.Size(54, 17);
            this.m_ServersLabel.TabIndex = 7;
            this.m_ServersLabel.Text = "Server:";
            // 
            // m_OkButton
            // 
            this.m_OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_OkButton.Enabled = false;
            this.m_OkButton.Location = new System.Drawing.Point(194, 213);
            this.m_OkButton.Margin = new System.Windows.Forms.Padding(4);
            this.m_OkButton.Name = "m_OkButton";
            this.m_OkButton.Size = new System.Drawing.Size(92, 28);
            this.m_OkButton.TabIndex = 5;
            this.m_OkButton.Text = "OK";
            this.m_OkButton.UseVisualStyleBackColor = true;
            this.m_OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // m_CancelButton
            // 
            this.m_CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_CancelButton.Location = new System.Drawing.Point(294, 213);
            this.m_CancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.m_CancelButton.Name = "m_CancelButton";
            this.m_CancelButton.Size = new System.Drawing.Size(100, 28);
            this.m_CancelButton.TabIndex = 6;
            this.m_CancelButton.Text = "Cancel";
            this.m_CancelButton.UseVisualStyleBackColor = true;
            this.m_CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // m_TimeoutLabel
            // 
            this.m_TimeoutLabel.AutoSize = true;
            this.m_TimeoutLabel.Location = new System.Drawing.Point(7, 177);
            this.m_TimeoutLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_TimeoutLabel.Name = "m_TimeoutLabel";
            this.m_TimeoutLabel.Size = new System.Drawing.Size(99, 17);
            this.m_TimeoutLabel.TabIndex = 8;
            this.m_TimeoutLabel.Text = "Timeout (sec):";
            this.m_TimeoutTooltip.SetToolTip(this.m_TimeoutLabel, "-1 - infinite,\r\n0 - immediate");
            // 
            // m_TimeoutUpDown
            // 
            this.m_TimeoutUpDown.Location = new System.Drawing.Point(113, 175);
            this.m_TimeoutUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.m_TimeoutUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.m_TimeoutUpDown.Name = "m_TimeoutUpDown";
            this.m_TimeoutUpDown.Size = new System.Drawing.Size(80, 22);
            this.m_TimeoutUpDown.TabIndex = 4;
            this.m_TimeoutUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // LoginForm
            // 
            this.AcceptButton = this.m_OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_CancelButton;
            this.ClientSize = new System.Drawing.Size(426, 266);
            this.Controls.Add(this.m_TimeoutUpDown);
            this.Controls.Add(this.m_TimeoutLabel);
            this.Controls.Add(this.m_CancelButton);
            this.Controls.Add(this.m_OkButton);
            this.Controls.Add(this.m_ServersLabel);
            this.Controls.Add(this.m_PasswordLabel);
            this.Controls.Add(this.m_OrgLabel);
            this.Controls.Add(this.m_MemberLabel);
            this.Controls.Add(this.m_ServersComboBox);
            this.Controls.Add(this.m_PasswordTextBox);
            this.Controls.Add(this.m_OrgTextBox);
            this.Controls.Add(this.m_MemberTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_TimeoutUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox m_MemberTextBox;
        private System.Windows.Forms.TextBox m_OrgTextBox;
        private System.Windows.Forms.TextBox m_PasswordTextBox;
        private System.Windows.Forms.ComboBox m_ServersComboBox;
        private System.Windows.Forms.Label m_MemberLabel;
        private System.Windows.Forms.Label m_OrgLabel;
        private System.Windows.Forms.Label m_PasswordLabel;
        private System.Windows.Forms.Label m_ServersLabel;
        private System.Windows.Forms.Button m_OkButton;
        private System.Windows.Forms.Button m_CancelButton;
        private System.Windows.Forms.Label m_TimeoutLabel;
        private System.Windows.Forms.NumericUpDown m_TimeoutUpDown;
        private System.Windows.Forms.ToolTip m_TimeoutTooltip;
    }
}