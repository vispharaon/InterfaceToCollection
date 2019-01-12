using System;
using System.Collections.Generic;

namespace InterfaceToCollection.Model
{
    public partial class AptRenovationItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateChanged { get; set; }
        public string Description { get; set; }
        public decimal? Cost { get; set; }
        public decimal EstimatedCost { get; set; }
        public byte Status { get; set; }
    }
}
