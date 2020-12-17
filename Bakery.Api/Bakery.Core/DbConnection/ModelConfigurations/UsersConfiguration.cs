using Bakery.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
                    ID = 1,
                    Login="MainAdmin",
                    Password="MyBakeryCabinet"
                }
                );
        }
    }
}
