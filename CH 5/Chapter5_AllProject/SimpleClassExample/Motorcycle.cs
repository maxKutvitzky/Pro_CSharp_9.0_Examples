using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassExample
{
    class Motorcycle
    {
        public int driverIntensity;
        public string driverName;
        public void SetDriverName(string name) => this.driverName = name;
        public void PopAWheely()
        {
            for (int i = 0; i <= driverIntensity; i++)
            {
                Console.WriteLine("Yeeeeeee Haaaaaeewww!");
            }
        }
        // Put back the default constructor, which will
        // set all data members to default values.
        public Motorcycle() { Console.WriteLine("In default ctor"); }
        public Motorcycle(int intensity) : this(intensity, "") {
            Console.WriteLine("In ctor taking an int");
        }
        public Motorcycle(string name) : this(0, name) {
            Console.WriteLine("In ctor taking a string");
        }
        public Motorcycle(int intensity = 0, string name = "")
        {
            Console.WriteLine("In master ctor ");
            if (intensity > 10)
            {
                intensity = 10;
            }
            driverIntensity = intensity;
            driverName = name;
        }
        public void SetIntensity(int intensity)
        {
            if (intensity > 10)
            {
                intensity = 10;
            }
            driverIntensity = intensity;
        }
        static void MakeSomeBikes()
        {
            // driverName = "", driverIntensity = 0
            Motorcycle m1 = new Motorcycle();
            Console.WriteLine("Name= {0}, Intensity= {1}", m1.driverName, m1.driverIntensity);
            // driverName = "Tiny", driverIntensity = 0
            Motorcycle m2 = new Motorcycle(name: "Tiny");
            Console.WriteLine("Name= {0}, Intensity= {1}", m2.driverName, m2.driverIntensity);
            // driverName = "", driverIntensity = 7
            Motorcycle m3 = new Motorcycle(7);
            Console.WriteLine("Name= {0}, Intensity= {1}", m3.driverName, m3.driverIntensity);
        }
    }
}
