using ISOmeterAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ISOmeterAPI.Context.Relationships
{
    public class DeviceEntityTypeConfiguration
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder
                .HasMany(d => d.DeviceHistory)
                .WithOne(dh => dh.Device)
                .HasForeignKey(dh => dh.DeviceId);
        }
    }
}
