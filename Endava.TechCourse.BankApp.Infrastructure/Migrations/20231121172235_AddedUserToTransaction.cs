using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Endava.TechCourse.BankApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserToTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<Guid>(
                name: "DestinationUserId",
                table: "Transactions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SourceUserId",
                table: "Transactions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("ad74300a-7462-430d-98b6-1d1cd0ddbdb8"), null, "USER", "USER" },
                    { new Guid("b1c8e105-af19-4341-bb6c-2e65e697d34a"), null, "ADMIN", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "ChangeRate", "CurrencyCode", "Name" },
                values: new object[] { new Guid("7dbb95c5-b674-456f-b066-301bb7751569"), 1m, "MDL", "Leu Moldovenesc" });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_DestinationUserId",
                table: "Transactions",
                column: "DestinationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_SourceUserId",
                table: "Transactions",
                column: "SourceUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AspNetUsers_DestinationUserId",
                table: "Transactions",
                column: "DestinationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AspNetUsers_SourceUserId",
                table: "Transactions",
                column: "SourceUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AspNetUsers_DestinationUserId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AspNetUsers_SourceUserId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_DestinationUserId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_SourceUserId",
                table: "Transactions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ad74300a-7462-430d-98b6-1d1cd0ddbdb8"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b1c8e105-af19-4341-bb6c-2e65e697d34a"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("7dbb95c5-b674-456f-b066-301bb7751569"));

            migrationBuilder.DropColumn(
                name: "DestinationUserId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "SourceUserId",
                table: "Transactions");

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
        }
    }
}
