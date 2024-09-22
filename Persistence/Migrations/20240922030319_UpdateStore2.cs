using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStore2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "Order",
                type: "float",
                nullable: true);

          
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("42194cf4-7c2b-4201-b559-469803081d1e"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("d6236232-b245-46d5-9518-f9036867c7f8"));

            migrationBuilder.DeleteData(
                table: "RoleGroup",
                keyColumn: "Id",
                keyValue: new Guid("0636f5c9-4ba6-44d4-822f-768dfe41ff1d"));

            migrationBuilder.DeleteData(
                table: "RoleGroup",
                keyColumn: "Id",
                keyValue: new Guid("849715e5-c727-4421-a45f-e112ae397bda"));

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Order");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("78bc2968-ecb4-4f0a-8c59-ac6db294703a"), "Create_Product" },
                    { new Guid("e6c3df13-f741-4951-b04c-54825a177d1e"), "Find_Product" }
                });

            migrationBuilder.InsertData(
                table: "RoleGroup",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("b0be3f56-e27c-4fde-8acd-b6aa99e1fa40"), "Admin" },
                    { new Guid("e392a6ef-4fd7-4633-b340-1d100f185a7f"), "User" }
                });
        }
    }
}
