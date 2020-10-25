using Bakery.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Core.DbConnection.ModelConfigurations
{
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(b => b.ID).ValueGeneratedOnAdd();
            builder.HasData(
                new User 
                {
                    Login="MainAdmin",
                    Password="MyBakeryCabinet"
                }
                );
        }
    }
}
