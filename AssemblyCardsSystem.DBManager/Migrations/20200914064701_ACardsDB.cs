using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssemblyCardsSystem.DBManager.Migrations
{
    public partial class ACardsDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Cards");

            migrationBuilder.AddColumn<string>(
                name: "CardId",
                table: "Cards",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardId",
                table: "Cards");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Cards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
