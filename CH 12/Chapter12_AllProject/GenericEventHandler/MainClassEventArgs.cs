using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericEventHandler
{
    internal class MainClassEventArgs:EventArgs
    {
        public readonly string msg;
        public readonly int newCounter;
        public MainClassEventArgs(string msg, int counter)
        {
            this.msg = msg;
            newCounter = counter;
        }
    }
}
