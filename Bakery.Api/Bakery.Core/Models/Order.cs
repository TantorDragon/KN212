using Bakery.Core.Converters;
using System;
using System.Text.Json.Serialization;

namespace Bakery.Core.Models
{
    public class Order : Item
    {
        public DateTime DateCreated { get; set; }

        public string Description { get; set; }

        public string PhoneNumber { get; set; }

        [JsonConverter(typeof(ProductTypeConverter))]
        public ProductType OrderType { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public string ClientName { get; set; }
    }
}
