using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Activities.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RowStatusId",
                table: "Row",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RowDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateStop = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateRegistration = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RowDto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowDtoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDto_RowDto_RowDtoId",
                        column: x => x.RowDtoId,
                        principalTable: "RowDto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "ActivityStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 2, 10, 17, 17, 49, 651, DateTimeKind.Local).AddTicks(8194));

            migrationBuilder.UpdateData(
                table: "ActivityStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateRegistration",
                value: new DateTime(2022, 2, 10, 17, 17, 49, 660, DateTimeKind.Local).AddTicks(6072));

            migrationBuilder.UpdateData(
                table: "ActivityStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateRegistration",
                value: new DateTime(2022, 2, 10, 17, 17, 49, 660, DateTimeKind.Local).AddTicks(6130));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 2, 10, 17, 17, 49, 662, DateTimeKind.Local).AddTicks(4732));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateRegistration",
                value: new DateTime(2022, 2, 10, 17, 17, 49, 662, DateTimeKind.Local).AddTicks(4708));

            migrationBuilder.UpdateData(
                table: "RowStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 2, 10, 17, 17, 49, 662, DateTimeKind.Local).AddTicks(3204));

            migrationBuilder.UpdateData(
                table: "RowStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateRegistration",
                value: new DateTime(2022, 2, 10, 17, 17, 49, 662, DateTimeKind.Local).AddTicks(3240));

            migrationBuilder.UpdateData(
                table: "RowStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateRegistration",
                value: new DateTime(2022, 2, 10, 17, 17, 49, 662, DateTimeKind.Local).AddTicks(3245));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 2, 10, 17, 17, 49, 662, DateTimeKind.Local).AddTicks(7756));

            migrationBuilder.CreateIndex(
                name: "IX_Row_RowStatusId",
                table: "Row",
                column: "RowStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDto_RowDtoId",
                table: "UserDto",
                column: "RowDtoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Row_RowStatus_RowStatusId",
                table: "Row",
                column: "RowStatusId",
                principalTable: "RowStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Row_RowStatus_RowStatusId",
                table: "Row");

            migrationBuilder.DropTable(
                name: "UserDto");

            migrationBuilder.DropTable(
                name: "RowDto");

            migrationBuilder.DropIndex(
                name: "IX_Row_RowStatusId",
                table: "Row");

            migrationBuilder.DropColumn(
                name: "RowStatusId",
                table: "Row");

            migrationBuilder.UpdateData(
                table: "ActivityStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 2, 10, 15, 1, 37, 86, DateTimeKind.Local).AddTicks(9426));

            migrationBuilder.UpdateData(
                table: "ActivityStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateRegistration",
                value: new DateTime(2022, 2, 10, 15, 1, 37, 94, DateTimeKind.Local).AddTicks(8114));

            migrationBuilder.UpdateData(
                table: "ActivityStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateRegistration",
                value: new DateTime(2022, 2, 10, 15, 1, 37, 94, DateTimeKind.Local).AddTicks(8169));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 2, 10, 15, 1, 37, 96, DateTimeKind.Local).AddTicks(6602));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateRegistration",
                value: new DateTime(2022, 2, 10, 15, 1, 37, 96, DateTimeKind.Local).AddTicks(6573));

            migrationBuilder.UpdateData(
                table: "RowStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 2, 10, 15, 1, 37, 96, DateTimeKind.Local).AddTicks(4968));

            migrationBuilder.UpdateData(
                table: "RowStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateRegistration",
                value: new DateTime(2022, 2, 10, 15, 1, 37, 96, DateTimeKind.Local).AddTicks(5004));

            migrationBuilder.UpdateData(
                table: "RowStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateRegistration",
                value: new DateTime(2022, 2, 10, 15, 1, 37, 96, DateTimeKind.Local).AddTicks(5009));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 2, 10, 15, 1, 37, 97, DateTimeKind.Local).AddTicks(1084));
        }
    }
}
