using Bakery.Core.Converters;
using System.Text.Json.Serialization;

namespace Bakery.Core.Models
{
    public class Product : Item
    {
        [JsonConverter(typeof(ProductTypeConverter))]
        public ProductType Type { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; } 
    }
}
