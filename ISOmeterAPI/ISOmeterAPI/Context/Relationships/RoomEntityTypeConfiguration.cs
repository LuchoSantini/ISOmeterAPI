using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using ISOmeterAPI.Data.Entities;
using System.Reflection.Emit;

namespace ISOmeterAPI.Context.Relationships
{
    public class RoomEntityTypeConfiguration
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder
                .HasOne(r => r.Device)
                .WithOne(d => d.Room)
                .HasForeignKey<Device>(d => d.RoomId);
        }
    }
}
