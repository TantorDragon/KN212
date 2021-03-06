﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Bakery.Core.Models
{
    public enum ProductType
    {
        [EnumMember(Value ="Торт")]
        Cake,
        [EnumMember(Value = "Пляцок")]
        Homecake,
        [EnumMember(Value = "Зефір")]
        Marshmallow,
        [EnumMember(Value = "Печиво")]
        Cookies,
        [EnumMember(Value = "Капкейки")]
        Cupcakes,
        [EnumMember(Value = "Маффіни")]
        Muffins,
        [EnumMember(Value = "Інша випічка")]
        Others
    }
}
