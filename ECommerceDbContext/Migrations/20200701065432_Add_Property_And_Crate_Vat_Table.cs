using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceDbContext.Migrations
{
    public partial class Add_Property_And_Crate_Vat_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArticleName",
                table: "ArticleDetails");

            migrationBuilder.AddColumn<string>(
                name: "ArticleSubtitle",
                table: "ArticleDetails",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ArticleTitle",
                table: "ArticleDetails",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Vat_Id",
                table: "ArticleDetails",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Vats",
                columns: table => new
                {
                    Vat_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VatTypeName = table.Column<string>(nullable: true),
                    Vat_Rat = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vats", x => x.Vat_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleDetails_Vat_Id",
                table: "ArticleDetails",
                column: "Vat_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleDetails_Vats_Vat_Id",
                table: "ArticleDetails",
                column: "Vat_Id",
                principalTable: "Vats",
                principalColumn: "Vat_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleDetails_Vats_Vat_Id",
                table: "ArticleDetails");

            migrationBuilder.DropTable(
                name: "Vats");

            migrationBuilder.DropIndex(
                name: "IX_ArticleDetails_Vat_Id",
                table: "ArticleDetails");

            migrationBuilder.DropColumn(
                name: "ArticleSubtitle",
                table: "ArticleDetails");

            migrationBuilder.DropColumn(
                name: "ArticleTitle",
                table: "ArticleDetails");

            migrationBuilder.DropColumn(
                name: "Vat_Id",
                table: "ArticleDetails");

            migrationBuilder.AddColumn<string>(
                name: "ArticleName",
                table: "ArticleDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
