﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Test2.Data;

#nullable disable

namespace Test2.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250609090720_InitialCreate2")]
    partial class InitialCreate2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Test2.models.AvailableProgram", b =>
                {
                    b.Property<int>("AvailableProgramId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AvailableProgramId"));

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProgramId")
                        .HasColumnType("int");

                    b.Property<int>("WashingMachineId")
                        .HasColumnType("int");

                    b.HasKey("AvailableProgramId");

                    b.HasIndex("ProgramId");

                    b.HasIndex("WashingMachineId");

                    b.ToTable("AvailablePrograms");

                    b.HasData(
                        new
                        {
                            AvailableProgramId = 1,
                            Price = 15m,
                            ProgramId = 1,
                            WashingMachineId = 1
                        },
                        new
                        {
                            AvailableProgramId = 2,
                            Price = 20m,
                            ProgramId = 2,
                            WashingMachineId = 1
                        },
                        new
                        {
                            AvailableProgramId = 3,
                            Price = 18m,
                            ProgramId = 1,
                            WashingMachineId = 2
                        });
                });

            modelBuilder.Entity("Test2.models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            FirstName = "Al",
                            LastName = "Smith",
                            PhoneNumber = "123456789"
                        },
                        new
                        {
                            CustomerId = 2,
                            FirstName = "Bob",
                            LastName = "Johnson",
                            PhoneNumber = "987654322"
                        });
                });

            modelBuilder.Entity("Test2.models.PurchaseHistory", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("AvailableProgramId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.HasKey("CustomerId", "AvailableProgramId");

                    b.HasIndex("AvailableProgramId");

                    b.ToTable("PurchaseHistories");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            AvailableProgramId = 1,
                            PurchaseDate = new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Rating = 5
                        },
                        new
                        {
                            CustomerId = 2,
                            AvailableProgramId = 2,
                            PurchaseDate = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Rating = 4
                        });
                });

            modelBuilder.Entity("Test2.models.WashProgram", b =>
                {
                    b.Property<int>("ProgramId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProgramId"));

                    b.Property<int>("DurationMinutes")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProgramId");

                    b.ToTable("PROGRAM", (string)null);

                    b.HasData(
                        new
                        {
                            ProgramId = 1,
                            DurationMinutes = 30,
                            Name = "firstWash"
                        },
                        new
                        {
                            ProgramId = 2,
                            DurationMinutes = 60,
                            Name = "Eco Wash"
                        });
                });

            modelBuilder.Entity("Test2.models.WashingMachine", b =>
                {
                    b.Property<int>("WashingMachineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WashingMachineId"));

                    b.Property<decimal>("MaxWeight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WashingMachineId");

                    b.ToTable("WashingMachines");

                    b.HasData(
                        new
                        {
                            WashingMachineId = 1,
                            MaxWeight = 8m,
                            SerialNumber = "WM2012/S431/12"
                        },
                        new
                        {
                            WashingMachineId = 2,
                            MaxWeight = 10m,
                            SerialNumber = "WM2012/S931/12"
                        });
                });

            modelBuilder.Entity("Test2.models.AvailableProgram", b =>
                {
                    b.HasOne("Test2.models.WashProgram", "WashProgram")
                        .WithMany("AvailablePrograms")
                        .HasForeignKey("ProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Test2.models.WashingMachine", "WashingMachine")
                        .WithMany("AvailablePrograms")
                        .HasForeignKey("WashingMachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WashProgram");

                    b.Navigation("WashingMachine");
                });

            modelBuilder.Entity("Test2.models.PurchaseHistory", b =>
                {
                    b.HasOne("Test2.models.AvailableProgram", "AvailableProgram")
                        .WithMany("PurchaseHistories")
                        .HasForeignKey("AvailableProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Test2.models.Customer", "Customer")
                        .WithMany("PurchaseHistories")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AvailableProgram");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Test2.models.AvailableProgram", b =>
                {
                    b.Navigation("PurchaseHistories");
                });

            modelBuilder.Entity("Test2.models.Customer", b =>
                {
                    b.Navigation("PurchaseHistories");
                });

            modelBuilder.Entity("Test2.models.WashProgram", b =>
                {
                    b.Navigation("AvailablePrograms");
                });

            modelBuilder.Entity("Test2.models.WashingMachine", b =>
                {
                    b.Navigation("AvailablePrograms");
                });
#pragma warning restore 612, 618
        }
    }
}
