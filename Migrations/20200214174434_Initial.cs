using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace myApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DateOfBird = table.Column<DateTime>(nullable: true),
                    Sex = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    Created_at = table.Column<DateTime>(nullable: true),
                    Update_at = table.Column<DateTime>(nullable: true),
                    Deleted_at = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created_at", "DateOfBird", "Deleted_at", "Email", "Name", "Role", "Sex", "Update_at" },
                values: new object[] { 1, null, new DateTime(1996, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@api.com", "AdminAPI", "Manager", "Masculino", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
