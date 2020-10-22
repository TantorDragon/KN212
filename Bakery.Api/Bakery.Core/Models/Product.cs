using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Core.Models
{
    public class Product : Item
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; } 
    }
}
