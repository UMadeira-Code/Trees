using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trees.Commands;

namespace Trees
{
    class AddNodeCommand : ICommand
    {
        private static int Counter = 0;
        public AddNodeCommand( TreeView aTreeView )
        {
            this.View = aTreeView;
            this.Node = new TreeNode( "New node (" + Counter++ + ")...");
        }

        private TreeView View { get; set; }

        private TreeNode Node { get; set; }

        public void Execute()
        {
            View.Nodes.Add(Node);
        }

        public void Redo()
        {
            Execute();
        }

        public void Undo()
        {
            Node.Remove();
        }
    }
}
