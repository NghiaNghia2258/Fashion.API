using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("02cbc9fb-dbe9-43e0-9fb0-ed7142bcada5"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("97cef74d-1ef2-4a2c-b0b4-29e9311b82ff"));

            migrationBuilder.DeleteData(
                table: "RoleGroup",
                keyColumn: "Id",
                keyValue: new Guid("5288f826-25c3-4338-8a29-2e0f8532291c"));

            migrationBuilder.DeleteData(
                table: "RoleGroup",
                keyColumn: "Id",
                keyValue: new Guid("7bff95d5-00b0-48e9-b3fe-716a00636653"));

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "OrderItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Point",
                table: "Customer",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("dbec292f-b78f-4827-8884-96d3cdc523e1"), "Create_Product" },
                    { new Guid("ebc6dde5-10ba-4a03-9dfb-debd35288830"), "Find_Product" }
                });

            migrationBuilder.InsertData(
                table: "RoleGroup",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3d36f897-a4f6-4548-a232-8da01aca78e9"), "Admin" },
                    { new Guid("61c980d4-0a53-4e2a-9244-a1e7d2b7a84e"), "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("dbec292f-b78f-4827-8884-96d3cdc523e1"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("ebc6dde5-10ba-4a03-9dfb-debd35288830"));

            migrationBuilder.DeleteData(
                table: "RoleGroup",
                keyColumn: "Id",
                keyValue: new Guid("3d36f897-a4f6-4548-a232-8da01aca78e9"));

            migrationBuilder.DeleteData(
                table: "RoleGroup",
                keyColumn: "Id",
                keyValue: new Guid("61c980d4-0a53-4e2a-9244-a1e7d2b7a84e"));

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "Point",
                table: "Customer");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("02cbc9fb-dbe9-43e0-9fb0-ed7142bcada5"), "Find_Product" },
                    { new Guid("97cef74d-1ef2-4a2c-b0b4-29e9311b82ff"), "Create_Product" }
                });

            migrationBuilder.InsertData(
                table: "RoleGroup",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5288f826-25c3-4338-8a29-2e0f8532291c"), "User" },
                    { new Guid("7bff95d5-00b0-48e9-b3fe-716a00636653"), "Admin" }
                });
        }
    }
}
