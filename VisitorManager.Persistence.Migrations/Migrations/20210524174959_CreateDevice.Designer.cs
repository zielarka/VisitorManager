// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VisitorManager.Persistence.Migrations;

namespace VisitorManager.Persistence.Migrations.Migrations
{
    [DbContext(typeof(DataContext_Sqlite))]
    [Migration("20210524174959_CreateDevice")]
    partial class CreateDevice
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity("VisitorManager.Core.Domain.Device", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("LastActive");

                    b.Property<string>("Name");

                    b.Property<string>("SerialNumber");

                    b.Property<int?>("StoreId");

                    b.HasKey("Id");

                    b.ToTable("Device");
                });

            modelBuilder.Entity("VisitorManager.Core.Domain.Store", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<float>("Latitude");

                    b.Property<float>("Longitude");

                    b.Property<string>("Name");

                    b.Property<string>("PostalCode");

                    b.Property<string>("ResponsiblePerson");

                    b.Property<string>("SID");

                    b.Property<string>("Street");

                    b.HasKey("Id");

                    b.ToTable("Store");
                });

            modelBuilder.Entity("VisitorManager.Core.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("LastActive");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}
