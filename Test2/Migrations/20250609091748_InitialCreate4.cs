using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PROGRAM",
                columns: new[] { "ProgramId", "DurationMinutes", "Name" },
                values: new object[] { 5, 15, "Quick Wash" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PROGRAM",
                keyColumn: "ProgramId",
                keyValue: 5);
        }
    }
}
