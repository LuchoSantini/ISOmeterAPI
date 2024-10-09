using ISOmeterAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ISOmeterAPI.Context.Relationships
{
    public class UserEntityTypeConfiguration
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasMany(u => u.Rooms)
                .WithOne()
                .HasForeignKey(r => r.UserId);
        }
    }
}
