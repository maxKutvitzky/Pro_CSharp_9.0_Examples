using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApplyingAttributes
{
    public class Motorcycle
    {
        [JsonIgnore]
        public float weightOfCurrentPassengers;
        // These fields are still serializable.
        public bool hasRadioSystem;
        public bool hasHeadSet;
        public bool hasSissyBar;
    }
}
