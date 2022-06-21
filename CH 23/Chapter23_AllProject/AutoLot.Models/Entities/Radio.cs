using System;
using System.Collections.Generic;

#nullable disable

namespace AutoLot.Models.Entities
{
    public partial class Radio
    {
        public int Id { get; set; }
        public bool HasTweeters { get; set; }
        public bool HasSubWoofers { get; set; }
        public string RadioId { get; set; }
        public int CarId { get; set; }
        public byte[] TimeStamp { get; set; }

        public virtual Inventory Car { get; set; }
    }
}
