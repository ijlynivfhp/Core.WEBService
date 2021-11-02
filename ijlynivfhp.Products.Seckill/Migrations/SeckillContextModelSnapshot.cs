﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ijlynivfhp.Projects.SeckillServices.Context;

namespace ijlynivfhp.Projects.SeckillServices.Migrations
{
    [DbContext(typeof(SeckillContext))]
    partial class SeckillContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ijlynivfhp.Projects.SeckillServices.Models.Seckill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("SeckillDescription")
                        .HasColumnType("text");

                    b.Property<int>("SeckillIstop")
                        .HasColumnType("int");

                    b.Property<int>("SeckillLimit")
                        .HasColumnType("int");

                    b.Property<string>("SeckillName")
                        .HasColumnType("text");

                    b.Property<string>("SeckillPercent")
                        .HasColumnType("text");

                    b.Property<decimal>("SeckillPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("SeckillStatus")
                        .HasColumnType("int");

                    b.Property<int>("SeckillStock")
                        .HasColumnType("int");

                    b.Property<int>("SeckillType")
                        .HasColumnType("int");

                    b.Property<string>("SeckillUrl")
                        .HasColumnType("text");

                    b.Property<int>("TimeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Seckills");
                });

            modelBuilder.Entity("ijlynivfhp.Projects.SeckillServices.Models.SeckillRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Createtime")
                        .HasColumnType("datetime");

                    b.Property<string>("OrderSn")
                        .HasColumnType("text");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("RecordStatus")
                        .HasColumnType("int");

                    b.Property<decimal>("RecordTotalprice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("SeckillId")
                        .HasColumnType("int");

                    b.Property<int>("SeckillNum")
                        .HasColumnType("int");

                    b.Property<decimal>("SeckillPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("Updatetime")
                        .HasColumnType("datetime");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SeckillRecords");
                });

            modelBuilder.Entity("ijlynivfhp.Projects.SeckillServices.Models.SeckillTimeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("SeckillDate")
                        .HasColumnType("text");

                    b.Property<string>("SeckillEndtime")
                        .HasColumnType("text");

                    b.Property<string>("SeckillStarttime")
                        .HasColumnType("text");

                    b.Property<int>("TimeStatus")
                        .HasColumnType("int");

                    b.Property<string>("TimeTitleUrl")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SeckillTimeModels");
                });
#pragma warning restore 612, 618
        }
    }
}
