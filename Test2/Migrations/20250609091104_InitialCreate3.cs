using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Test2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PROGRAM",
                columns: new[] { "ProgramId", "DurationMinutes", "Name" },
                values: new object[,]
                {
                    { 3, 60, "Cotton Cycle" },
                    { 4, 60, "Synthetic" }
                });

            migrationBuilder.InsertData(
                table: "AvailablePrograms",
                columns: new[] { "AvailableProgramId", "Price", "ProgramId", "WashingMachineId" },
                values: new object[,]
                {
                    { 4, 13m, 3, 2 },
                    { 5, 12m, 4, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AvailablePrograms",
                keyColumn: "AvailableProgramId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AvailablePrograms",
                keyColumn: "AvailableProgramId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PROGRAM",
                keyColumn: "ProgramId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PROGRAM",
                keyColumn: "ProgramId",
                keyValue: 4);
        }
    }
}
