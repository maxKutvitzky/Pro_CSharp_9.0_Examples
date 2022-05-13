using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributedCarLibrary
{
    // A custom attribute.
    // This time, we are using the AttributeUsage attribute
    // to annotate our custom attribute.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false)]
    public sealed class VehicleDescriptionAttribute : Attribute
    {
        public string Description { get; set; }
        public VehicleDescriptionAttribute(string description) => Description = description;
        public VehicleDescriptionAttribute() { }
    }
}
