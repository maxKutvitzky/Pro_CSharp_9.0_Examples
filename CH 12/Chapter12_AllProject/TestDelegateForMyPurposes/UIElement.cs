using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDelegateForMyPurposes
{
    internal class UIElement
    {
        public string State { get; set; }
        public UIElement(string state)
        {
            State = state;
        }
    }
}
