using System;
using System.Collections.Generic;

#nullable disable

namespace AutoLot.Models.Entities
{
    public partial class Make
    {
        public Make()
        {
            Inventories = new HashSet<Inventory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] TimeStamp { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
