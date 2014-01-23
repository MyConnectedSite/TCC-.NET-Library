namespace UsageSample
{
    partial class ProgressFormBase
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
            this.m_InformationLabel = new System.Windows.Forms.Label();
            this.m_ProgressBar = new System.Windows.Forms.ProgressBar();
            this.m_CloseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_InformationLabel
            // 
            this.m_InformationLabel.AutoSize = true;
            this.m_InformationLabel.Location = new System.Drawing.Point(12, 9);
            this.m_InformationLabel.Name = "m_InformationLabel";
            this.m_InformationLabel.Size = new System.Drawing.Size(59, 13);
            this.m_InformationLabel.TabIndex = 0;
            this.m_InformationLabel.Text = "Information";
            // 
            // m_ProgressBar
            // 
            this.m_ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ProgressBar.Location = new System.Drawing.Point(12, 36);
            this.m_ProgressBar.Name = "m_ProgressBar";
            this.m_ProgressBar.Size = new System.Drawing.Size(338, 23);
            this.m_ProgressBar.TabIndex = 2;
            // 
            // m_CloseButton
            // 
            this.m_CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_CloseButton.Location = new System.Drawing.Point(144, 75);
            this.m_CloseButton.Name = "m_CloseButton";
            this.m_CloseButton.Size = new System.Drawing.Size(75, 23);
            this.m_CloseButton.TabIndex = 3;
            this.m_CloseButton.Text = "Close";
            this.m_CloseButton.UseVisualStyleBackColor = true;
            this.m_CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // ProgressFormBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_CloseButton;
            this.ClientSize = new System.Drawing.Size(362, 108);
            this.Controls.Add(this.m_CloseButton);
            this.Controls.Add(this.m_ProgressBar);
            this.Controls.Add(this.m_InformationLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ProgressFormBase";
            this.Text = "Progress";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label m_InformationLabel;
        private System.Windows.Forms.ProgressBar m_ProgressBar;
        private System.Windows.Forms.Button m_CloseButton;
    }
}