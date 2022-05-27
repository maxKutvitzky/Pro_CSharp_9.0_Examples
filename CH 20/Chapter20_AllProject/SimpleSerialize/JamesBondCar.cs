using System;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Serialization;
namespace SimpleSerialize
{
    public class JamesBondCar : Car
    {
        public bool CanFly;
        public bool CanSubmerge;
        public override string ToString() => $"CanFly:{CanFly}, CanSubmerge:{CanSubmerge} {base.ToString()}";
    }
}
