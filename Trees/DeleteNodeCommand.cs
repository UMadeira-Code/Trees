using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trees.Commands;

namespace Trees
{
    class DeleteNodeCommand : ICommand
    {
        public DeleteNodeCommand(TreeNode aNode)
        {
            View   = aNode.TreeView;
            Node   = aNode;
            Parent = aNode.Parent;

            Index = Parent == null ? View.Nodes.IndexOf(Node)
                                   : Parent.Nodes.IndexOf(Node);
        }

        private TreeView View { get; set; }
        private TreeNode Node { get; set; }
        private TreeNode Parent { get; set; }

        private int Index { get; set; }

        public void Execute()
        {
            Node.Remove();
        }

        public void Redo()
        {
            Execute();
        }

        public void Undo()
        {
            if (Parent == null)
            {
                View.Nodes.Insert(Index, Node);
            }
            else
            {
                Parent.Nodes.Insert(Index, Node);
            }
        }
    }
}
