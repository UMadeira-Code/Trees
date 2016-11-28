using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees.Logging
{
    interface ILogger
    {
        IRecorder Recorder { get; set; }
        void Log(string aFormat, params object[] aArgs);
    }
}
