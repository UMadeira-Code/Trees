using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trees.Observer;

namespace Trees.Commands
{
    class CommandManager : ISubject 
    {
        #region Singleton
        private static readonly CommandManager instance = new CommandManager();
        private CommandManager() { }

        public static CommandManager Instance { get { return instance; } }
        #endregion

        private readonly List<ICommand> mCommands = new List<ICommand>();
        private int mPosition = -1;

        public event UpdateHandler OnUpdate;

        public void Execute( ICommand aCommand )
        {
            if (HasRedo())
            {
                mCommands.RemoveRange( mPosition + 1, mCommands.Count - mPosition - 1 );
            }
            mCommands.Add(aCommand);
            aCommand.Execute();
            mPosition++;

            Notify();
        }

        public void Undo()
        {
            if (!HasUndo()) return;

            mCommands[mPosition].Undo();
            mPosition--;

            Notify();
        }

        public void Redo()
        {
            if (!HasRedo()) return;

            mPosition++;
            mCommands[mPosition].Redo();

            Notify();
        }

        public bool HasUndo()
        {
            return mPosition > -1;
        }

        public bool HasRedo()
        {
            return (mPosition < mCommands.Count() - 1);
        }



        public void Notify(object aData = null)
        {
            OnUpdate(this, aData);
        }
    }
}
