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

            migrationBuilder.CreateTable(
                name: "Chat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserIdSource = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UserIdDestiny = table.Column<int>(type: "int", nullable: false),
                    DateRegistration = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserOnline",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DateRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOnline", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOnline_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                columns: new[] { "DateRegistration", "Name" },
                values: new object[] { new DateTime(2022, 4, 12, 12, 10, 36, 305, DateTimeKind.Local).AddTicks(6231), "Colaborador" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "DateRegistration", "Description", "IsActive", "Name" },
                values: new object[] { 3, new DateTime(2022, 4, 12, 12, 10, 36, 305, DateTimeKind.Local).AddTicks(6216), null, true, "Lider de equipo" });

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

            migrationBuilder.InsertData(
                table: "RowStatus",
                columns: new[] { "Id", "DateRegistration", "Description", "IsActive", "Name" },
                values: new object[] { 4, new DateTime(2022, 4, 12, 12, 10, 36, 305, DateTimeKind.Local).AddTicks(5210), null, true, "Por hacer" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 4, 12, 12, 10, 36, 305, DateTimeKind.Local).AddTicks(8248));

            migrationBuilder.CreateIndex(
                name: "IX_UserOnline_UserId",
                table: "UserOnline",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chat");

            migrationBuilder.DropTable(
                name: "UserOnline");

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
