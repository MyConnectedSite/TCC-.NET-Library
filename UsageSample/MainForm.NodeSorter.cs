using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UsageSample
{
    partial class MainForm
    {
        public class NodeSorter : IComparer
        {
            // Compare the length of the strings, or the strings
            // themselves, if they are the same length.
            public int Compare(object x, object y)
            {
                TreeNode first = x as TreeNode;
                TreeNode second = y as TreeNode;

                if (first == null && second != null)
                    return -1;

                if (first != null && second == null)
                    return 1;

                if (ReferenceEquals(first, second))
                    return 0;

                bool isFirstFolder = (first.Name == MainForm.m_FolderNodeKey);
                bool isSecondFolder = (second.Name == MainForm.m_FolderNodeKey);
                if (isFirstFolder != isSecondFolder)
                    return isFirstFolder ? -1 : 1;

                return string.Compare(first.Text, second.Text);
            }
        }

    }
}
