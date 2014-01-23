using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using TCC2.API;
using TCC2.API.Filesystem;

using UsageSample.Properties;

namespace UsageSample
{
    public partial class MainForm : Form
    {
        /// <summary>Session. Closed in Dispose method</summary>
        Session m_Session;

        /// <summary>
        /// Both collections contains Id as key, and short name as value
        /// </summary>
        List<FilespaceData> m_Filespaces = new List<FilespaceData>();
        BindingSource m_FilespacesBindingList = new BindingSource();

        List<ProgressFormBase> m_ProgressDialogs = new List<ProgressFormBase>();
        Dictionary<object, TreeNode> m_NodesForRefreshing = new Dictionary<object, TreeNode>();

        const int m_FilespaceIconIndex = 1;
        const int m_FileIconIndex = 2;
        const int m_FolderIconIndex = 3;
        const int m_OpenFolderIconIndex = 4;

        const string m_FictiveNodeKey = "FICTIVE";
        const string m_FilespaceNodeKey = "FILESPACE";
        const string m_FileNodeKey = "FILE";
        const string m_FolderNodeKey = "FOLDER";

        public MainForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;

            m_FilespacesBindingList.CurrentItemChanged += new EventHandler(FilespacesBindingList_CurrentItemChanged);

            m_FilespaceView.ImageList = new ImageList();
            m_FilespaceView.ImageList.Images.Add(new Bitmap(16, 16));
            m_FilespaceView.ImageList.Images.Add(Resources.Filespace);
            m_FilespaceView.ImageList.Images.Add(Resources.File);
            m_FilespaceView.ImageList.Images.Add(Resources.Folder);
            m_FilespaceView.ImageList.Images.Add(Resources.OpenedFolder);

            m_FilespaceView.TreeViewNodeSorter = new NodeSorter();
        }

        FilespaceData CurrentFilespace
        {
            get
            {
                return (FilespaceData)m_FilespacesBindingList.Current;
            }
        }

        TreeNode RootNode
        {
            get
            {
                Debug.Assert(m_FilespaceView.Nodes.Count > 0);
                return m_FilespaceView.Nodes[0];
            }
        }

        /// <summary>
        /// Simply get
        /// </summary>
        void LoadFilespaces()
        {
            Debug.Assert(m_Session.IsOpened);

            m_Filespaces.Clear();
            m_FilespaceView.Enabled = false;

            try
            {
                GetFilespacesResult filespaces = m_Session.GetFilespaces();
                m_Filespaces.AddRange(filespaces.Filespaces);

                UpdateFilespacesComboBox();
            }
            catch (System.Exception ex)
            {
                Utils.ShowError(ex);
            }            
        }

