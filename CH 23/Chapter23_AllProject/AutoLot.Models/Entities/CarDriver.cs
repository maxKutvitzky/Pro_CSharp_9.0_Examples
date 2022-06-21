using System;
using System.Collections.Generic;

#nullable disable

namespace AutoLot.Models.Entities
{
    public partial class CarDriver
    {
        public int CarsId { get; set; }
        public int DriversId { get; set; }

        public virtual Inventory Cars { get; set; }
        public virtual Driver Drivers { get; set; }
    }
}
