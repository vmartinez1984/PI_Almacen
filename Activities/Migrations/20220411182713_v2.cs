using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Activities.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Row_RowEntityId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_RowEntityId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RowEntityId",
                table: "User");

            migrationBuilder.UpdateData(
                table: "ActivityStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 4, 11, 13, 27, 13, 367, DateTimeKind.Local).AddTicks(5090));

            migrationBuilder.UpdateData(
                table: "ActivityStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateRegistration",
                value: new DateTime(2022, 4, 11, 13, 27, 13, 369, DateTimeKind.Local).AddTicks(6171));

            migrationBuilder.UpdateData(
                table: "ActivityStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateRegistration",
                value: new DateTime(2022, 4, 11, 13, 27, 13, 369, DateTimeKind.Local).AddTicks(6205));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 4, 11, 13, 27, 13, 370, DateTimeKind.Local).AddTicks(7213));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateRegistration", "Name" },
                values: new object[] { new DateTime(2022, 4, 11, 13, 27, 13, 370, DateTimeKind.Local).AddTicks(7210), "Colaborador" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "DateRegistration", "Description", "IsActive", "Name" },
                values: new object[] { 3, new DateTime(2022, 4, 11, 13, 27, 13, 370, DateTimeKind.Local).AddTicks(7197), null, true, "Lider de equipo" });

            migrationBuilder.UpdateData(
                table: "RowStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 4, 11, 13, 27, 13, 370, DateTimeKind.Local).AddTicks(6283));

            migrationBuilder.UpdateData(
                table: "RowStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateRegistration",
                value: new DateTime(2022, 4, 11, 13, 27, 13, 370, DateTimeKind.Local).AddTicks(6299));

            migrationBuilder.UpdateData(
                table: "RowStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateRegistration",
                value: new DateTime(2022, 4, 11, 13, 27, 13, 370, DateTimeKind.Local).AddTicks(6302));

            migrationBuilder.InsertData(
                table: "RowStatus",
                columns: new[] { "Id", "DateRegistration", "Description", "IsActive", "Name" },
                values: new object[] { 4, new DateTime(2022, 4, 11, 13, 27, 13, 370, DateTimeKind.Local).AddTicks(6351), null, true, "Por hacer" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 4, 11, 13, 27, 13, 370, DateTimeKind.Local).AddTicks(9064));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RowStatus",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AddColumn<int>(
                name: "RowEntityId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ActivityStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 2, 28, 14, 17, 8, 962, DateTimeKind.Local).AddTicks(317));

            migrationBuilder.UpdateData(
                table: "ActivityStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateRegistration",
                value: new DateTime(2022, 2, 28, 14, 17, 8, 965, DateTimeKind.Local).AddTicks(7775));

            migrationBuilder.UpdateData(
                table: "ActivityStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateRegistration",
                value: new DateTime(2022, 2, 28, 14, 17, 8, 965, DateTimeKind.Local).AddTicks(7825));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 2, 28, 14, 17, 8, 967, DateTimeKind.Local).AddTicks(3574));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateRegistration", "Name" },
                values: new object[] { new DateTime(2022, 2, 28, 14, 17, 8, 967, DateTimeKind.Local).AddTicks(3558), "Operador" });

            migrationBuilder.UpdateData(
                table: "RowStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 2, 28, 14, 17, 8, 967, DateTimeKind.Local).AddTicks(2418));

            migrationBuilder.UpdateData(
                table: "RowStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateRegistration",
                value: new DateTime(2022, 2, 28, 14, 17, 8, 967, DateTimeKind.Local).AddTicks(2443));

            migrationBuilder.UpdateData(
                table: "RowStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateRegistration",
                value: new DateTime(2022, 2, 28, 14, 17, 8, 967, DateTimeKind.Local).AddTicks(2449));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 2, 28, 14, 17, 8, 967, DateTimeKind.Local).AddTicks(6023));

            migrationBuilder.CreateIndex(
                name: "IX_User_RowEntityId",
                table: "User",
                column: "RowEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Row_RowEntityId",
                table: "User",
                column: "RowEntityId",
                principalTable: "Row",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
