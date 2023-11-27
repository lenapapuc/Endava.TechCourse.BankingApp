using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Endava.TechCourse.BankApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RoleConfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
