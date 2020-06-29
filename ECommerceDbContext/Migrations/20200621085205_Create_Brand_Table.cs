using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceDbContext.Migrations
{
    public partial class Create_Brand_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Brand_Id",
                table: "ArticleDetails",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Brand_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Brand_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleDetails_Brand_Id",
                table: "ArticleDetails",
                column: "Brand_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleDetails_Brands_Brand_Id",
                table: "ArticleDetails",
                column: "Brand_Id",
                principalTable: "Brands",
                principalColumn: "Brand_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleDetails_Brands_Brand_Id",
                table: "ArticleDetails");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_ArticleDetails_Brand_Id",
                table: "ArticleDetails");

            migrationBuilder.DropColumn(
                name: "Brand_Id",
                table: "ArticleDetails");
        }
    }
}
