﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(FashionStoresContext))]
    partial class FashionStoresContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone")
                        .HasMaxLength(13)
                        .IsUnicode(false)
                        .HasColumnType("char(13)")
                        .IsFixedLength();

                    b.Property<Guid?>("UserLoginId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK__Customer__3214EC074AD5E376");

                    b.HasIndex(new[] { "UserLoginId" }, "IX_Customer_UserLoginId");

                    b.HasIndex(new[] { "Phone" }, "UQ__Customer__5C7E359E1B940700")
                        .IsUnique()
                        .HasFilter("([Phone] IS NOT NULL)");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone")
                        .HasMaxLength(13)
                        .IsUnicode(false)
                        .HasColumnType("char(13)")
                        .IsFixedLength();

                    b.Property<string>("Position")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasDefaultValue("Nhân Viên");

                    b.Property<Guid?>("UserLoginId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK__Employee__3214EC0741CB445D");

                    b.HasIndex(new[] { "UserLoginId" }, "IX_Employee_UserLoginId");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CustomerNote")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<double?>("DiscountPercent")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<double?>("DiscountValue")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Note")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("char(255)")
                        .IsFixedLength();

                    b.Property<Guid?>("RecipientsInformationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("Tax")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid?>("VoucherId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK__Order__3214EC071334B5D6");

                    b.HasIndex(new[] { "CustomerId" }, "IX_Order_CustomerId");

                    b.HasIndex(new[] { "RecipientsInformationId" }, "IX_Order_RecipientsInformationId");

                    b.HasIndex(new[] { "VoucherId" }, "IX_Order_VoucherId");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("DiscountPercent")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<double?>("DiscountValue")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("float");

                    b.HasKey("Id")
                        .HasName("PK__OrderIte__3214EC076F1F5F8B");

                    b.HasIndex(new[] { "OrderId" }, "IX_OrderItem_OrderId");

                    b.HasIndex(new[] { "ProductId" }, "IX_OrderItem_ProductId");

                    b.ToTable("OrderItem", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Inventory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("MainImageUrl")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("char(255)")
                        .IsFixedLength();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("NameEn")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Name_En");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("PK__Product__3214EC0725E8E8FC");

                    b.HasIndex(new[] { "CategoryId" }, "IX_Product_CategoryId");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.ProductCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("PK__ProductC__3214EC07582867F3");

                    b.ToTable("ProductCategory", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.ProductImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK__ProductI__3214EC070BAF46A0");

                    b.HasIndex(new[] { "ProductId" }, "IX_ProductImage_ProductId");

                    b.ToTable("ProductImage", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.ProductRate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Review")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK__ProductR__3214EC07D1E4BE12");

                    b.HasIndex(new[] { "CustomerId" }, "IX_ProductRate_CustomerId");

                    b.HasIndex(new[] { "ProductId" }, "IX_ProductRate_ProductId");

                    b.ToTable("ProductRate", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.RecipientsInformation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("District")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Latitude")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Longiude")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("RecipientsName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("RecipientsNote")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("RecipientsPhone")
                        .IsRequired()
                        .HasMaxLength(13)
                        .IsUnicode(false)
                        .HasColumnType("char(13)")
                        .IsFixedLength();

                    b.Property<string>("Ward")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("PK__Recipien__3214EC070B21DBA6");

                    b.HasIndex(new[] { "CustomerId" }, "IX_RecipientsInformation_CustomerId");

                    b.ToTable("RecipientsInformation", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("PK__Role__3214EC07DA4F84DC");

                    b.ToTable("Role", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("b032f63b-1d72-4118-8e16-27302d6020b5"),
                            Name = "Create_Product"
                        },
                        new
                        {
                            Id = new Guid("2213cc53-c7ba-49a0-af30-deb85eaa56e1"),
                            Name = "Find_Product"
                        });
                });

            modelBuilder.Entity("Domain.Entities.RoleGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("PK__RoleGrou__3214EC07F2C32E25");

                    b.ToTable("RoleGroup", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("2cee39b2-9461-4253-9139-cb6868975241"),
                            Name = "Admin"
                        },
                        new
                        {
                            Id = new Guid("6a2d6cfa-4c2a-49dc-a06f-747627e0ac76"),
                            Name = "User"
                        });
                });

            modelBuilder.Entity("Domain.Entities.UserLogin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("RoleGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("PK__UserLogi__3214EC0753B5740E");

                    b.HasIndex(new[] { "RoleGroupId" }, "IX_UserLogin_RoleGroupId");

                    b.HasIndex(new[] { "Username" }, "UQ__UserLogi__536C85E4CC1A22D1")
                        .IsUnique();

                    b.ToTable("UserLogin", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Voucher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<double?>("DiscountPercent")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<double?>("DiscountValue")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("Redemptions")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("VoucherCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("char(50)")
                        .IsFixedLength();

                    b.HasKey("Id")
                        .HasName("PK__Voucher__3214EC07734077BB");

                    b.HasIndex(new[] { "VoucherCode" }, "UQ__Voucher__7F0ABCA9AFCF4FF9")
                        .IsUnique();

                    b.ToTable("Voucher", (string)null);
                });

            modelBuilder.Entity("RoleGroupAndRole", b =>
                {
                    b.Property<Guid>("RoleGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoleGroupId", "RoleId")
                        .HasName("PK__RoleGrou__003F8CCD9982EA3E");

                    b.HasIndex(new[] { "RoleId" }, "IX_RoleGroupAndRole_RoleId");

                    b.ToTable("RoleGroupAndRole", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Customer", b =>
                {
                    b.HasOne("Domain.Entities.UserLogin", "UserLogin")
                        .WithMany("Customers")
                        .HasForeignKey("UserLoginId")
                        .HasConstraintName("FK_Customer_Userlogin");

                    b.Navigation("UserLogin");
                });

            modelBuilder.Entity("Domain.Entities.Employee", b =>
                {
                    b.HasOne("Domain.Entities.UserLogin", "UserLogin")
                        .WithMany("Employees")
                        .HasForeignKey("UserLoginId")
                        .HasConstraintName("FK_Employee_Userlogin");

                    b.Navigation("UserLogin");
                });

            modelBuilder.Entity("Domain.Entities.Order", b =>
                {
                    b.HasOne("Domain.Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_Order_Customer");

                    b.HasOne("Domain.Entities.RecipientsInformation", "RecipientsInformation")
                        .WithMany("Orders")
                        .HasForeignKey("RecipientsInformationId")
                        .HasConstraintName("FK_Order_RecipientsInformation");

                    b.HasOne("Domain.Entities.Voucher", "Voucher")
                        .WithMany("Orders")
                        .HasForeignKey("VoucherId")
                        .HasConstraintName("FK_Order_Voucher");

                    b.Navigation("Customer");

                    b.Navigation("RecipientsInformation");

                    b.Navigation("Voucher");
                });

            modelBuilder.Entity("Domain.Entities.OrderItem", b =>
                {
                    b.HasOne("Domain.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK_OrderItem_Order");

                    b.HasOne("Domain.Entities.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_OrderItem_Product");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.HasOne("Domain.Entities.ProductCategory", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Product_Category");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Domain.Entities.ProductImage", b =>
                {
                    b.HasOne("Domain.Entities.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_ProductImage_Product");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Domain.Entities.ProductRate", b =>
                {
                    b.HasOne("Domain.Entities.Customer", "Customer")
                        .WithMany("ProductRates")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_ProductRate_Customer");

                    b.HasOne("Domain.Entities.Product", "Product")
                        .WithMany("ProductRates")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_ProductRate_Product");

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Domain.Entities.RecipientsInformation", b =>
                {
                    b.HasOne("Domain.Entities.Customer", "Customer")
                        .WithMany("RecipientsInformations")
                        .HasForeignKey("CustomerId")
                        .IsRequired()
                        .HasConstraintName("FK_RecipientsInformation_Customer");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Domain.Entities.UserLogin", b =>
                {
                    b.HasOne("Domain.Entities.RoleGroup", "RoleGroup")
                        .WithMany("UserLogins")
                        .HasForeignKey("RoleGroupId")
                        .IsRequired()
                        .HasConstraintName("FK_UserLogin_RoleGroup");

                    b.Navigation("RoleGroup");
                });

            modelBuilder.Entity("RoleGroupAndRole", b =>
                {
                    b.HasOne("Domain.Entities.RoleGroup", null)
                        .WithMany()
                        .HasForeignKey("RoleGroupId")
                        .IsRequired()
                        .HasConstraintName("FK_RoleGroupAndRole_RoleGroup");

                    b.HasOne("Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("FK_RoleGroupAndRole_Role");
                });

            modelBuilder.Entity("Domain.Entities.Customer", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("ProductRates");

                    b.Navigation("RecipientsInformations");
                });

            modelBuilder.Entity("Domain.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.Navigation("OrderItems");

                    b.Navigation("ProductImages");

                    b.Navigation("ProductRates");
                });

            modelBuilder.Entity("Domain.Entities.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Domain.Entities.RecipientsInformation", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Domain.Entities.RoleGroup", b =>
                {
                    b.Navigation("UserLogins");
                });

            modelBuilder.Entity("Domain.Entities.UserLogin", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Domain.Entities.Voucher", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
