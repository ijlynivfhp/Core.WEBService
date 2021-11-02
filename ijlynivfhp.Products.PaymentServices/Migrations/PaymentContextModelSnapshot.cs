﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ijlynivfhp.Projects.PaymentServices.Context;

namespace ijlynivfhp.Projects.PaymentServices.Migrations
{
    [DbContext(typeof(PaymentContext))]
    partial class PaymentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ijlynivfhp.Projects.PaymentServices.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Createtime")
                        .HasColumnType("datetime");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("PaymentCode")
                        .HasColumnType("text");

                    b.Property<string>("PaymentErrorInfo")
                        .HasColumnType("text");

                    b.Property<string>("PaymentErrorNo")
                        .HasColumnType("text");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("text");

                    b.Property<string>("PaymentPrice")
                        .HasColumnType("text");

                    b.Property<string>("PaymentRemark")
                        .HasColumnType("text");

                    b.Property<string>("PaymentReturnUrl")
                        .HasColumnType("text");

                    b.Property<string>("PaymentStatus")
                        .HasColumnType("text");

                    b.Property<int>("PaymentType")
                        .HasColumnType("int");

                    b.Property<string>("PaymentUrl")
                        .HasColumnType("text");

                    b.Property<DateTime>("Updatetime")
                        .HasColumnType("datetime");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}
