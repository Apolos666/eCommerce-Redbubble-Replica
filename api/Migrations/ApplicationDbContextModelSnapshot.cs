﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Data;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("api.Models.ColorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ColorHexCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ColorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ColorHexCode")
                        .IsUnique();

                    b.HasIndex("ColorName")
                        .IsUnique();

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("api.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ProductDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("api.Models.ProductAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductAttributeOptionId")
                        .HasColumnType("int");

                    b.HasKey("Id", "ProductId", "ProductAttributeOptionId");

                    b.HasIndex("ProductAttributeOptionId");

                    b.HasIndex("ProductId", "ProductAttributeOptionId")
                        .IsUnique();

                    b.ToTable("ProductAttributes");
                });

            modelBuilder.Entity("api.Models.ProductAttributeOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AttributeOptionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductAttributeTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductAttributeTypeId");

                    b.ToTable("ProductAttributeOptions");
                });

            modelBuilder.Entity("api.Models.ProductAttributeType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AttributeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AttributeName")
                        .IsUnique();

                    b.ToTable("ProductAttributeTypes");
                });

            modelBuilder.Entity("api.Models.ProductCategory", b =>
                {
                    b.Property<int>("ProductCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductCategoryId"));

                    b.Property<string>("CategoryDescription")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("CategoryImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("SizeCategoryId")
                        .HasColumnType("int");

                    b.HasKey("ProductCategoryId");

                    b.HasIndex("ParentCategoryId");

                    b.HasIndex("SizeCategoryId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("api.Models.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageFileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductItemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductItemId");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("api.Models.ProductItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<decimal>("OriginalPrice")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("SalePrice")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ColorId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductItems");
                });

            modelBuilder.Entity("api.Models.ProductSizeVariation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductItemId")
                        .HasColumnType("int");

                    b.Property<int>("SizeOptionsId")
                        .HasColumnType("int");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("int");

                    b.HasKey("Id", "ProductItemId", "SizeOptionsId");

                    b.HasIndex("SizeOptionsId");

                    b.HasIndex("ProductItemId", "SizeOptionsId")
                        .IsUnique();

                    b.ToTable("ProductSizeVariations");
                });

            modelBuilder.Entity("api.Models.SizeCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("SizeCategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SizeCategories");
                });

            modelBuilder.Entity("api.Models.SizeOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SizeCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("SizeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SizeCategoryId");

                    b.ToTable("SizeOptions");
                });

            modelBuilder.Entity("api.Models.Product", b =>
                {
                    b.HasOne("api.Models.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("api.Models.ProductAttribute", b =>
                {
                    b.HasOne("api.Models.ProductAttributeOption", "ProductAttributeOption")
                        .WithMany("ProductAttributes")
                        .HasForeignKey("ProductAttributeOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Product", "Product")
                        .WithMany("ProductAttributes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ProductAttributeOption");
                });

            modelBuilder.Entity("api.Models.ProductAttributeOption", b =>
                {
                    b.HasOne("api.Models.ProductAttributeType", "ProductAttributeType")
                        .WithMany("ProductAttributeOptions")
                        .HasForeignKey("ProductAttributeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductAttributeType");
                });

            modelBuilder.Entity("api.Models.ProductCategory", b =>
                {
                    b.HasOne("api.Models.ProductCategory", "ParentProductCategory")
                        .WithMany()
                        .HasForeignKey("ParentCategoryId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("api.Models.SizeCategory", "SizeCategory")
                        .WithMany("ProductCategories")
                        .HasForeignKey("SizeCategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ParentProductCategory");

                    b.Navigation("SizeCategory");
                });

            modelBuilder.Entity("api.Models.ProductImage", b =>
                {
                    b.HasOne("api.Models.ProductItem", "ProductItem")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductItem");
                });

            modelBuilder.Entity("api.Models.ProductItem", b =>
                {
                    b.HasOne("api.Models.ColorModel", "ColorModel")
                        .WithMany()
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Product", "Product")
                        .WithMany("ProductItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ColorModel");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("api.Models.ProductSizeVariation", b =>
                {
                    b.HasOne("api.Models.ProductItem", "ProductItem")
                        .WithMany("ProductSizeVariations")
                        .HasForeignKey("ProductItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.SizeOption", "SizeOption")
                        .WithMany("ProductSizeVariations")
                        .HasForeignKey("SizeOptionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductItem");

                    b.Navigation("SizeOption");
                });

            modelBuilder.Entity("api.Models.SizeOption", b =>
                {
                    b.HasOne("api.Models.SizeCategory", "SizeCategory")
                        .WithMany("SizeOptions")
                        .HasForeignKey("SizeCategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("SizeCategory");
                });

            modelBuilder.Entity("api.Models.Product", b =>
                {
                    b.Navigation("ProductAttributes");

                    b.Navigation("ProductItems");
                });

            modelBuilder.Entity("api.Models.ProductAttributeOption", b =>
                {
                    b.Navigation("ProductAttributes");
                });

            modelBuilder.Entity("api.Models.ProductAttributeType", b =>
                {
                    b.Navigation("ProductAttributeOptions");
                });

            modelBuilder.Entity("api.Models.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("api.Models.ProductItem", b =>
                {
                    b.Navigation("ProductImages");

                    b.Navigation("ProductSizeVariations");
                });

            modelBuilder.Entity("api.Models.SizeCategory", b =>
                {
                    b.Navigation("ProductCategories");

                    b.Navigation("SizeOptions");
                });

            modelBuilder.Entity("api.Models.SizeOption", b =>
                {
                    b.Navigation("ProductSizeVariations");
                });
#pragma warning restore 612, 618
        }
    }
}
