using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees.Logging
{
    interface IRecorder
    {
        void Record(string aMessage);
    }
}
