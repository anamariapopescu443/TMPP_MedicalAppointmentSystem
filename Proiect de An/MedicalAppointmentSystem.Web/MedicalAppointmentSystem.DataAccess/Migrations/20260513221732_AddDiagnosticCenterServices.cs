using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalAppointmentSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddDiagnosticCenterServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "HospitalId", "Name" },
                values: new object[,]
                {
                    { 5, 3, "Laboratory" },
                    { 6, 3, "Radiology" }
                });

            migrationBuilder.InsertData(
                table: "MedicalServices",
                columns: new[] { "Id", "DepartmentId", "Description", "DurationMinutes", "Name", "Price" },
                values: new object[,]
                {
                    { 6, 5, "Basic laboratory blood analysis.", 15, "Blood Test", 180m },
                    { 7, 6, "Ultrasound diagnostic investigation.", 30, "Ultrasound Investigation", 500m },
                    { 8, 6, "Radiology investigation for diagnostic purposes.", 20, "X-Ray Investigation", 350m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MedicalServices",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MedicalServices",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MedicalServices",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
