using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Activities.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ActivityStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 4, 26, 17, 12, 54, 542, DateTimeKind.Local).AddTicks(5342));

            migrationBuilder.UpdateData(
                table: "ActivityStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateRegistration",
                value: new DateTime(2022, 4, 26, 17, 12, 54, 546, DateTimeKind.Local).AddTicks(5321));

            migrationBuilder.UpdateData(
                table: "ActivityStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateRegistration",
                value: new DateTime(2022, 4, 26, 17, 12, 54, 546, DateTimeKind.Local).AddTicks(5386));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 4, 26, 17, 12, 54, 548, DateTimeKind.Local).AddTicks(1264));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateRegistration",
                value: new DateTime(2022, 4, 26, 17, 12, 54, 548, DateTimeKind.Local).AddTicks(1260));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateRegistration",
                value: new DateTime(2022, 4, 26, 17, 12, 54, 548, DateTimeKind.Local).AddTicks(1238));

            migrationBuilder.UpdateData(
                table: "RowStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 4, 26, 17, 12, 54, 547, DateTimeKind.Local).AddTicks(9928));

            migrationBuilder.UpdateData(
                table: "RowStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateRegistration",
                value: new DateTime(2022, 4, 26, 17, 12, 54, 547, DateTimeKind.Local).AddTicks(9983));

            migrationBuilder.UpdateData(
                table: "RowStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateRegistration",
                value: new DateTime(2022, 4, 26, 17, 12, 54, 547, DateTimeKind.Local).AddTicks(9991));

            migrationBuilder.UpdateData(
                table: "RowStatus",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateRegistration",
                value: new DateTime(2022, 4, 26, 17, 12, 54, 547, DateTimeKind.Local).AddTicks(9998));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 4, 26, 17, 12, 54, 548, DateTimeKind.Local).AddTicks(3899));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ActivityStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 4, 12, 12, 10, 36, 301, DateTimeKind.Local).AddTicks(4129));

            migrationBuilder.UpdateData(
                table: "ActivityStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateRegistration",
                value: new DateTime(2022, 4, 12, 12, 10, 36, 304, DateTimeKind.Local).AddTicks(3302));

            migrationBuilder.UpdateData(
                table: "ActivityStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateRegistration",
                value: new DateTime(2022, 4, 12, 12, 10, 36, 304, DateTimeKind.Local).AddTicks(3428));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 4, 12, 12, 10, 36, 305, DateTimeKind.Local).AddTicks(6235));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateRegistration",
                value: new DateTime(2022, 4, 12, 12, 10, 36, 305, DateTimeKind.Local).AddTicks(6231));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateRegistration",
                value: new DateTime(2022, 4, 12, 12, 10, 36, 305, DateTimeKind.Local).AddTicks(6216));

            migrationBuilder.UpdateData(
                table: "RowStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 4, 12, 12, 10, 36, 305, DateTimeKind.Local).AddTicks(5166));

            migrationBuilder.UpdateData(
                table: "RowStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateRegistration",
                value: new DateTime(2022, 4, 12, 12, 10, 36, 305, DateTimeKind.Local).AddTicks(5203));

            migrationBuilder.UpdateData(
                table: "RowStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateRegistration",
                value: new DateTime(2022, 4, 12, 12, 10, 36, 305, DateTimeKind.Local).AddTicks(5207));

            migrationBuilder.UpdateData(
                table: "RowStatus",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateRegistration",
                value: new DateTime(2022, 4, 12, 12, 10, 36, 305, DateTimeKind.Local).AddTicks(5210));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 4, 12, 12, 10, 36, 305, DateTimeKind.Local).AddTicks(8248));
        }
    }
}
