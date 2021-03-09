using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceDbContext.Migrations
{
    public partial class Update_Orderheader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BillingId",
                table: "OrderHeaders",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ShippingId",
                table: "OrderHeaders",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillingId",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "ShippingId",
                table: "OrderHeaders");
        }
    }
}
