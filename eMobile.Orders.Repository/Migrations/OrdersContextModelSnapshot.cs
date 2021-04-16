﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eMobile.Orders.Repository;

namespace eMobile.Orders.Repository.Migrations
{
    [DbContext(typeof(OrdersContext))]
    partial class OrdersContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("eMobile.Orders.Domain.DimensionsEntity.Dimensions", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<double>("Length")
                        .HasColumnType("float");

                    b.Property<Guid>("PhoneId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Width")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PhoneId")
                        .IsUnique();

                    b.ToTable("Dimensions");
                });

            modelBuilder.Entity("eMobile.Orders.Domain.DisplayEntity.Display", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("HorizontalResolution")
                        .HasColumnType("int");

                    b.Property<Guid>("PhoneId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Size")
                        .HasColumnType("float");

                    b.Property<int>("VerticalResolution")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PhoneId")
                        .IsUnique();

                    b.ToTable("Display");
                });

            modelBuilder.Entity("eMobile.Orders.Domain.MediaEntity.Media", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PhoneId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PhotoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PhoneId");

                    b.ToTable("Media");
                });

            modelBuilder.Entity("eMobile.Orders.Domain.OrdersEntity.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PhoneId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PhoneId")
                        .IsUnique();

                    b.ToTable("Order");
                });

            modelBuilder.Entity("eMobile.Orders.Domain.PhonesEntity.Phone", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CPUModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OS")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("RAM")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Phone");
                });

            modelBuilder.Entity("eMobile.Orders.Domain.ShippingAddressEntity.ShippingAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Address1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("ShippingAddress");
                });

            modelBuilder.Entity("eMobile.Orders.Domain.DimensionsEntity.Dimensions", b =>
                {
                    b.HasOne("eMobile.Orders.Domain.PhonesEntity.Phone", "Phone")
                        .WithOne("Dimensions")
                        .HasForeignKey("eMobile.Orders.Domain.DimensionsEntity.Dimensions", "PhoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Phone");
                });

            modelBuilder.Entity("eMobile.Orders.Domain.DisplayEntity.Display", b =>
                {
                    b.HasOne("eMobile.Orders.Domain.PhonesEntity.Phone", "Phone")
                        .WithOne("Display")
                        .HasForeignKey("eMobile.Orders.Domain.DisplayEntity.Display", "PhoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Phone");
                });

            modelBuilder.Entity("eMobile.Orders.Domain.MediaEntity.Media", b =>
                {
                    b.HasOne("eMobile.Orders.Domain.PhonesEntity.Phone", "Phone")
                        .WithMany("Media")
                        .HasForeignKey("PhoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Phone");
                });

            modelBuilder.Entity("eMobile.Orders.Domain.OrdersEntity.Order", b =>
                {
                    b.HasOne("eMobile.Orders.Domain.PhonesEntity.Phone", "Phone")
                        .WithOne("Order")
                        .HasForeignKey("eMobile.Orders.Domain.OrdersEntity.Order", "PhoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Phone");
                });

            modelBuilder.Entity("eMobile.Orders.Domain.ShippingAddressEntity.ShippingAddress", b =>
                {
                    b.HasOne("eMobile.Orders.Domain.OrdersEntity.Order", "Order")
                        .WithOne("ShippingAddress")
                        .HasForeignKey("eMobile.Orders.Domain.ShippingAddressEntity.ShippingAddress", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("eMobile.Orders.Domain.OrdersEntity.Order", b =>
                {
                    b.Navigation("ShippingAddress");
                });

            modelBuilder.Entity("eMobile.Orders.Domain.PhonesEntity.Phone", b =>
                {
                    b.Navigation("Dimensions");

                    b.Navigation("Display");

                    b.Navigation("Media");

                    b.Navigation("Order");
                });
#pragma warning restore 612, 618
        }
    }
}
