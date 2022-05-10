using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterfaces
{
    public abstract class CloneableType
    {
        // Only derived types can support this
        // "polymorphic interface." Classes in other
        // hierarchies have no access to this abstract
        // member.
        public abstract object Clone();
    }
}
