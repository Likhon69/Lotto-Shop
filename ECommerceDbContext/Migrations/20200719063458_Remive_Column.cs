using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceDbContext.Migrations
{
    public partial class Remive_Column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArticleMasterImage",
                table: "ArticleDetails");

            migrationBuilder.DropColumn(
                name: "ArticlechildImage",
                table: "ArticleDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ArticleMasterImage",
                table: "ArticleDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArticlechildImage",
                table: "ArticleDetails",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
