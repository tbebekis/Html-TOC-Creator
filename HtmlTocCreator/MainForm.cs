using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

 

namespace HtmlTocCreator
{
 
    public partial class MainForm : Form
    {
        /* private */
        const string SFilter = "Html files (*.html;*.htm)|*.html;*.htm|All files (*.*)|*.*";

        TocBuilder Builder;

        /* handlers */
        void AnyClick(object sender, EventArgs ea)
        {
            if (btnExit == sender)
            {
                Close();
                return;
            }

            if (btnLoadFromFile == sender)
            {
                LoadFromFile();
            }
            else if (btnSaveToFile == sender)
            {
                SaveToFile();
            }
            else if (btnExecute == sender)
            {
                Execute();
            }
        }

        /* private */
        void LoadFromFile()
        {
            Pager.SelectedTab = tabInput;

            tv.Nodes.Clear();
            edtOutput.Clear();

            using (OpenFileDialog Dlg = new OpenFileDialog())
            {
                Dlg.Filter = SFilter;
                Dlg.Multiselect = false;

                if (Dlg.ShowDialog() == DialogResult.OK)
                {
                    edtInput.Text = Builder.LoadFromFile(Dlg.FileName);
                }
            }
        }
        void SaveToFile()
        {
            Pager.SelectedTab = tabOutput;

            using (SaveFileDialog Dlg = new SaveFileDialog())
            {
                Dlg.Filter = SFilter;
                Dlg.RestoreDirectory = true;

                if (Dlg.ShowDialog() == DialogResult.OK)
                {
                    Builder.SaveToFile(Dlg.FileName);
                }
            }
        }
        void DisplayToBroser(string HtmlText)
        {
            Pager.SelectedTab = tabBrowser;

            Browser.Navigate("about:blank");
            try
            {
                if (Browser.Document != null)
                {
                    Browser.Document.Write(string.Empty);
                }
            }
            catch  
            {
            }  

            Browser.DocumentText = HtmlText;
        }
        void AddTreeNodes(TreeNodeCollection Nodes, Node Node)
        {
            TreeNode TreeNode = new TreeNode(Node.GetName());
            TreeNode.Tag = Node;
            Nodes.Add(TreeNode);

            foreach (var Child in Node.Items)
            {
                AddTreeNodes(TreeNode.Nodes, Child);
            }
        }
        void Execute()
        {
            try
            {
                Builder = new TocBuilder();
                Builder.UnorderedLists = chUnorderedLists.Checked;
                Builder.LoadFromText(edtInput.Text);
                Node Root = Builder.Build();

                tv.Nodes.Clear();
                AddTreeNodes(tv.Nodes, Root);
                
                DisplayToBroser(Builder.HtmlText);
                edtOutput.Text = Builder.HtmlText;

                tv.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        void FormInitialize()
        {
            Browser.IsWebBrowserContextMenuEnabled = false;
            Browser.WebBrowserShortcutsEnabled = true;
            Browser.ScriptErrorsSuppressed = true;
            Browser.AllowWebBrowserDrop = false;

            btnExit.Click += AnyClick;
            btnExecute.Click += AnyClick;
            btnLoadFromFile.Click += AnyClick;
            btnSaveToFile.Click += AnyClick;
        }

        /* overrides */
        protected override void OnShown(EventArgs e)
        {
            if (!DesignMode)
                FormInitialize();
            base.OnShown(e);
        }

        /* construction */
        public MainForm()
        {
            InitializeComponent();
        }
    }
}
