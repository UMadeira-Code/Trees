using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trees.Logging;

namespace Trees
{
    class FileRecorder : IRecorder
    {
        public FileRecorder(string aFileName)
        {
            Writer = new StreamWriter(aFileName) { AutoFlush = true };
        }

        private StreamWriter Writer { get; set; }

        public void Record(string aMessage)
        {
            Writer.WriteLine(aMessage);
        }
    }
}
