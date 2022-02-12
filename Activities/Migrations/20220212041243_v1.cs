using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Activities.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RowStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RowStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DateRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ActivityStatusId = table.Column<int>(type: "int", nullable: false),
                    DateRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activity_ActivityStatus_ActivityStatusId",
                        column: x => x.ActivityStatusId,
                        principalTable: "ActivityStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activity_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UserEntityId = table.Column<int>(type: "int", nullable: true),
                    DateRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Role_User_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Row",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RowStatusId = table.Column<int>(type: "int", nullable: false),
                    DateStop = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActivityEntityId = table.Column<int>(type: "int", nullable: true),
                    DateRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Row", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Row_Activity_ActivityEntityId",
                        column: x => x.ActivityEntityId,
                        principalTable: "Activity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Row_RowStatus_RowStatusId",
                        column: x => x.RowStatusId,
                        principalTable: "RowStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Row_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    RowEntityId = table.Column<int>(type: "int", nullable: true),
                    DateRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Row_RowEntityId",
                        column: x => x.RowEntityId,
                        principalTable: "Row",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RowId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    DateRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_Row_RowId",
                        column: x => x.RowId,
                        principalTable: "Row",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_File_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersInRow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RowId = table.Column<int>(type: "int", nullable: false),
                    DateRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersInRow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersInRow_Row_RowId",
                        column: x => x.RowId,
                        principalTable: "Row",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UsersInRow_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ActivityStatus",
                columns: new[] { "Id", "DateRegistration", "Description", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 2, 11, 22, 12, 42, 345, DateTimeKind.Local).AddTicks(4555), null, true, "Por hacer" },
                    { 2, new DateTime(2022, 2, 11, 22, 12, 42, 357, DateTimeKind.Local).AddTicks(566), null, true, "Haciendo" },
                    { 3, new DateTime(2022, 2, 11, 22, 12, 42, 357, DateTimeKind.Local).AddTicks(655), null, true, "Hecho" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "DateRegistration", "Description", "IsActive", "Name", "UserEntityId" },
                values: new object[,]
                {
                    { 2, new DateTime(2022, 2, 11, 22, 12, 42, 359, DateTimeKind.Local).AddTicks(3846), null, true, "Operador", null },
                    { 1, new DateTime(2022, 2, 11, 22, 12, 42, 359, DateTimeKind.Local).AddTicks(3873), null, true, "Administrador", null }
                });

            migrationBuilder.InsertData(
                table: "RowStatus",
                columns: new[] { "Id", "DateRegistration", "Description", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 2, 11, 22, 12, 42, 359, DateTimeKind.Local).AddTicks(2185), null, true, "Listo" },
                    { 2, new DateTime(2022, 2, 11, 22, 12, 42, 359, DateTimeKind.Local).AddTicks(2221), null, true, "En proceso" },
                    { 3, new DateTime(2022, 2, 11, 22, 12, 42, 359, DateTimeKind.Local).AddTicks(2226), null, true, "Estancado" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "ConfirmPassword", "DateRegistration", "Email", "IsActive", "LastName", "Name", "Password", "Phone", "RolId", "UserName" },
                values: new object[] { 1, null, new DateTime(2022, 2, 11, 22, 12, 42, 359, DateTimeKind.Local).AddTicks(7432), null, true, "", "Administrador", "123456", null, 1, "administrador" });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_ActivityStatusId",
                table: "Activity",
                column: "ActivityStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_UserId",
                table: "Activity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_RowEntityId",
                table: "Comment",
                column: "RowEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId",
                table: "Comment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_File_RowId",
                table: "File",
                column: "RowId");

            migrationBuilder.CreateIndex(
                name: "IX_File_UserId",
                table: "File",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_UserEntityId",
                table: "Role",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Row_ActivityEntityId",
                table: "Row",
                column: "ActivityEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Row_RowStatusId",
                table: "Row",
                column: "RowStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Row_UserId",
                table: "Row",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInRow_RowId",
                table: "UsersInRow",
                column: "RowId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInRow_UserId",
                table: "UsersInRow",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "UsersInRow");

            migrationBuilder.DropTable(
                name: "Row");

            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "RowStatus");

            migrationBuilder.DropTable(
                name: "ActivityStatus");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
