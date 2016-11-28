using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trees.Logging;

namespace Trees
{
    class TextBoxRecorder : IRecorder
    {
        public TextBoxRecorder(TextBox aTextBox)
        {
            TextBox = aTextBox;
        }

        private TextBox TextBox { get; set; }

        public void Record(string aMessage)
        {
            TextBox.AppendText(aMessage);
            TextBox.AppendText(Environment.NewLine);
        }
    }
}
