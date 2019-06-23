using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class NewWishItemTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WishItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EntityId = table.Column<Guid>(nullable: false),
                    LastChangedDate = table.Column<DateTime>(maxLength: 7, nullable: false),
                    DeletedDate = table.Column<DateTime>(maxLength: 7, nullable: true),
                    AuthorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishItems", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WishItems");
        }
    }
}
