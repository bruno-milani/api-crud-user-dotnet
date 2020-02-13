using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace myApi.Migrations
{
    public partial class AlterUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted_at",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted_at",
                table: "Users");
        }
    }
}
