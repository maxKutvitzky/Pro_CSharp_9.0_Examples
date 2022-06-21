using System;
using System.Collections.Generic;

#nullable disable

namespace AutoLot.Models.Entities
{
    public partial class Driver
    {
        public Driver()
        {
            CarDrivers = new HashSet<CarDriver>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] TimeStamp { get; set; }

        public virtual ICollection<CarDriver> CarDrivers { get; set; }
    }
}
