using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using TCC2.API;

namespace UsageSample
{
    abstract partial class ProgressFormBase : Form
    {
        public ProgressFormBase()
        {
            InitializeComponent();
        }

        protected void OnProgressChanged(object sender, ProgressEventArgs e)
        {
            Action<int> action = new Action<int>(SetProgress);
            Invoke(action, (int)e.Percent);
        }

        void SetProgress(int value)
        {
            m_ProgressBar.Value = value;
        }

        void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
