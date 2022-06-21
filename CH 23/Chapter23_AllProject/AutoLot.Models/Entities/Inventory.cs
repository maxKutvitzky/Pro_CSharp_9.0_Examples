using System;
using System.Collections.Generic;

#nullable disable

namespace AutoLot.Models.Entities
{
    public partial class Inventory
    {
        public Inventory()
        {
            CarDrivers = new HashSet<CarDriver>();
            Radios = new HashSet<Radio>();
        }

        public int Id { get; set; }
        public string Color { get; set; }
        public string PetName { get; set; }
        public int MakeId { get; set; }
        public byte[] TimeStamp { get; set; }

        public virtual Make Make { get; set; }
        public virtual ICollection<CarDriver> CarDrivers { get; set; }
        public virtual ICollection<Radio> Radios { get; set; }
    }
}
