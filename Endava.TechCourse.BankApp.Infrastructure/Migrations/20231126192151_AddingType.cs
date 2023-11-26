using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Endava.TechCourse.BankApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Type",
                table: "Wallets");

            migrationBuilder.AddColumn<Guid>(
                name: "TypeId",
                table: "Wallets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WalletTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Commission = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("465a9279-f4e8-45d6-a96e-2ea30c3c0e73"), null, "ADMIN", "ADMIN" },
                    { new Guid("f9db75b3-e649-4d82-bedd-b41fc8f396cf"), null, "USER", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "ChangeRate", "CurrencyCode", "Name" },
                values: new object[] { new Guid("51009ea5-71c0-4667-a416-081883827c2e"), 1m, "MDL", "Leu Moldovenesc" });

            migrationBuilder.InsertData(
                table: "WalletTypes",
                columns: new[] { "Id", "Commission", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("17819156-d436-48d1-9cc1-ba596fe25eb3"), 4m, "Second Best", "Gold" },
                    { new Guid("35835223-6781-48fc-84ec-d43a57c0910c"), 5m, "Third Best", "Silver" },
                    { new Guid("52c82fff-62b7-4a68-85c1-4f914078d548"), 10m, "Fourth Best", "Basic" },
                    { new Guid("707e5684-5996-4c87-b73b-518917efaf1b"), 3m, "The best type of card, has the smallest commission", "Platinum" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_TypeId",
                table: "Wallets",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wallets_WalletTypes_TypeId",
                table: "Wallets",
                column: "TypeId",
                principalTable: "WalletTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_WalletTypes_TypeId",
                table: "Wallets");

            migrationBuilder.DropTable(
                name: "WalletTypes");

            migrationBuilder.DropIndex(
                name: "IX_Wallets_TypeId",
                table: "Wallets");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("465a9279-f4e8-45d6-a96e-2ea30c3c0e73"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f9db75b3-e649-4d82-bedd-b41fc8f396cf"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("51009ea5-71c0-4667-a416-081883827c2e"));

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Wallets");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Wallets",
                type: "nvarchar(max)",
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
        }
    }
}
