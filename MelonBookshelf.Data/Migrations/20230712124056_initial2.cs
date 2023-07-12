using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MelonBookshelf.Data.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResourceRequestId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ResourceRequestId",
                table: "Categories",
                column: "ResourceRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_ResourcesRequests_ResourceRequestId",
                table: "Categories",
                column: "ResourceRequestId",
                principalTable: "ResourcesRequests",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_ResourcesRequests_ResourceRequestId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ResourceRequestId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ResourceRequestId",
                table: "Categories");
        }
    }
}
