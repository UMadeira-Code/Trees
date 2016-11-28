using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees.Observer
{
    interface IObserver
    {
        void Update( ISubject aSubject, object aData);
    }
}
