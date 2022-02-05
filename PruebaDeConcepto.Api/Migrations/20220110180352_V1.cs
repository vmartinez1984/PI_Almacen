using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PruebaDeConcepto.Api.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Habitantes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Pais",
                columns: new[] { "Id", "Habitantes", "Nombre" },
                values: new object[,]
                {
                    { new Guid("989558b2-33b6-45dc-aaa1-521f76f7330c"), 46000000, "España" },
                    { new Guid("b46a0038-cc00-4c5c-bc59-a953b6b47b1c"), 83000000, "Alemania" },
                    { new Guid("75bbb01d-6bc6-47e5-97d7-2044b3c84bc0"), 65000000, "Francia" },
                    { new Guid("1515be91-7940-42a6-a2c7-bd80c50fa2d0"), 61000000, "Italia" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pais");
        }
    }
}
