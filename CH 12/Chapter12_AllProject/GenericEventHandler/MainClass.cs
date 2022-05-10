using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericEventHandler
{
    internal class MainClass
    {
        public string Name { get; set; }
        public int Counter { get; set; }
        public List<int> ListCounter = new List<int>();
        public delegate void MainClassDelegate(object sender, string msg, int counter);
        public delegate int MainClassDelegateInt(object sender, string msg);
        public event MainClassDelegate NameChangedDelegateEvent;
        public event EventHandler<MainClassEventArgs> NameChangedEvent;
        public event MainClassDelegateInt NameChangedIntEvent;
        public MainClass(string name, int counter)
        {
            Name = name;
            Counter = counter;
        }
        public void ChangeName(string newName, int newConter)
        {
            Name = newName;
            NameChangedEvent?.Invoke(this,new MainClassEventArgs("Name has changed!",newConter));
            NameChangedDelegateEvent?.Invoke(this,"delegate event: Name has changed!", newConter);
        }
        public int ChangeNameWithInt(string newName)
        {
            Name = newName;
            var invocationList = NameChangedIntEvent.GetInvocationList();
            invocationList = invocationList.Reverse().ToArray();
            foreach (var item in invocationList)
            {             
                ListCounter.Add((int)item.DynamicInvoke(this, "Name changed int"));
            } 
            return 1;
        }
    }
}
