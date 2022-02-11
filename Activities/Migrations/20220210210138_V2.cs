using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Activities.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UsersInRow",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ActivityStatus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateRegistration", "IsActive" },
                values: new object[] { new DateTime(2022, 2, 10, 15, 1, 37, 86, DateTimeKind.Local).AddTicks(9426), true });

            migrationBuilder.UpdateData(
                table: "ActivityStatus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateRegistration", "IsActive" },
                values: new object[] { new DateTime(2022, 2, 10, 15, 1, 37, 94, DateTimeKind.Local).AddTicks(8114), true });

            migrationBuilder.UpdateData(
                table: "ActivityStatus",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateRegistration", "IsActive" },
                values: new object[] { new DateTime(2022, 2, 10, 15, 1, 37, 94, DateTimeKind.Local).AddTicks(8169), true });

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
                columns: new[] { "DateRegistration", "IsActive" },
                values: new object[] { new DateTime(2022, 2, 10, 15, 1, 37, 96, DateTimeKind.Local).AddTicks(4968), true });

            migrationBuilder.UpdateData(
                table: "RowStatus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateRegistration", "IsActive" },
                values: new object[] { new DateTime(2022, 2, 10, 15, 1, 37, 96, DateTimeKind.Local).AddTicks(5004), true });

            migrationBuilder.UpdateData(
                table: "RowStatus",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateRegistration", "IsActive" },
                values: new object[] { new DateTime(2022, 2, 10, 15, 1, 37, 96, DateTimeKind.Local).AddTicks(5009), true });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 2, 10, 15, 1, 37, 97, DateTimeKind.Local).AddTicks(1084));

            migrationBuilder.CreateIndex(
                name: "IX_UsersInRow_UserId",
                table: "UsersInRow",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInRow_User_UserId",
                table: "UsersInRow",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersInRow_User_UserId",
                table: "UsersInRow");

            migrationBuilder.DropIndex(
                name: "IX_UsersInRow_UserId",
                table: "UsersInRow");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UsersInRow");

            migrationBuilder.UpdateData(
                table: "ActivityStatus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateRegistration", "IsActive" },
                values: new object[] { new DateTime(2022, 2, 10, 13, 4, 14, 977, DateTimeKind.Local).AddTicks(3274), false });

            migrationBuilder.UpdateData(
                table: "ActivityStatus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateRegistration", "IsActive" },
                values: new object[] { new DateTime(2022, 2, 10, 13, 4, 14, 986, DateTimeKind.Local).AddTicks(5980), false });

            migrationBuilder.UpdateData(
                table: "ActivityStatus",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateRegistration", "IsActive" },
                values: new object[] { new DateTime(2022, 2, 10, 13, 4, 14, 986, DateTimeKind.Local).AddTicks(6038), false });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 2, 10, 13, 4, 14, 988, DateTimeKind.Local).AddTicks(8911));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateRegistration",
                value: new DateTime(2022, 2, 10, 13, 4, 14, 988, DateTimeKind.Local).AddTicks(8387));

            migrationBuilder.UpdateData(
                table: "RowStatus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateRegistration", "IsActive" },
                values: new object[] { new DateTime(2022, 2, 10, 13, 4, 14, 988, DateTimeKind.Local).AddTicks(6827), false });

            migrationBuilder.UpdateData(
                table: "RowStatus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateRegistration", "IsActive" },
                values: new object[] { new DateTime(2022, 2, 10, 13, 4, 14, 988, DateTimeKind.Local).AddTicks(6865), false });

            migrationBuilder.UpdateData(
                table: "RowStatus",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateRegistration", "IsActive" },
                values: new object[] { new DateTime(2022, 2, 10, 13, 4, 14, 988, DateTimeKind.Local).AddTicks(6871), false });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 2, 10, 13, 4, 14, 989, DateTimeKind.Local).AddTicks(3347));
        }
    }
}
