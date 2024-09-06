using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTableProductVariant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Product",
                table: "OrderItem");


            migrationBuilder.DropColumn(
                name: "Color",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Inventory",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "OrderItem",
                newName: "ProductVariantId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_ProductId",
                table: "OrderItem",
                newName: "IX_OrderItem_ProductVariantId");

            migrationBuilder.CreateTable(
                name: "ProductVariant",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Inventory = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductVariant_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariant_ProductId",
                table: "ProductVariant",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_ProductVariant_ProductVariantId",
                table: "OrderItem",
                column: "ProductVariantId",
                principalTable: "ProductVariant",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_ProductVariant_ProductVariantId",
                table: "OrderItem");

            migrationBuilder.DropTable(
                name: "ProductVariant");

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

            migrationBuilder.RenameColumn(
                name: "ProductVariantId",
                table: "OrderItem",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_ProductVariantId",
                table: "OrderItem",
                newName: "IX_OrderItem_ProductId");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Product",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Inventory",
                table: "Product",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Product",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Product",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Product",
                table: "OrderItem",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");
        }
    }
}
