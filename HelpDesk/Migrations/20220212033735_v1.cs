﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpDesk.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BranchType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DateRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
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
                name: "Branch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    BranchTypeId = table.Column<int>(type: "int", nullable: false),
                    TypeBranchId = table.Column<int>(type: "int", nullable: true),
                    DateRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branch_BranchType_TypeBranchId",
                        column: x => x.TypeBranchId,
                        principalTable: "BranchType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Branch_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SerieNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateStop = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductStatusId = table.Column<int>(type: "int", nullable: false),
                    DateRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_ProductStatus_ProductStatusId",
                        column: x => x.ProductStatusId,
                        principalTable: "ProductStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    DateRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductAssignment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DateAssignment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAssignment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAssignment_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAssignment_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAssignment_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BranchType",
                columns: new[] { "Id", "DateRegistration", "Description", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 2, 11, 21, 37, 34, 2, DateTimeKind.Local).AddTicks(1031), null, true, "Matriz" },
                    { 2, new DateTime(2022, 2, 11, 21, 37, 34, 2, DateTimeKind.Local).AddTicks(1053), null, true, "Sucursal" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "DateRegistration", "Description", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 2, 11, 21, 37, 34, 2, DateTimeKind.Local).AddTicks(112), null, true, "Software" },
                    { 2, new DateTime(2022, 2, 11, 21, 37, 34, 2, DateTimeKind.Local).AddTicks(146), null, true, "Hardware" },
                    { 3, new DateTime(2022, 2, 11, 21, 37, 34, 2, DateTimeKind.Local).AddTicks(154), null, true, "Comunicación" }
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "DateRegistration", "IsActive", "Name", "Note", "Street" },
                values: new object[] { 1, new DateTime(2022, 2, 11, 21, 37, 34, 2, DateTimeKind.Local).AddTicks(7774), true, "Compañia A", "Prueba", "Domicilio conocido" });

            migrationBuilder.InsertData(
                table: "ProductStatus",
                columns: new[] { "Id", "DateRegistration", "Description", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 2, 11, 21, 37, 33, 989, DateTimeKind.Local).AddTicks(8385), null, true, "Activo" },
                    { 2, new DateTime(2022, 2, 11, 21, 37, 34, 0, DateTimeKind.Local).AddTicks(1805), null, true, "Asignado" },
                    { 3, new DateTime(2022, 2, 11, 21, 37, 34, 0, DateTimeKind.Local).AddTicks(1863), null, true, "Merma" },
                    { 4, new DateTime(2022, 2, 11, 21, 37, 34, 0, DateTimeKind.Local).AddTicks(1871), null, true, "Baja por daño" },
                    { 5, new DateTime(2022, 2, 11, 21, 37, 34, 0, DateTimeKind.Local).AddTicks(1877), null, true, "Recuperado" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "DateRegistration", "Description", "IsActive", "Name", "UserEntityId" },
                values: new object[,]
                {
                    { 2, new DateTime(2022, 2, 11, 21, 37, 34, 2, DateTimeKind.Local).AddTicks(2880), null, true, "Operador", null },
                    { 1, new DateTime(2022, 2, 11, 21, 37, 34, 2, DateTimeKind.Local).AddTicks(2907), null, true, "Administrador", null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateRegistration", "Email", "IsActive", "LastName", "Name", "Password", "Phone", "RolId", "UserName" },
                values: new object[] { 1, new DateTime(2022, 2, 11, 21, 37, 34, 2, DateTimeKind.Local).AddTicks(5872), null, true, "", "Administrador", "123456", null, 1, "administrador" });

            migrationBuilder.InsertData(
                table: "Branch",
                columns: new[] { "Id", "BranchTypeId", "CompanyId", "DateRegistration", "Email", "IsActive", "Name", "Note", "Phone", "Street", "TypeBranchId" },
                values: new object[] { 1, 1, 1, new DateTime(2022, 2, 11, 21, 37, 34, 2, DateTimeKind.Local).AddTicks(9868), "correo@dominio.com", true, "Sucursal", "Sin observaciones", "55 5658 1111", "Domicilio conocido", null });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "DateRegistration", "DateStart", "DateStop", "Description", "IsActive", "Name", "ProductStatusId", "SerieNumber" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 2, 11, 21, 37, 34, 3, DateTimeKind.Local).AddTicks(7463), new DateTime(2022, 2, 11, 21, 37, 34, 3, DateTimeKind.Local).AddTicks(5631), new DateTime(2023, 2, 11, 21, 37, 34, 3, DateTimeKind.Local).AddTicks(6854), "Posicion 1/3", true, "Oficce 360", 1, "148318" },
                    { 2, 1, new DateTime(2022, 2, 11, 21, 37, 34, 3, DateTimeKind.Local).AddTicks(9737), new DateTime(2022, 2, 11, 21, 37, 34, 3, DateTimeKind.Local).AddTicks(9701), new DateTime(2023, 2, 11, 21, 37, 34, 3, DateTimeKind.Local).AddTicks(9722), "Posicion 2/3", true, "Oficce 360", 1, "148318" },
                    { 3, 1, new DateTime(2022, 2, 11, 21, 37, 34, 3, DateTimeKind.Local).AddTicks(9754), new DateTime(2022, 2, 11, 21, 37, 34, 3, DateTimeKind.Local).AddTicks(9744), new DateTime(2023, 2, 11, 21, 37, 34, 3, DateTimeKind.Local).AddTicks(9749), "Posicion 3/3", true, "Oficce 360", 1, "148318" },
                    { 4, 3, new DateTime(2022, 2, 11, 21, 37, 34, 3, DateTimeKind.Local).AddTicks(9760), null, null, "Camara axis 1020", true, "Camara IP", 1, "148318" }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "BranchId", "DateRegistration", "Email", "IsActive", "LastName", "Name", "Phone" },
                values: new object[] { 1, 1, new DateTime(2022, 2, 11, 21, 37, 34, 3, DateTimeKind.Local).AddTicks(2771), "ahal_tocob@hotmail.com", true, "Mtz", "Víctor", "55 3273 7357" });

            migrationBuilder.CreateIndex(
                name: "IX_Branch_CompanyId",
                table: "Branch",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_TypeBranchId",
                table: "Branch",
                column: "TypeBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_BranchId",
                table: "Person",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductStatusId",
                table: "Product",
                column: "ProductStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAssignment_PersonId",
                table: "ProductAssignment",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAssignment_ProductId",
                table: "ProductAssignment",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAssignment_UserId",
                table: "ProductAssignment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_UserEntityId",
                table: "Role",
                column: "UserEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductAssignment");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "ProductStatus");

            migrationBuilder.DropTable(
                name: "BranchType");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}