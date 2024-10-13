using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class updatecontext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_UserId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Doctors_DoctorId",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_UserId",
                table: "Comments",
                newName: "IX_Comments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_DoctorId",
                table: "Comments",
                newName: "IX_Comments_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 16, 33, 36, 632, DateTimeKind.Local).AddTicks(7590));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 16, 33, 36, 632, DateTimeKind.Local).AddTicks(7644));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 16, 33, 36, 632, DateTimeKind.Local).AddTicks(7648));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 16, 33, 36, 632, DateTimeKind.Local).AddTicks(7653));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 16, 33, 36, 632, DateTimeKind.Local).AddTicks(7657));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 16, 33, 36, 632, DateTimeKind.Local).AddTicks(7661));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 16, 33, 36, 632, DateTimeKind.Local).AddTicks(7665));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 16, 33, 36, 632, DateTimeKind.Local).AddTicks(7670));

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Doctors_DoctorId",
                table: "Comments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Doctors_DoctorId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId",
                table: "Comment",
                newName: "IX_Comment_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_DoctorId",
                table: "Comment",
                newName: "IX_Comment_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_UserId",
                table: "Comment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Doctors_DoctorId",
                table: "Comment",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
