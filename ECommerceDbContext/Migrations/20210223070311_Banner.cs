using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceDbContext.Migrations
{
    public partial class Banner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BannerInfo",
                columns: table => new
                {
                    BannerId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BannerName = table.Column<string>(nullable: true),
                    BannerImageName = table.Column<string>(nullable: true),
                    DateOfEntry = table.Column<DateTime>(nullable: false),
                    EnteredBy = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BannerInfo", x => x.BannerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BannerInfo");
        }
    }
}
