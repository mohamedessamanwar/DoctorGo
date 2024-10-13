using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addCOmment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentContent = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    DocktorId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Doctors_DocktorId",
                        column: x => x.DocktorId,
                        principalTable: "Doctors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 9, 28, 20, 499, DateTimeKind.Local).AddTicks(3249));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 9, 28, 20, 499, DateTimeKind.Local).AddTicks(3292));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 9, 28, 20, 499, DateTimeKind.Local).AddTicks(3295));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 9, 28, 20, 499, DateTimeKind.Local).AddTicks(3299));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 9, 28, 20, 499, DateTimeKind.Local).AddTicks(3302));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 9, 28, 20, 499, DateTimeKind.Local).AddTicks(3306));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 9, 28, 20, 499, DateTimeKind.Local).AddTicks(3310));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 9, 28, 20, 499, DateTimeKind.Local).AddTicks(3313));

            migrationBuilder.CreateIndex(
                name: "IX_Comments_DocktorId",
                table: "Comments",
                column: "DocktorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_DoctorId",
                table: "Comments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 8, 10, 21, 57, 961, DateTimeKind.Local).AddTicks(3559));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 8, 10, 21, 57, 961, DateTimeKind.Local).AddTicks(3609));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 8, 10, 21, 57, 961, DateTimeKind.Local).AddTicks(3613));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 8, 10, 21, 57, 961, DateTimeKind.Local).AddTicks(3617));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 8, 10, 21, 57, 961, DateTimeKind.Local).AddTicks(3620));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 8, 10, 21, 57, 961, DateTimeKind.Local).AddTicks(3624));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 8, 10, 21, 57, 961, DateTimeKind.Local).AddTicks(3627));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 8, 10, 21, 57, 961, DateTimeKind.Local).AddTicks(3630));
        }
    }
}
