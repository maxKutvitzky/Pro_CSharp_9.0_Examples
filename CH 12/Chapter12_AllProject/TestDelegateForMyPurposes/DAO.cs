using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDelegateForMyPurposes
{
    internal class DAO : IDAO
    {
        //private DAOHandler _handler = new DAOHandler();
        public delegate void DAOHandlerDelegate();
        public event DAOHandlerDelegate Update;
        public DAO()
        {

        }
        public DAO(DAOHandler daoHandler)
        {
            //_handler = daoHandler;
        }
        public void AddSomeThing(DBInstance dBInstance)
        {
            Console.WriteLine("DAO: Adding something");
            //_handler.Update();
            Update.Invoke();
        }
    }
}
