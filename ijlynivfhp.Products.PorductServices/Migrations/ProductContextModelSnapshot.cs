﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ijlynivfhp.Projects.ProductServices.Context;

namespace ijlynivfhp.Projects.ProductServices.Migrations
{
    [DbContext(typeof(ProductContext))]
    partial class ProductContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ijlynivfhp.Projects.ProductServices.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ProductCode")
                        .HasColumnType("text");

                    b.Property<string>("ProductDescription")
                        .HasColumnType("text");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("ProductSold")
                        .HasColumnType("int");

                    b.Property<int>("ProductSort")
                        .HasColumnType("int");

                    b.Property<string>("ProductStatus")
                        .HasColumnType("text");

                    b.Property<int>("ProductStock")
                        .HasColumnType("int");

                    b.Property<string>("ProductTitle")
                        .HasColumnType("text");

                    b.Property<string>("ProductUrl")
                        .HasColumnType("text");

                    b.Property<decimal>("ProductVirtualprice")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ijlynivfhp.Projects.ProductServices.Models.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ImageSort")
                        .HasColumnType("int");

                    b.Property<string>("ImageStatus")
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProductImages");
                });
#pragma warning restore 612, 618
        }
    }
}
