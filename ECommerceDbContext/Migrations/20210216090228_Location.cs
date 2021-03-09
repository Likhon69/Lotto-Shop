using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceDbContext.Migrations
{
    public partial class Location : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "RegionId",
                table: "City",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CityId",
                table: "Areas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_City_RegionId",
                table: "City",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_CityId",
                table: "Areas",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_City_CityId",
                table: "Areas",
                column: "CityId",
                principalTable: "City",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_City_Regions_RegionId",
                table: "City",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "RegionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_City_CityId",
                table: "Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_City_Regions_RegionId",
                table: "City");

            migrationBuilder.DropIndex(
                name: "IX_City_RegionId",
                table: "City");

            migrationBuilder.DropIndex(
                name: "IX_Areas_CityId",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "City");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Areas");
        }
    }
}
