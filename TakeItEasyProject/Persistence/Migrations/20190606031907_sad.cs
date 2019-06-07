using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class sad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacations_Users_AuthorId",
                table: "Vacations");

            migrationBuilder.DropIndex(
                name: "IX_Vacations_AuthorId",
                table: "Vacations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Vacations_AuthorId",
                table: "Vacations",
                column: "AuthorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacations_Users_AuthorId",
                table: "Vacations",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
