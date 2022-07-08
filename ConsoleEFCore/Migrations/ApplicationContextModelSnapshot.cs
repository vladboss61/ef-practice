﻿// <auto-generated />
using System;
using ConsoleEFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConsoleEFCore.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ConsoleEFCore.DbModels.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CarId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Name_Car");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Car", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Audi",
                            Size = 250
                        },
                        new
                        {
                            Id = 2,
                            Name = "Ford",
                            Size = 350
                        });
                });

            modelBuilder.Entity("ConsoleEFCore.DbModels.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CompanyId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("FoundationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Revenue")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Company", (string)null);
                });

            modelBuilder.Entity("ConsoleEFCore.DbModels.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProductId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("ConsoleEFCore.DbModels.ProductVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("ProductVersion");
                });

            modelBuilder.Entity("ConsoleEFCore.DbModels.SupplyHistory", b =>
                {
                    b.Property<int>("SupplyHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplyHistoryId"), 1L, 1);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ShipmentDate")
                        .HasColumnType("datetime2");

                    b.HasKey("SupplyHistoryId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ProductId");

                    b.ToTable("SupplyHistory");
                });

            modelBuilder.Entity("ConsoleEFCore.DbModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HiredDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("ConsoleEFCore.DbModels.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserProfile", (string)null);
                });

            modelBuilder.Entity("ConsoleEFCore.DbModels.Company", b =>
                {
                    b.HasOne("ConsoleEFCore.DbModels.Product", null)
                        .WithMany("Companies")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("ConsoleEFCore.DbModels.ProductVersion", b =>
                {
                    b.HasOne("ConsoleEFCore.DbModels.Product", "Product")
                        .WithOne("ProductVersion")
                        .HasForeignKey("ConsoleEFCore.DbModels.ProductVersion", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ConsoleEFCore.DbModels.SupplyHistory", b =>
                {
                    b.HasOne("ConsoleEFCore.DbModels.Company", "Company")
                        .WithMany("SupplyHistory")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsoleEFCore.DbModels.Product", "Product")
                        .WithMany("SupplyHistory")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ConsoleEFCore.DbModels.User", b =>
                {
                    b.HasOne("ConsoleEFCore.DbModels.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("ConsoleEFCore.DbModels.UserProfile", b =>
                {
                    b.HasOne("ConsoleEFCore.DbModels.User", "User")
                        .WithOne("Profile")
                        .HasForeignKey("ConsoleEFCore.DbModels.UserProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ConsoleEFCore.DbModels.Company", b =>
                {
                    b.Navigation("SupplyHistory");
                });

            modelBuilder.Entity("ConsoleEFCore.DbModels.Product", b =>
                {
                    b.Navigation("Companies");

                    b.Navigation("ProductVersion");

                    b.Navigation("SupplyHistory");
                });

            modelBuilder.Entity("ConsoleEFCore.DbModels.User", b =>
                {
                    b.Navigation("Profile");
                });
#pragma warning restore 612, 618
        }
    }
}