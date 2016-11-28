using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees.Observer
{
    class Subject : ISubject
    {
        public event UpdateHandler OnUpdate;

        public void Notify(object aData = null)
        {
            OnUpdate(this, aData);
        }
    }
}
