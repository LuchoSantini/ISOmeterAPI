﻿// <auto-generated />
using System;
using ISOmeterAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ISOmeterAPI.Migrations
{
    [DbContext(typeof(ISOmeterContext))]
    [Migration("20241001185330_change in entities")]
    partial class changeinentities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.33");

            modelBuilder.Entity("ISOmeterAPI.Data.Entities.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UniversalId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("ISOmeterAPI.Data.Entities.Measurement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ChangeDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("DeviceId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("Humidity")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("Temperature")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.ToTable("Measurement");
                });

            modelBuilder.Entity("ISOmeterAPI.Data.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Observations")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UserId1")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("ISOmeterAPI.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "user@user.com",
                            Name = "user",
                            Password = "password",
                            Status = true,
                            Surname = "user",
                            UserType = "Admin"
                        });
                });

            modelBuilder.Entity("ISOmeterAPI.Data.Entities.Device", b =>
                {
                    b.HasOne("ISOmeterAPI.Data.Entities.User", null)
                        .WithMany("Devices")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ISOmeterAPI.Data.Entities.Measurement", b =>
                {
                    b.HasOne("ISOmeterAPI.Data.Entities.Device", "Device")
                        .WithMany("Measurements")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");
                });

            modelBuilder.Entity("ISOmeterAPI.Data.Entities.Room", b =>
                {
                    b.HasOne("ISOmeterAPI.Data.Entities.Device", "Device")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ISOmeterAPI.Data.Entities.User", null)
                        .WithMany("Rooms")
                        .HasForeignKey("UserId1");

                    b.Navigation("Device");
                });

            modelBuilder.Entity("ISOmeterAPI.Data.Entities.Device", b =>
                {
                    b.Navigation("Measurements");
                });

            modelBuilder.Entity("ISOmeterAPI.Data.Entities.User", b =>
                {
                    b.Navigation("Devices");

                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
