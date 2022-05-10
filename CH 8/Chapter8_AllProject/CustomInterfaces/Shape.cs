using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterfaces
{
    // The abstract base class of the hierarchy.
    abstract class Shape
    {
        protected Shape(string name = "NoName")
        { PetName = name; }
        public string PetName { get; set; }
        // A single virtual method.
        public abstract void Draw();
        
    }
}
