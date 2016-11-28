using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trees.Logging;

namespace Trees
{
    class CompositeRecorder : IRecorder
    {
        private readonly List<IRecorder> mRecorders = new List<IRecorder>();

        public CompositeRecorder()
        {
        }

        public void Add(IRecorder aRecorder)
        {
            mRecorders.Add(aRecorder);
        }

        public void Record(string aMessage)
        {
            foreach (var recorder in mRecorders)
                recorder.Record(aMessage);
        }
    }
}
