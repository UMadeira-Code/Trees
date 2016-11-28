using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trees.Commands;
using Trees.Observer;

namespace Trees
{
    class UndoButtonObserverAdapter : IObserver
    {
        public UndoButtonObserverAdapter( ToolStripButton aButton )
        {
            Button = aButton;
        }

        private ToolStripButton Button { get; set; }
        public void Update(ISubject aSubject, object aData)
        {
            Button.Enabled = CommandManager.Instance.HasUndo();
        }
    }
}
