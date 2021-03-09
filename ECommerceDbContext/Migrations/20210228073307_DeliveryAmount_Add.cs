using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceDbContext.Migrations
{
    public partial class DeliveryAmount_Add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryInfoDetails",
                columns: table => new
                {
                    Del_InId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionId = table.Column<long>(nullable: false),
                    CityId = table.Column<long>(nullable: false),
                    DeliveryAmount = table.Column<decimal>(nullable: false),
                    CompanyId = table.Column<long>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    DateOfEntry = table.Column<DateTime>(nullable: false),
                    EnteredBy = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryInfoDetails", x => x.Del_InId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryInfoDetails");
        }
    }
}
