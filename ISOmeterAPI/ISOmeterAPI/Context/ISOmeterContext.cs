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
        public DbSet<Essay> Essays { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }

        public ISOmeterContext(DbContextOptions<ISOmeterContext> dbContextOptions) : base(dbContextOptions)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Name = "user",
                Surname = "user",
                Email = "user@user.com",
                Password = "password",
                UserType = "Admin",
                Status = true
            }
            );

            modelBuilder.Entity<Room>().HasData(
            new Room
            {
                Id = 1,
                Name = "Habitación 1",
                Description = "Habitación 1",
                UserId = 1,
                Status = true,
            }
            );

            new DeviceEntityTypeConfiguration().Configure(modelBuilder.Entity<Device>());
            new EssayEntityTypeConfiguration().Configure(modelBuilder.Entity<Essay>());
            new RoomEntityTypeConfiguration().Configure(modelBuilder.Entity<Room>());
            new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());
        }
    }
}
