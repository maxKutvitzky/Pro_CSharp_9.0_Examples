using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConnectionFactory
{
    //OleDb is Windows only and is not supported in .NET Core
    enum DataProviderEnum
    {
        SqlServer,
        #if PC
         OleDb,
        #endif
        Odbc,
        None
    }
}