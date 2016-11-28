using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trees.Logging;

namespace Trees
{
    class NumberRecorderDecorator : IRecorder
    {
        private static int counter = 1;

        public NumberRecorderDecorator(IRecorder aRecorder)
        {
            Recorder = aRecorder;
        }

        private IRecorder Recorder { get; set; }

        public void Record(string aMessage)
        {
            Recorder.Record(string.Format("{0} : {1}", counter++, aMessage));
        }
    }
}
