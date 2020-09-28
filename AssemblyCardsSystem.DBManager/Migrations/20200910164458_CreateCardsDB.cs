using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssemblyCardsSystem.DBManager.Migrations
{
    public partial class CreateCardsDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeLN = table.Column<string>(nullable: true),
                    EmployeeFN = table.Column<string>(nullable: true),
                    EmployeeID = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    KNNR = table.Column<string>(nullable: true),
                    Sort = table.Column<string>(nullable: true),
                    PrNr = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");
        }
    }
}
