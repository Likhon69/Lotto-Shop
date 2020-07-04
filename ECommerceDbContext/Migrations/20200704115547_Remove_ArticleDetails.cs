using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceDbContext.Migrations
{
    public partial class Remove_ArticleDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pricings_ArticleDetails_ArticleDetailsArtD_Id",
                table: "Pricings");

            migrationBuilder.DropIndex(
                name: "IX_Pricings_ArticleDetailsArtD_Id",
                table: "Pricings");

            migrationBuilder.DropColumn(
                name: "ArticleDetailsArtD_Id",
                table: "Pricings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArticleDetailsArtD_Id",
                table: "Pricings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pricings_ArticleDetailsArtD_Id",
                table: "Pricings",
                column: "ArticleDetailsArtD_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pricings_ArticleDetails_ArticleDetailsArtD_Id",
                table: "Pricings",
                column: "ArticleDetailsArtD_Id",
                principalTable: "ArticleDetails",
                principalColumn: "ArtD_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
