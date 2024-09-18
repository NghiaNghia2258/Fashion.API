using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.RenameColumn(
                name: "MinOrdervalue",
                table: "Voucher",
                newName: "MinOrderValue");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentStatus",
                table: "Order",
                type: "int",
                unicode: false,
                fixedLength: true,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(255)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 255);

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("4daf0a71-1393-4efb-a86c-684a1f753ca2"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("95269f65-79ae-4232-b041-70f3ac76a33a"));

            migrationBuilder.DeleteData(
                table: "RoleGroup",
                keyColumn: "Id",
                keyValue: new Guid("5084bfdd-9dd4-44b6-a3d5-cb5f12891bbc"));

            migrationBuilder.DeleteData(
                table: "RoleGroup",
                keyColumn: "Id",
                keyValue: new Guid("ff415af1-838e-4b3d-be08-e75ce344282e"));

            migrationBuilder.RenameColumn(
                name: "MinOrderValue",
                table: "Voucher",
                newName: "MinOrdervalue");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentStatus",
                table: "Order",
                type: "char(255)",
                unicode: false,
                fixedLength: true,
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("21135a77-935a-46d9-8ce7-9571d2233f5c"), "Find_Product" },
                    { new Guid("d5e3ee84-5efa-47cd-b009-faa849a5a74d"), "Create_Product" }
                });

            migrationBuilder.InsertData(
                table: "RoleGroup",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("7f03b2da-e40e-42cf-946d-defe75ddc577"), "User" },
                    { new Guid("b479e87e-ac98-4812-ac42-3c807dc84eed"), "Admin" }
                });
        }
    }
}
