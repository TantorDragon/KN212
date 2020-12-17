using Bakery.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Globalization;

namespace Bakery.Core.DbConnection.ModelConfigurations
{
    public class OrdersConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(b => b.ID).ValueGeneratedOnAdd();
            builder.HasData(
                new Order
                {
                    ID = 1,
                    DateCreated = DateTime.ParseExact("23.10.2020", "dd.MM.yyyy", CultureInfo.InvariantCulture),
                    ClientName = "Оксана",
                    PhoneNumber = "380992847194",
                    Email = "oks.karpa12@gmail.com",
                    OrderType = ProductType.Cupcakes,
                    Description = "Добрий день! Я б хотіла замовити капкейки на Хеловін у дитячий садок. Потрібно 18 штук.",
                    IsActive = true
                },
                new Order
                {
                    ID = 2,
                    DateCreated = DateTime.ParseExact("24.10.2020", "dd.MM.yyyy", CultureInfo.InvariantCulture),
                    ClientName = "Олег",
                    PhoneNumber = "380979205389",
                    Email = "markiv.o.p@gmail.com",
                    OrderType = ProductType.Cake,
                    Description = "Потрібен торт на ювілей 50 років чоловіку. Щось не дуже солодке.",
                    IsActive = true
                },
                new Order
                {
                    ID = 3,
                    DateCreated = DateTime.ParseExact("25.10.2020", "dd.MM.yyyy", CultureInfo.InvariantCulture),
                    ClientName = "Юлія",
                    PhoneNumber = "380956192064",
                    Email = "little.me83@gmail.com",
                    OrderType = ProductType.Homecake,
                    Description = "Хочу замовити 5 пляцків на невелике весілля",
                    IsActive = true
                });
        }
    }
}
