using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Endava.TechCourse.BankApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserToWallet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b51284df-cc4d-41b4-a72a-c9b1ca5933da"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cc8c64e1-4fda-4f82-a67f-54f607abf805"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("e2e37dff-977a-4758-a90a-d60884f7da10"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Wallets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0b031255-0e82-4793-a15f-1aabf093c713"), null, "ADMIN", "ADMIN" },
                    { new Guid("98c122be-9833-4f22-a3bf-8e994d53368d"), null, "USER", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "ChangeRate", "CurrencyCode", "Name" },
                values: new object[] { new Guid("d50bd5a1-9e89-4244-bc36-2c0ad82f46f5"), 1m, "MDL", "Leu Moldovenesc" });

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_UserId",
                table: "Wallets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wallets_AspNetUsers_UserId",
                table: "Wallets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_AspNetUsers_UserId",
                table: "Wallets");

            migrationBuilder.DropIndex(
                name: "IX_Wallets_UserId",
                table: "Wallets");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0b031255-0e82-4793-a15f-1aabf093c713"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("98c122be-9833-4f22-a3bf-8e994d53368d"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("d50bd5a1-9e89-4244-bc36-2c0ad82f46f5"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Wallets");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("b51284df-cc4d-41b4-a72a-c9b1ca5933da"), null, "USER", "USER" },
                    { new Guid("cc8c64e1-4fda-4f82-a67f-54f607abf805"), null, "ADMIN", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "ChangeRate", "CurrencyCode", "Name" },
                values: new object[] { new Guid("e2e37dff-977a-4758-a90a-d60884f7da10"), 1m, "MDL", "Leu Moldovenesc" });
        }
    }
}
