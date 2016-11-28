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
using Trees.Logging;

namespace Trees
{
    public partial class TreesForm : Form
    {
        public TreesForm()
        {
            InitializeComponent();

            var recorder = new CompositeRecorder();
            Logger.Instance.Recorder = recorder;

            recorder.Add(new TextBoxRecorder(mMessageBox));
            recorder.Add(  new FileRecorder("Messages.log") );

            Logger.Instance.Recorder = new NumberRecorderDecorator(Logger.Instance.Recorder);

            CommandManager.Instance.OnUpdate +=
                (s, d) => mUndoButton.Enabled = CommandManager.Instance.HasUndo();
            CommandManager.Instance.OnUpdate +=
                (s, d) => mRedoButton.Enabled = CommandManager.Instance.HasRedo();

            CommandManager.Instance.OnUpdate +=
                (s, d) => mUndoMenuItem.Enabled = CommandManager.Instance.HasUndo();
            CommandManager.Instance.OnUpdate +=
                (s, d) => mRedoMenuItem.Enabled = CommandManager.Instance.HasRedo();
        }

        private void OnAddNode(object sender, EventArgs e)
        {
            Logger.Instance.Log("Add new node...");
            CommandManager.Instance.Execute(new AddNodeCommand(mTreeView));
        }

        private void OnDeleteNode(object sender, EventArgs e)
        {
            if (mTreeView.SelectedNode != null)
            {
                Logger.Instance.Log("Delete node ({0})", mTreeView.SelectedNode.Text );
                CommandManager.Instance.Execute(
                    new DeleteNodeCommand(mTreeView.SelectedNode));
            }
        }

        private void OnUndo(object sender, EventArgs e)
        {
            Logger.Instance.Log("Undo");
            CommandManager.Instance.Undo();
        }

        private void OnRedo(object sender, EventArgs e)
        {
            Logger.Instance.Log("Redo");
            CommandManager.Instance.Redo();
        }

        private void OnDeleteAll(object sender, EventArgs e)
        {
            List<TreeNode> nodes = new List<TreeNode>();
            foreach (TreeNode node in mTreeView.Nodes)
            {
                nodes.Add(node);
            }

            Logger.Instance.Log("Delete {0} nodes", nodes.Count );

            var macro = new MacroCommand();
            foreach (TreeNode node in nodes)
            {
                macro.Execute( new DeleteNodeCommand(node));
            }
            CommandManager.Instance.Execute(macro);
        }
    }
}
