using Bakery.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

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
                    DateCreated = DateTime.Parse("23/10/2020"),
                    ClientName = "Оксана",
                    PhoneNumber = "380992847194",
                    Email="oks.karpa12@gmail.com",
                    OrderType = ProductType.Cupcakes,
                    Description = "Добрий день! Я б хотіла замовити капкейки на Хеловін у дитячий садок. Потрібно 18 штук.",
                    IsActive = true
                },
                new Order 
                {
                    DateCreated = DateTime.Parse("24/10/2020"),
                    ClientName = "Олег",
                    PhoneNumber = "380979205389",
                    Email = "markiv.o.p@gmail.com",
                    OrderType = ProductType.Cake,
                    Description = "Потрібен торт на ювілей 50 років чоловіку. Щось не дуже солодке.",
                    IsActive = true
                },
                new Order
                {
                    DateCreated = DateTime.Parse("24/10/2020"),
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
