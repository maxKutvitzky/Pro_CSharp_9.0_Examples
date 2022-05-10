using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterfaces
{
    class ThreeDCircle : Circle, IDraw3D
    {
        public void Draw()
        {
            Console.WriteLine("Drawing a 3D Circle");
        }
        public void Draw3D() => Console.WriteLine("Drawing Circle in 3D!");
    }
}
