namespace UsageSample
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                    components.Dispose();

                if (m_ProgressDialogs != null)
                {
                    for (int i = 0; i < m_ProgressDialogs.Count; ++i)
                        m_ProgressDialogs[i].Dispose();
                }

                if (m_Session != null)
                    m_Session.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_FilespaceView = new System.Windows.Forms.TreeView();
            this.m_FilespacesComboBox = new System.Windows.Forms.ComboBox();
            this.m_FilespaceLabel = new System.Windows.Forms.Label();
            this.m_RefreshButton = new System.Windows.Forms.Button();
            this.m_UploadButton = new System.Windows.Forms.Button();
            this.m_DownloadButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_FilespaceView
            // 
            this.m_FilespaceView.Location = new System.Drawing.Point(190, 13);
            this.m_FilespaceView.Name = "m_FilespaceView";
            this.m_FilespaceView.Size = new System.Drawing.Size(436, 328);
            this.m_FilespaceView.TabIndex = 4;
            this.m_FilespaceView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.FilespaceView_AfterSelect);
            this.m_FilespaceView.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.FilespaceView_AfterExpand);
            // 
            // m_FilespacesComboBox
            // 
            this.m_FilespacesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_FilespacesComboBox.FormattingEnabled = true;
            this.m_FilespacesComboBox.Location = new System.Drawing.Point(12, 29);
            this.m_FilespacesComboBox.Name = "m_FilespacesComboBox";
            this.m_FilespacesComboBox.Size = new System.Drawing.Size(155, 21);
            this.m_FilespacesComboBox.TabIndex = 0;
            // 
            // m_FilespaceLabel
            // 
            this.m_FilespaceLabel.AutoSize = true;
            this.m_FilespaceLabel.Location = new System.Drawing.Point(12, 13);
            this.m_FilespaceLabel.Name = "m_FilespaceLabel";
            this.m_FilespaceLabel.Size = new System.Drawing.Size(85, 13);
            this.m_FilespaceLabel.TabIndex = 4;
            this.m_FilespaceLabel.Text = "Select filespace:";
            // 
            // m_RefreshButton
            // 
            this.m_RefreshButton.Location = new System.Drawing.Point(12, 71);
            this.m_RefreshButton.Name = "m_RefreshButton";
            this.m_RefreshButton.Size = new System.Drawing.Size(155, 23);
            this.m_RefreshButton.TabIndex = 1;
            this.m_RefreshButton.Text = "Refresh filespace list";
            this.m_RefreshButton.UseVisualStyleBackColor = true;
            this.m_RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // m_UploadButton
            // 
            this.m_UploadButton.Enabled = false;
            this.m_UploadButton.Location = new System.Drawing.Point(12, 111);
            this.m_UploadButton.Name = "m_UploadButton";
            this.m_UploadButton.Size = new System.Drawing.Size(75, 23);
            this.m_UploadButton.TabIndex = 2;
            this.m_UploadButton.Text = "Upload";
            this.m_UploadButton.UseVisualStyleBackColor = true;
            this.m_UploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // m_DownloadButton
            // 
            this.m_DownloadButton.Enabled = false;
            this.m_DownloadButton.Location = new System.Drawing.Point(92, 111);
            this.m_DownloadButton.Name = "m_DownloadButton";
            this.m_DownloadButton.Size = new System.Drawing.Size(75, 23);
            this.m_DownloadButton.TabIndex = 3;
            this.m_DownloadButton.Text = "Download";
            this.m_DownloadButton.UseVisualStyleBackColor = true;
            this.m_DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 358);
            this.Controls.Add(this.m_DownloadButton);
            this.Controls.Add(this.m_UploadButton);
            this.Controls.Add(this.m_RefreshButton);
            this.Controls.Add(this.m_FilespaceLabel);
            this.Controls.Add(this.m_FilespacesComboBox);
            this.Controls.Add(this.m_FilespaceView);
            this.Name = "MainForm";
            this.Text = "TCC2.API Sample application";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView m_FilespaceView;
        private System.Windows.Forms.ComboBox m_FilespacesComboBox;
        private System.Windows.Forms.Label m_FilespaceLabel;
        private System.Windows.Forms.Button m_RefreshButton;
        private System.Windows.Forms.Button m_UploadButton;
        private System.Windows.Forms.Button m_DownloadButton;
    }
}

