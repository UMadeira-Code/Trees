using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trees.Commands;

namespace Trees
{
    class MacroCommand : ICommand
    {
        private readonly List<ICommand> mCommands = new List<ICommand>();

        public void Execute( ICommand aCommand )
        {
            mCommands.Add(aCommand);
        }

        public void Execute()
        {
            foreach (var command in mCommands)
                command.Execute();
        }

        public void Redo()
        {
            Execute();
        }

        public void Undo()
        {
            foreach (var command in mCommands.Reverse<ICommand>())
                command.Undo();

        }
    }
}
