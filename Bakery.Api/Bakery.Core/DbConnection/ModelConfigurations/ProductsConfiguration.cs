﻿using Bakery.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bakery.Core.DbConnection.ModelConfigurations
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(b => b.ID).ValueGeneratedOnAdd();
            builder.HasData(
                new Product
                {
                    Type = ProductType.Marshmallow,
                    Name = "Яблучний зефір",
                    Description = "Зефір з натуральних продуктів з мінімальним вмістом цукру",
                    Price = 150
                },
                new Product
                {
                    Type = ProductType.Cupcakes,
                    Name = "Капкейки з шоколадом і лимоном",
                    Description = "Капкейки з лимонним присмаком та шматком шоколаду всередині",
                    Price = 20
                },
                new Product
                {
                    Type = ProductType.Cake,
                    Name = "Орео",
                    Description = "Торт з шоколадними коржами та сирною прослойкою",
                    Price = 200
                },
                new Product
                {
                    Type = ProductType.Homecake,
                    Name = "Фантазія",
                    Description = "Пляцок з кольоровими коржами, з кислинкою",
                    Price = 170
                });
        }
    }
}
