using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceDbContext.Migrations
{
    public partial class Add_table_Courier_Person : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "courierCompanyMasters",
                columns: table => new
                {
                    company_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyName = table.Column<string>(nullable: false),
                    contactPerson = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    website = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Remarks = table.Column<string>(maxLength: 600, nullable: false),
                    status = table.Column<bool>(nullable: false),
                    created_At = table.Column<DateTime>(nullable: false),
                    created_By = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courierCompanyMasters", x => x.company_Id);
                });

            migrationBuilder.CreateTable(
                name: "courierContactPersons",
                columns: table => new
                {
                    person_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    personName = table.Column<string>(nullable: false),
                    phone1 = table.Column<string>(nullable: false),
                    phone2 = table.Column<string>(nullable: false),
                    status = table.Column<bool>(nullable: false),
                    created_By = table.Column<string>(nullable: true),
                    Created_At = table.Column<DateTime>(nullable: false),
                    CourierCompanyMastercompany_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courierContactPersons", x => x.person_Id);
                    table.ForeignKey(
                        name: "FK_courierContactPersons_courierCompanyMasters_CourierCompanyMastercompany_Id",
                        column: x => x.CourierCompanyMastercompany_Id,
                        principalTable: "courierCompanyMasters",
                        principalColumn: "company_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_courierContactPersons_CourierCompanyMastercompany_Id",
                table: "courierContactPersons",
                column: "CourierCompanyMastercompany_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "courierContactPersons");

            migrationBuilder.DropTable(
                name: "courierCompanyMasters");
        }
    }
}
