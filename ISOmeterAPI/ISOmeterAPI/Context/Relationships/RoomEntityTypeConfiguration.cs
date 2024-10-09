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
                .HasMany(r => r.Devices)
                .WithOne(d => d.Room)
                .HasForeignKey(d => d.RoomId);

            builder
                .HasMany(r => r.Essays)
                .WithOne(e => e.Room)
                .HasForeignKey(e => e.RoomId);
        }
    }
}
