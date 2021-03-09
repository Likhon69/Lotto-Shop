using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceDbContext.Migrations
{
    public partial class Address_Add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
       

            migrationBuilder.CreateTable(
                name: "BillingAddresses",
                columns: table => new
                {
                    BillingAdd_Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionId = table.Column<long>(nullable: false),
                    CityId = table.Column<long>(nullable: false),
                    AreaId = table.Column<long>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    CustName = table.Column<string>(nullable: true),
                    CustPhone = table.Column<string>(nullable: true),
                    IsDeafultAddress = table.Column<bool>(nullable: false),
                    CustomerId = table.Column<long>(nullable: false),
                    DateOfEntry = table.Column<DateTime>(nullable: false),
                    IsHome = table.Column<bool>(nullable: false),
                    IsOffice = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingAddresses", x => x.BillingAdd_Id);
                });

            migrationBuilder.CreateTable(
                name: "ShippingAddresses",
                columns: table => new
                {
                    ShippingAdd_Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionId = table.Column<long>(nullable: false),
                    CityId = table.Column<long>(nullable: false),
                    AreaId = table.Column<long>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    CustName = table.Column<string>(nullable: true),
                    CustPhone = table.Column<string>(nullable: true),
                    IsDeafultAddress = table.Column<bool>(nullable: false),
                    CustomerId = table.Column<long>(nullable: false),
                    DateOfEntry = table.Column<DateTime>(nullable: false),
                    IsHome = table.Column<bool>(nullable: false),
                    IsOffice = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingAddresses", x => x.ShippingAdd_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillingAddresses");

            migrationBuilder.DropTable(
                name: "ShippingAddresses");

            migrationBuilder.CreateTable(
                name: "ShppingAddress",
                columns: table => new
                {
                    DelAdd_Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaId = table.Column<long>(type: "bigint", nullable: false),
                    CityId = table.Column<long>(type: "bigint", nullable: false),
                    CustName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    DateOfEntry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeafultAddress = table.Column<bool>(type: "bit", nullable: false),
                    IsHome = table.Column<bool>(type: "bit", nullable: false),
                    IsOffice = table.Column<bool>(type: "bit", nullable: false),
                    RegionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShppingAddress", x => x.DelAdd_Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerProfileInfos",
                columns: table => new
                {
                    CustP_Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryAddressDelAdd_Id = table.Column<long>(type: "bigint", nullable: true),
                    RecieverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecieverPhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerProfileInfos", x => x.CustP_Id);
                    table.ForeignKey(
                        name: "FK_CustomerProfileInfos_ShppingAddress_DeliveryAddressDelAdd_Id",
                        column: x => x.DeliveryAddressDelAdd_Id,
                        principalTable: "ShppingAddress",
                        principalColumn: "DelAdd_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProfileInfos_DeliveryAddressDelAdd_Id",
                table: "CustomerProfileInfos",
                column: "DeliveryAddressDelAdd_Id");
        }
    }
}
