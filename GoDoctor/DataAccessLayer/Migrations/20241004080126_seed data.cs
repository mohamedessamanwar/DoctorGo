using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsValid",
                table: "Docktor",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Clinic",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Specialty",
                columns: new[] { "Id", "CreatedDate", "Description", "IsDeleted", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 4, 11, 1, 26, 291, DateTimeKind.Local).AddTicks(4476), "Heart and cardiovascular system specialists.", false, "Cardiology", null },
                    { 2, new DateTime(2024, 10, 4, 11, 1, 26, 291, DateTimeKind.Local).AddTicks(4531), "Specializes in the treatment of nervous system disorders.", false, "Neurology", null },
                    { 3, new DateTime(2024, 10, 4, 11, 1, 26, 291, DateTimeKind.Local).AddTicks(4534), "Treats skin conditions and diseases.", false, "Dermatology", null },
                    { 4, new DateTime(2024, 10, 4, 11, 1, 26, 291, DateTimeKind.Local).AddTicks(4538), "Focused on children's health and well-being.", false, "Pediatrics", null },
                    { 5, new DateTime(2024, 10, 4, 11, 1, 26, 291, DateTimeKind.Local).AddTicks(4541), "Treats conditions related to bones, joints, and muscles.", false, "Orthopedics", null },
                    { 6, new DateTime(2024, 10, 4, 11, 1, 26, 291, DateTimeKind.Local).AddTicks(4544), "Specializes in the diagnosis and treatment of eye disorders.", false, "Ophthalmology", null },
                    { 7, new DateTime(2024, 10, 4, 11, 1, 26, 291, DateTimeKind.Local).AddTicks(4548), "Focuses on the health of the female reproductive systems.", false, "Gynecology", null },
                    { 8, new DateTime(2024, 10, 4, 11, 1, 26, 291, DateTimeKind.Local).AddTicks(4551), "Specializes in diagnosing and treating cancer.", false, "Oncology", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Clinic");

            migrationBuilder.AlterColumn<bool>(
                name: "IsValid",
                table: "Docktor",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);
        }
    }
}
