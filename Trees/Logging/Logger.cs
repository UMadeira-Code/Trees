using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees.Logging
{
    class Logger : ILogger
    {
        #region Singleton
        private static readonly Logger instance = new Logger();
        private Logger() { }
        public static Logger Instance { get { return instance; } }

        #endregion

        public IRecorder Recorder { get; set; }

        public void Log(string aFormat, params object[] aArgs)
        {
            if (Recorder == null) return;
            Recorder.Record( string.Format(aFormat, aArgs) );
        }

    }
}
