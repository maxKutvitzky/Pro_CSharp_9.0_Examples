using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterfaces
{
    class Knife : IPointy
    {
        public byte Points => 1;
    }
}
