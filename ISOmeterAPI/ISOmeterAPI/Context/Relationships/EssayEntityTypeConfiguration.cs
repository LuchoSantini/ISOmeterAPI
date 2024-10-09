using ISOmeterAPI.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ISOmeterAPI.Context.Relationships
{
    public class EssayEntityTypeConfiguration
    {
        public void Configure(EntityTypeBuilder<Essay> builder)
        {
            builder
                .HasMany(e => e.Measurements)
                .WithOne()
                .HasForeignKey(m => m.EssayId);
        }
    }
}
