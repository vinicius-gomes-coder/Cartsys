﻿// <auto-generated />
using System;
using CartSysAPI.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CartSysAPI.Migrations
{
    [DbContext(typeof(CartsysContext))]
    [Migration("20240716174248_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CartSysAPI.Model.PersonModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Address");

                    b.Property<int?>("Age")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("Age");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });
#pragma warning restore 612, 618
        }
    }
}
