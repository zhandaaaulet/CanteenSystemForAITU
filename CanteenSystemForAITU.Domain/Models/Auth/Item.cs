using System;
using System.Collections.Generic;
using System.Text;

namespace CanteenSystemForAITU.Domain.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsBad { get; set; }
    }
}
