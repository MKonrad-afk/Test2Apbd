using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Test2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Al", "Smith", "123456789" },
                    { 2, "Bob", "Johnson", "987654322" }
                });

            migrationBuilder.InsertData(
                table: "PROGRAM",
                columns: new[] { "ProgramId", "DurationMinutes", "Name" },
                values: new object[,]
                {
                    { 1, 30, "firstWash" },
                    { 2, 60, "Eco Wash" }
                });

            migrationBuilder.InsertData(
                table: "WashingMachines",
                columns: new[] { "WashingMachineId", "MaxWeight", "SerialNumber" },
                values: new object[,]
                {
                    { 1, 8m, "WM2012/S431/12" },
                    { 2, 10m, "WM2012/S931/12" }
                });

            migrationBuilder.InsertData(
                table: "AvailablePrograms",
                columns: new[] { "AvailableProgramId", "Price", "ProgramId", "WashingMachineId" },
                values: new object[,]
                {
                    { 1, 15m, 1, 1 },
                    { 2, 20m, 2, 1 },
                    { 3, 18m, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "PurchaseHistories",
                columns: new[] { "AvailableProgramId", "CustomerId", "PurchaseDate", "Rating" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 2, 2, new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AvailablePrograms",
                keyColumn: "AvailableProgramId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PurchaseHistories",
                keyColumns: new[] { "AvailableProgramId", "CustomerId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PurchaseHistories",
                keyColumns: new[] { "AvailableProgramId", "CustomerId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "AvailablePrograms",
                keyColumn: "AvailableProgramId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AvailablePrograms",
                keyColumn: "AvailableProgramId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WashingMachines",
                keyColumn: "WashingMachineId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PROGRAM",
                keyColumn: "ProgramId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PROGRAM",
                keyColumn: "ProgramId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WashingMachines",
                keyColumn: "WashingMachineId",
                keyValue: 1);
        }
    }
}
