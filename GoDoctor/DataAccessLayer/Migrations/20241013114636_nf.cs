using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class nf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 14, 46, 35, 671, DateTimeKind.Local).AddTicks(9027));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 14, 46, 35, 671, DateTimeKind.Local).AddTicks(9069));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 14, 46, 35, 671, DateTimeKind.Local).AddTicks(9072));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 14, 46, 35, 671, DateTimeKind.Local).AddTicks(9076));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 14, 46, 35, 671, DateTimeKind.Local).AddTicks(9079));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 14, 46, 35, 671, DateTimeKind.Local).AddTicks(9082));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 14, 46, 35, 671, DateTimeKind.Local).AddTicks(9085));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 14, 46, 35, 671, DateTimeKind.Local).AddTicks(9088));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 13, 47, 36, 285, DateTimeKind.Local).AddTicks(7693));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 13, 47, 36, 285, DateTimeKind.Local).AddTicks(7735));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 13, 47, 36, 285, DateTimeKind.Local).AddTicks(7739));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 13, 47, 36, 285, DateTimeKind.Local).AddTicks(7742));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 13, 47, 36, 285, DateTimeKind.Local).AddTicks(7745));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 13, 47, 36, 285, DateTimeKind.Local).AddTicks(7748));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 13, 47, 36, 285, DateTimeKind.Local).AddTicks(7751));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 13, 47, 36, 285, DateTimeKind.Local).AddTicks(7754));
        }
    }
}
