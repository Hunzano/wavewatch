﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WaveWatchApi.Data;

#nullable disable

namespace WaveWatchApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WaveWatchApi.Models.ESP32Data", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DeviceStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Esp32MacAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rssi")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("WifiSsid")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Esp32Data");
                });

            modelBuilder.Entity("WaveWatchApi.Models.FormDataModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstRecordTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastRecordMac")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastRecordSsid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastRecordTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaxRssi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MinRssi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TotalRecords")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FormDataModels");
                });
#pragma warning restore 612, 618
        }
    }
}
