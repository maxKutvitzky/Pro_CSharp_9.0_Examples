using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithRecords
{
    class Car
    {
        public string Make { get; init; }
        public string Model { get; init; }
        public string Color { get; init; }
        public Car() { }
        public Car(string make, string model, string color)
        {
            Make = make;
            Model = model;
            Color = color;
        }
    }
}
