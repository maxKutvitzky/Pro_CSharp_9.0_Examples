using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLot.Samples.Models
{
    public class Car : BaseEntity
    {
        public string Color { get; set; }
        public string PetName { get; set; }
        public int MakeId { get; set; }
    }
}
