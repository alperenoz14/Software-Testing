using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Software_Testing.Migrations
{
    public partial class guessedTimeUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "guessedTime",
                table: "Cards",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "guessedTime",
                table: "Cards",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
