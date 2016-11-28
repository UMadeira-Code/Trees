using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trees.Commands;

namespace Trees
{
    public partial class TreesForm : Form
    {
        public TreesForm()
        {
            InitializeComponent();

            CommandManager.Instance.OnUpdate +=
                (s, d) => mUndoButton.Enabled = CommandManager.Instance.HasUndo();
            CommandManager.Instance.OnUpdate +=
                (s, d) => mRedoButton.Enabled = CommandManager.Instance.HasRedo();
        }

        private void OnAddNode(object sender, EventArgs e)
        {
            CommandManager.Instance.Execute(new AddNodeCommand(mTreeView));
        }

        private void OnDeleteNode(object sender, EventArgs e)
        {
            if (mTreeView.SelectedNode != null)
            {
                mTreeView.SelectedNode.Remove();
            }
        }

        private void OnUndo(object sender, EventArgs e)
        {
            CommandManager.Instance.Undo();
        }

        private void OnRedo(object sender, EventArgs e)
        {
            CommandManager.Instance.Redo();
        }
    }
}
