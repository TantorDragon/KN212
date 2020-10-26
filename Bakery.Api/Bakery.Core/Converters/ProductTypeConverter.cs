using Bakery.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bakery.Core.Converters
{
    public class ProductTypeConverter : JsonConverter<ProductType>
    {
        public override void Write(Utf8JsonWriter writer,
                              ProductType value,
                              JsonSerializerOptions options)
        {
            var result = value switch
            {
                ProductType.Cake => "Торт",
                ProductType.Cookies => "Печиво",
                ProductType.Cupcakes => "Капкейки",
                ProductType.Homecake => "Пляцок",
                ProductType.Marshmallow => "Зефір",
                ProductType.Muffins => "Маффіни",
                ProductType.Others => "Інша випічка",
                _=> "Undefined"
            };
            writer.WriteStringValue(result);
        }

        public override ProductType Read(ref Utf8JsonReader reader,
                                 Type typeToConvert,
                                 JsonSerializerOptions options)
        {
            return reader.GetString() switch
            {
                "Торт" => ProductType.Cake,
                "Печиво"=> ProductType.Cookies,
                "Капкейки" => ProductType.Cupcakes,
                "Пляцок" => ProductType.Homecake,
                "Зефір" => ProductType.Marshmallow,
                "Маффіни" => ProductType.Muffins,
                "Інша випічка" => ProductType.Others,
                _ => ProductType.Others
            };
        }
    }
}
