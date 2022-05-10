using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterfaces
{
    public interface IPointy
    {
        // Implicitly public and abstract.
        //byte GetNumberOfPoints();
        // Implicitly public and abstract.
        //byte GetNumberOfPoints();
        // A read-write property in an interface would look like:
        //string PropName { get; set; }
        // while a write-only property in an interface would be:
        byte Points { get; }

    }
}
