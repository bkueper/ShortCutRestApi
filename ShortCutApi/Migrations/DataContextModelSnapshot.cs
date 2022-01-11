﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ShortCutApi.Data;

namespace ShortCutApi.Migrations
{
    [DbContext(typeof(ShortCutContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ShortCutApi.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Adress")
                        .HasColumnType("text");

                    b.Property<string>("EMail")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("phonenumber")
                        .HasColumnType("text");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ShortCutApi.Models.Machine", b =>
                {
                    b.Property<int>("MachineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<string>("MachineName")
                        .HasColumnType("text");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("text");

                    b.Property<string>("url")
                        .HasColumnType("text");

                    b.HasKey("MachineId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("ShortCutApi.Models.Machine", b =>
                {
                    b.HasOne("ShortCutApi.Models.Customer", "customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.Navigation("customer");
                });
#pragma warning restore 612, 618
        }
    }
}
