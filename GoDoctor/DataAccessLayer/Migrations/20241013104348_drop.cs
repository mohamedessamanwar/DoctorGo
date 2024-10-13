using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class drop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 13, 43, 47, 999, DateTimeKind.Local).AddTicks(1234));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 13, 43, 47, 999, DateTimeKind.Local).AddTicks(1284));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 13, 43, 47, 999, DateTimeKind.Local).AddTicks(1288));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 13, 43, 47, 999, DateTimeKind.Local).AddTicks(1291));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 13, 43, 47, 999, DateTimeKind.Local).AddTicks(1294));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 13, 43, 47, 999, DateTimeKind.Local).AddTicks(1297));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 13, 43, 47, 999, DateTimeKind.Local).AddTicks(1301));

            migrationBuilder.UpdateData(
                table: "Specialty",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 13, 13, 43, 47, 999, DateTimeKind.Local).AddTicks(1305));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CommentContent = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocktorId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
    }
}
