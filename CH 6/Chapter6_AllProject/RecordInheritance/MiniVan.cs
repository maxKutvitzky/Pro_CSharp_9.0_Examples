using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//MiniVan.cs
namespace RecordInheritance
{
    //MiniVan record type
    public sealed record MiniVan : Car
    {
        public int Seating { get; init; }
        public MiniVan(string make, string model, string color, int seating) : base(make,
       model, color)
        {
            Seating = seating;
        }
    }
}