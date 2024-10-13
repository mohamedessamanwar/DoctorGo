 using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class modi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 12, 16, 45, 87, DateTimeKind.Local).AddTicks(9005));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 12, 16, 45, 87, DateTimeKind.Local).AddTicks(9067));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 12, 16, 45, 87, DateTimeKind.Local).AddTicks(9071));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 12, 16, 45, 87, DateTimeKind.Local).AddTicks(9074));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 12, 16, 45, 87, DateTimeKind.Local).AddTicks(9078));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 12, 16, 45, 87, DateTimeKind.Local).AddTicks(9081));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 12, 16, 45, 87, DateTimeKind.Local).AddTicks(9084));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 12, 16, 45, 87, DateTimeKind.Local).AddTicks(9087));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 12, 13, 51, 853, DateTimeKind.Local).AddTicks(2889));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 12, 13, 51, 853, DateTimeKind.Local).AddTicks(2941));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 12, 13, 51, 853, DateTimeKind.Local).AddTicks(2946));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 12, 13, 51, 853, DateTimeKind.Local).AddTicks(2950));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 12, 13, 51, 853, DateTimeKind.Local).AddTicks(2954));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 12, 13, 51, 853, DateTimeKind.Local).AddTicks(2957));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 12, 13, 51, 853, DateTimeKind.Local).AddTicks(2961));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 12, 13, 51, 853, DateTimeKind.Local).AddTicks(2964));
        }
    }
}
