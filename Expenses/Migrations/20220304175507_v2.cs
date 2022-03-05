using Microsoft.EntityFrameworkCore.Migrations;

namespace Expenses.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.RenameColumn(
            //    name: "CategotyId",
            //    table: "Expense",
            //    newName: "CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Expense",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Entry",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Entry");

            //migrationBuilder.RenameColumn(
            //    name: "CategoryId",
            //    table: "Expense",
            //    newName: "CategotyId");
        }
    }
}
