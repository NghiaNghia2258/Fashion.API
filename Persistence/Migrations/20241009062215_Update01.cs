using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Update01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Voucher",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "UserLogin",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "RoleGroup",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Role",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "RecipientsInformation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "ProductVariant",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "ProductRate",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "ProductImage",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "ProductCategory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "OrderItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Customer",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedName",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Debt",
                table: "Customer",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "UserLogin");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "RoleGroup");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "RecipientsInformation");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "ProductVariant");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "ProductRate");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "ProductImage");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "ProductCategory");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "CreatedName",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Debt",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Customer");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("42194cf4-7c2b-4201-b559-469803081d1e"), "Create_Product" },
                    { new Guid("d6236232-b245-46d5-9518-f9036867c7f8"), "Find_Product" }
                });

            migrationBuilder.InsertData(
                table: "RoleGroup",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0636f5c9-4ba6-44d4-822f-768dfe41ff1d"), "Admin" },
                    { new Guid("849715e5-c727-4421-a45f-e112ae397bda"), "User" }
                });
        }
    }
}
