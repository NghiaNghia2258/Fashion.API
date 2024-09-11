using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVoucher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropColumn(
                name: "Redemptions",
                table: "Voucher");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Voucher",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MaxDiscountValue",
                table: "Voucher",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MinOrdervalue",
                table: "Voucher",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Voucher",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Voucher",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsageLimit",
                table: "Voucher",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsedCount",
                table: "Voucher",
                type: "int",
                nullable: true);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("21135a77-935a-46d9-8ce7-9571d2233f5c"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("d5e3ee84-5efa-47cd-b009-faa849a5a74d"));

            migrationBuilder.DeleteData(
                table: "RoleGroup",
                keyColumn: "Id",
                keyValue: new Guid("7f03b2da-e40e-42cf-946d-defe75ddc577"));

            migrationBuilder.DeleteData(
                table: "RoleGroup",
                keyColumn: "Id",
                keyValue: new Guid("b479e87e-ac98-4812-ac42-3c807dc84eed"));

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "MaxDiscountValue",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "MinOrdervalue",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "UsageLimit",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "UsedCount",
                table: "Voucher");

            migrationBuilder.AddColumn<int>(
                name: "Redemptions",
                table: "Voucher",
                type: "int",
                nullable: true,
                defaultValue: 1);

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
    }
}
