using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalAppointmentSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddHospitalType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Hospitals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Type" },
                values: new object[] { "Medpark, Spital Internațional", 2 });

            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "Address", "Description", "Name", "PhoneNumber", "Type" },
                values: new object[] { 3, "Bd. Stefan cel Mare 100, Chisinau", "Centru medical specializat in investigatii si diagnostic.", "Centru de Diagnostica Chisinau", "022000003", 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Hospitals");

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Medpark International Hospital");
        }
    }
}
