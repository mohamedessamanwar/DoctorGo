using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addmodi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinic_Docktor_DocktorId",
                table: "Clinic");

            migrationBuilder.DropForeignKey(
                name: "FK_Docktor_AspNetUsers_ApplicationUserId",
                table: "Docktor");

            migrationBuilder.DropForeignKey(
                name: "FK_Docktor_Specialty_SpecialtyId",
                table: "Docktor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Docktor",
                table: "Docktor");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Clinic");

            migrationBuilder.RenameTable(
                name: "Docktor",
                newName: "Doctors");

            migrationBuilder.RenameIndex(
                name: "IX_Docktor_SpecialtyId",
                table: "Doctors",
                newName: "IX_Doctors_SpecialtyId");

            migrationBuilder.RenameIndex(
                name: "IX_Docktor_ApplicationUserId",
                table: "Doctors",
                newName: "IX_Doctors_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 5, 1, 30, 53, 717, DateTimeKind.Local).AddTicks(7643));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 5, 1, 30, 53, 717, DateTimeKind.Local).AddTicks(7693));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 5, 1, 30, 53, 717, DateTimeKind.Local).AddTicks(7698));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 5, 1, 30, 53, 717, DateTimeKind.Local).AddTicks(7702));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 5, 1, 30, 53, 717, DateTimeKind.Local).AddTicks(7705));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 5, 1, 30, 53, 717, DateTimeKind.Local).AddTicks(7709));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 5, 1, 30, 53, 717, DateTimeKind.Local).AddTicks(7713));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 5, 1, 30, 53, 717, DateTimeKind.Local).AddTicks(7716));

            migrationBuilder.AddForeignKey(
                name: "FK_Clinic_Doctors_DocktorId",
                table: "Clinic",
                column: "DocktorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_AspNetUsers_ApplicationUserId",
                table: "Doctors",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Specialty_SpecialtyId",
                table: "Doctors",
                column: "SpecialtyId",
                principalTable: "Specialty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinic_Doctors_DocktorId",
                table: "Clinic");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_AspNetUsers_ApplicationUserId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Specialty_SpecialtyId",
                table: "Doctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors");

            migrationBuilder.RenameTable(
                name: "Doctors",
                newName: "Docktor");

            migrationBuilder.RenameIndex(
                name: "IX_Doctors_SpecialtyId",
                table: "Docktor",
                newName: "IX_Docktor_SpecialtyId");

            migrationBuilder.RenameIndex(
                name: "IX_Doctors_ApplicationUserId",
                table: "Docktor",
                newName: "IX_Docktor_ApplicationUserId");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Clinic",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Docktor",
                table: "Docktor",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 4, 11, 1, 26, 291, DateTimeKind.Local).AddTicks(4476));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 4, 11, 1, 26, 291, DateTimeKind.Local).AddTicks(4531));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 4, 11, 1, 26, 291, DateTimeKind.Local).AddTicks(4534));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 4, 11, 1, 26, 291, DateTimeKind.Local).AddTicks(4538));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 4, 11, 1, 26, 291, DateTimeKind.Local).AddTicks(4541));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 4, 11, 1, 26, 291, DateTimeKind.Local).AddTicks(4544));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 4, 11, 1, 26, 291, DateTimeKind.Local).AddTicks(4548));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 4, 11, 1, 26, 291, DateTimeKind.Local).AddTicks(4551));

            migrationBuilder.AddForeignKey(
                name: "FK_Clinic_Docktor_DocktorId",
                table: "Clinic",
                column: "DocktorId",
                principalTable: "Docktor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Docktor_AspNetUsers_ApplicationUserId",
                table: "Docktor",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Docktor_Specialty_SpecialtyId",
                table: "Docktor",
                column: "SpecialtyId",
                principalTable: "Specialty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
