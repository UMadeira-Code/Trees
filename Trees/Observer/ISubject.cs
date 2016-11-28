using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees.Observer
{
    public delegate void UpdateHandler(ISubject aSubject, object aData);

    public interface ISubject
    {
        event UpdateHandler OnUpdate;

        void Notify(object aData = null);
    }
}
