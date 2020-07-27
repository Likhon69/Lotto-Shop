using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceDbContext.Migrations
{
    public partial class Update_Test_Class : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "TestClass1s");

            migrationBuilder.DropColumn(
                name: "DiscountPice",
                table: "TestClass1s");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "TestClass1s");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "TestClass1s");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "TestClass1s");

            migrationBuilder.DropColumn(
                name: "VatRate",
                table: "TestClass1s");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "TestClass1s",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArticleDetails_Id",
                table: "TestClass1s",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TestClass1s",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "TestClass1s");

            migrationBuilder.DropColumn(
                name: "ArticleDetails_Id",
                table: "TestClass1s");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "TestClass1s");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "TestClass1s",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPice",
                table: "TestClass1s",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "TestClass1s",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "TestClass1s",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "TestClass1s",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "VatRate",
                table: "TestClass1s",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
