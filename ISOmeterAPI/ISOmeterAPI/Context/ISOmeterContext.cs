using ISOmeterAPI.Context.Relationships;
using ISOmeterAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Metadata;

namespace ISOmeterAPI.Context
{
    public class ISOmeterContext : DbContext
    {
        public DbSet<Device> Devices { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }

        public ISOmeterContext(DbContextOptions<ISOmeterContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new DeviceEntityTypeConfiguration().Configure(modelBuilder.Entity<Device>());
            new RoomEntityTypeConfiguration().Configure(modelBuilder.Entity<Room>());
            new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());
        }
    }
}