        void LoadFilespaceContent(FilespaceData filespace)
        {
            try
            {
                RootNode.Nodes.Clear();
                RootNode.Nodes.Add("Loading...");

                m_Session.BeginDir(filespace.FilespaceId, "/", false, OnEndDir, RootNode);
                UpdateButtons(m_FilespaceView.SelectedNode);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        string GetPathForNode(TreeNode node)
        {
            Debug.Assert(node != null);

            string pathToNode = node.FullPath.Substring(1);//ignore first backslash for root node
            if (pathToNode.Length == 0)
                return "/";

            return pathToNode.Replace(m_FilespaceView.PathSeparator, "/");
        }

        void UploadFinished(object sender, UploadForm.UploadEventArgs e)
        {
            if (CurrentFilespace == null || CurrentFilespace.FilespaceId != e.FilespaceId)
                return;

            if (m_NodesForRefreshing.ContainsKey(sender))
            {
                if (e.Success)
                    UpdateNode(m_NodesForRefreshing[sender]);

                m_NodesForRefreshing.Remove(sender);
            }
        }

        //----------------------------- TreeView helper methods -------------------------------

        static int GetIconIndex(IDirBaseEntry entry)
        {
            return (entry is IDirFolder ? m_FolderIconIndex : m_FileIconIndex);
        }

        static string GetKey(IDirBaseEntry entry)
        {
            return (entry is IDirFolder ? m_FolderNodeKey : m_FileNodeKey);
        }

        static bool IsFileNode(TreeNode node)
        {
            if (node == null)
                return false;

            return (node.Name == m_FileNodeKey);
        }

        static bool IsFolderNode(TreeNode node)
        {
            if (node == null)
                return false;

            return (node.Name == m_FolderNodeKey || node.Name == m_FilespaceNodeKey);
        }

        static bool IsFictiveNode(TreeNode node)
        {
            if (node == null)
                return false;

            return (node.Name == m_FictiveNodeKey);
        }

        //------------------------------ UI updating ---------------------------------------------

        void UpdateFilespacesComboBox()
        {
            m_FilespacesBindingList.DataSource = null;
            m_FilespacesBindingList.DataSource = m_Filespaces;

            m_FilespacesComboBox.DataSource = m_FilespacesBindingList;
            m_FilespacesComboBox.DisplayMember = "ShortName";
        }

        void UpdateTreeView(TreeNode parentNode, DirResult dirResult)
        {
            Debug.Assert(parentNode != null);

            TreeNodeCollection nodes = parentNode.Nodes;
            nodes.Clear();

            IDirFolder folder = (IDirFolder)dirResult.Content;
            foreach (IDirBaseEntry entry in folder.Entries)
            {
                int iconIndex = GetIconIndex(entry);
                string nodeKey = GetKey(entry);
                TreeNode node = nodes.Add(nodeKey, entry.Name, iconIndex, iconIndex);
                if (node != null && entry is IDirFolder)
                    node.Nodes.Add(m_FictiveNodeKey, "Loading...");
            }
        }

        void UpdateNode(TreeNode node)
        {
            string path = GetPathForNode(node);
            m_Session.BeginDir(CurrentFilespace.FilespaceId, path, false, OnEndDir, node);
        }

        void UpdateButtons(TreeNode node)
        {
            bool fileSelected = IsFileNode(node);
            m_DownloadButton.Enabled = fileSelected;

            bool fileOrFolderSelected = (IsFolderNode(node) || fileSelected);
            m_UploadButton.Enabled = fileOrFolderSelected;
        }

        //-------------------------- Callbacks and event handlers for async API calls -------------------------------

        delegate void UpdateTreeViewHandler(TreeNode parentNode, DirResult dirResult);

        void OnEndDir(IAsyncResult ar)
        {
            if (!ar.IsCompleted)
                return;

            Debug.Assert(ar.AsyncState != null);

            try
            {
                DirResult dirResult = m_Session.EndDir(ar);

                UpdateTreeViewHandler action = new UpdateTreeViewHandler(UpdateTreeView);
                Invoke(action, ar.AsyncState as TreeNode, dirResult);
            }
            catch (Exception ex)
            {
                string message = "Dir request failed: " + ex.Message;
                Utils.ShowError(message);
            }
        }

        //------------------------------ Event handlers ------------------------------------------

        void MainForm_Load(object sender, EventArgs e)
        {
            using (LoginForm loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                    m_Session = loginForm.Session;
            }

            if (m_Session == null)
            {
                Close();
                return;
            }

            m_FilespaceView.Nodes.Add(m_FilespaceNodeKey, "/", m_FilespaceIconIndex, m_FilespaceIconIndex);

            LoadFilespaces();
        }

        void FilespacesBindingList_CurrentItemChanged(object sender, EventArgs e)
        {
            if (CurrentFilespace == null)
            {
                m_FilespaceView.Enabled = false;
                RootNode.Nodes.Clear();
                return;
            }

            m_FilespaceView.Enabled = true;
            LoadFilespaceContent(CurrentFilespace);
        }

        void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadFilespaces();
        }

        void FilespaceView_AfterExpand(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            if (node.Nodes.Count > 1)
                return;

            if (node.Nodes[0].Name != m_FictiveNodeKey)
                return;

            UpdateNode(node);
        }

        void FilespaceView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            UpdateButtons(e.Node);
        }

        void UploadButton_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = m_FilespaceView.SelectedNode;
            Debug.Assert(!IsFictiveNode(selectedNode));

            if (IsFileNode(selectedNode))
                selectedNode = selectedNode.Parent;
            
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.CheckFileExists = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = GetPathForNode(selectedNode);
                    UploadForm uploadForm = new UploadForm(m_Session, openFileDialog.FileName, CurrentFilespace.FilespaceId, path, openFileDialog.SafeFileName);
                    uploadForm.StartPosition = FormStartPosition.CenterParent;

                    uploadForm.Finished += UploadFinished;
                    m_NodesForRefreshing.Add(uploadForm, selectedNode);

                    uploadForm.Show(this);
                    m_ProgressDialogs.Add(uploadForm);
                    
                }
            }
        }

        void DownloadButton_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = m_FilespaceView.SelectedNode;

            Debug.Assert(IsFileNode(selectedNode));
            if (!IsFileNode(selectedNode))
            {
                Utils.ShowError("Internal error");
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                string path = GetPathForNode(selectedNode);

                saveFileDialog.Filter = string.Format("*{0}|*{0}|All files (*.*)|*.*", Path.GetExtension(path));
                saveFileDialog.CheckFileExists = false;
                saveFileDialog.FileName = Path.GetFileName(path);

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    DownloadForm downloadForm = new DownloadForm(m_Session, saveFileDialog.FileName, CurrentFilespace.FilespaceId, path);
                    downloadForm.StartPosition = FormStartPosition.CenterParent;
                    downloadForm.Show();
                    m_ProgressDialogs.Add(downloadForm);
                }
            }
        }
    }
}
