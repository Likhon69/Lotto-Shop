using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceDbContext.Migrations
{
    public partial class Create_Matrix_InArticleDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArticleMatrixArtM_Id",
                table: "ArticleDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArticleDetails_ArticleMatrixArtM_Id",
                table: "ArticleDetails",
                column: "ArticleMatrixArtM_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleDetails_ArticleMatrices_ArticleMatrixArtM_Id",
                table: "ArticleDetails",
                column: "ArticleMatrixArtM_Id",
                principalTable: "ArticleMatrices",
                principalColumn: "ArtM_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleDetails_ArticleMatrices_ArticleMatrixArtM_Id",
                table: "ArticleDetails");

            migrationBuilder.DropIndex(
                name: "IX_ArticleDetails_ArticleMatrixArtM_Id",
                table: "ArticleDetails");

            migrationBuilder.DropColumn(
                name: "ArticleMatrixArtM_Id",
                table: "ArticleDetails");
        }
    }
}
