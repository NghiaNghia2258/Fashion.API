using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2213cc53-c7ba-49a0-af30-deb85eaa56e1"), "Find_Product" },
                    { new Guid("b032f63b-1d72-4118-8e16-27302d6020b5"), "Create_Product" }
                });

            migrationBuilder.InsertData(
                table: "RoleGroup",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2cee39b2-9461-4253-9139-cb6868975241"), "Admin" },
                    { new Guid("6a2d6cfa-4c2a-49dc-a06f-747627e0ac76"), "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("2213cc53-c7ba-49a0-af30-deb85eaa56e1"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b032f63b-1d72-4118-8e16-27302d6020b5"));

            migrationBuilder.DeleteData(
                table: "RoleGroup",
                keyColumn: "Id",
                keyValue: new Guid("2cee39b2-9461-4253-9139-cb6868975241"));

            migrationBuilder.DeleteData(
                table: "RoleGroup",
                keyColumn: "Id",
                keyValue: new Guid("6a2d6cfa-4c2a-49dc-a06f-747627e0ac76"));
        }
    }
}
