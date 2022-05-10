using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDelegateForMyPurposes
{
    internal class DAOHandler
    {
        public delegate void DAOHandlerDelegate();
        private DAOHandlerDelegate _DAOHandlerDelegate;
        public DAOHandler()
        {

        }
        public void AddSubscriber(DAOHandlerDelegate handlerDelegate)
        {
            Console.WriteLine($"Adding subscriber {handlerDelegate.Method}");
            _DAOHandlerDelegate += handlerDelegate;
        }
        public void RemoveSubscriber(DAOHandlerDelegate handlerDelegate)
        {
            Console.WriteLine($"Removing subscriber {handlerDelegate.Method}");
            _DAOHandlerDelegate -= handlerDelegate;                                  
        }
        public void Update()
        {
            _DAOHandlerDelegate.Invoke();
        }
    }
}
