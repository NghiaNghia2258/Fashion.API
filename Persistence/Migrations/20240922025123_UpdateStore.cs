using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
         

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerPhone",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoucherCode",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("78bc2968-ecb4-4f0a-8c59-ac6db294703a"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("e6c3df13-f741-4951-b04c-54825a177d1e"));

            migrationBuilder.DeleteData(
                table: "RoleGroup",
                keyColumn: "Id",
                keyValue: new Guid("b0be3f56-e27c-4fde-8acd-b6aa99e1fa40"));

            migrationBuilder.DeleteData(
                table: "RoleGroup",
                keyColumn: "Id",
                keyValue: new Guid("e392a6ef-4fd7-4633-b340-1d100f185a7f"));

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CustomerPhone",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "VoucherCode",
                table: "Order");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0ae3a80c-80cb-498f-ae77-2747d045e97d"), "Find_Product" },
                    { new Guid("f39cd486-654c-4210-b2a7-ad1d6c5e2997"), "Create_Product" }
                });

            migrationBuilder.InsertData(
                table: "RoleGroup",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("01551139-d99f-4fc0-8299-2a9bf905b5ba"), "User" },
                    { new Guid("3273b318-6453-4a1e-abc3-052c873442e7"), "Admin" }
                });
        }
    }
}
