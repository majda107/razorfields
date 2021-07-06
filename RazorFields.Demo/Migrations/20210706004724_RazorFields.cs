using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorFields.Demo.Migrations
{
    public partial class RazorFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersistenceRazorModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Content = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersistenceRazorModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersistenceRazorModel_Name",
                table: "PersistenceRazorModel",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersistenceRazorModel");
        }
    }
}
