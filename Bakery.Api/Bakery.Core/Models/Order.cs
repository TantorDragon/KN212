using System;
using System.Collections.Generic;

namespace Bakery.Core.Models
{
    public class Order : Item
    {
        public DateTime DateCreated { get; set; }

        public string Description { get; set; }

        public string PhoneNumber { get; set; }

        public ProductType OrderType { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public string ClientName { get; set; }
    }
}
