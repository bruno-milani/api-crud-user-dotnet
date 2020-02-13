using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace myApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DateOfBird = table.Column<DateTime>(nullable: true),
                    Sex = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateOfBird", "Email", "Name", "Role", "Sex" },
                values: new object[] { 1, new DateTime(1996, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@api.com", "AdminAPI", "Manager", "Masculino" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
