using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDelegateForMyPurposes
{
    internal class Subscriber
    {
        UIElement _element;
        public Subscriber(UIElement uIElement)
        {
            _element = uIElement;
            Console.WriteLine("Subscriber: UIElement added to subscriber class");
        }
        public void DoSmt()
        {
            Console.WriteLine("Subscriber: doing smt");
            _element.State = "Subscriber change UIElement state";
        }
    }
}
