﻿// <auto-generated />
using System;
using BusFor.Models.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BusFor.Migrations
{
    [DbContext(typeof(EFDatabaseContext))]
    [Migration("20201215093227_New")]
    partial class New
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("BusFor.Models.DataModel.BusInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Date1")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date2")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Platform")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<TimeSpan>("Time1")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("Time2")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("BusInfos");
                });

            modelBuilder.Entity("BusFor.Models.DataModel.Passenger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("BusInfoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateRace")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Place")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BusPassengers");
                });
#pragma warning restore 612, 618
        }
    }
}
