using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceDbContext.Migrations
{
    public partial class Create_All : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleDetails",
                columns: table => new
                {
                    ArtD_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleTitle = table.Column<string>(nullable: false),
                    ArticleSubtitle = table.Column<string>(nullable: false),
                    CategoryC_Id = table.Column<int>(nullable: false),
                    SubCategoryS_Id = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 900, nullable: false),
                    Brand_Id = table.Column<int>(nullable: false),
                    Vat_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleDetails", x => x.ArtD_Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleMatrices",
                columns: table => new
                {
                    ArtM_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleMatrices", x => x.ArtM_Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    C_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    shortName = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: false),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.C_Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerInstallationInfos",
                columns: table => new
                {
                    CusPIn_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(nullable: true),
                    CustomerMobileNo = table.Column<string>(nullable: true),
                    InstallationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInstallationInfos", x => x.CusPIn_Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryAddresses",
                columns: table => new
                {
                    DeAdd_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    District = table.Column<string>(nullable: true),
                    SubDistrict = table.Column<string>(nullable: true),
                    RoadNo = table.Column<int>(nullable: false),
                    HouseNo = table.Column<int>(nullable: false),
                    floorNo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryAddresses", x => x.DeAdd_Id);
                });

            migrationBuilder.CreateTable(
                name: "HaltArticles",
                columns: table => new
                {
                    HArt_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleName = table.Column<string>(nullable: true),
                    ArticleNo = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    Brand = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HaltArticles", x => x.HArt_Id);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemID);
                });

            migrationBuilder.CreateTable(
                name: "OtherInformations",
                columns: table => new
                {
                    Oth_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RptCategory = table.Column<string>(nullable: true),
                    RptSubCategory = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherInformations", x => x.Oth_Id);
                });

            migrationBuilder.CreateTable(
                name: "Pricings",
                columns: table => new
                {
                    Pricing_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StandardPrice = table.Column<decimal>(nullable: false),
                    FranchisePrice = table.Column<decimal>(nullable: false),
                    InstitutePrice = table.Column<decimal>(nullable: false),
                    PurchaseCost = table.Column<decimal>(nullable: false),
                    WholeSalePrice = table.Column<decimal>(nullable: false),
                    DealerPrice = table.Column<decimal>(nullable: false),
                    OtherPrice = table.Column<decimal>(nullable: false),
                    DiscontPrice = table.Column<int>(nullable: false),
                    DiscountRate = table.Column<decimal>(nullable: false),
                    ArticleDetails_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pricings", x => x.Pricing_Id);
                });

            migrationBuilder.CreateTable(
                name: "SoldArticles",
                columns: table => new
                {
                    SArt_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleName = table.Column<string>(nullable: true),
                    ArticleNo = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    Brand = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoldArticles", x => x.SArt_Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    S_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(nullable: false),
                    shortName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.S_Id);
                });

            migrationBuilder.CreateTable(
                name: "TestClass1s",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    DiscountPice = table.Column<decimal>(nullable: false),
                    VatRate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestClass1s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    LoginId = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Roles = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_Id);
                });

            migrationBuilder.CreateTable(
                name: "Vats",
                columns: table => new
                {
                    Vat_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VatTypeName = table.Column<string>(nullable: true),
                    Vat_Rat = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vats", x => x.Vat_Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleImageVarients",
                columns: table => new
                {
                    Img_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(nullable: true),
                    ArticleDetailsArtD_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleImageVarients", x => x.Img_Id);
                    table.ForeignKey(
                        name: "FK_ArticleImageVarients_ArticleDetails_ArticleDetailsArtD_Id",
                        column: x => x.ArticleDetailsArtD_Id,
                        principalTable: "ArticleDetails",
                        principalColumn: "ArtD_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArticleVariants",
                columns: table => new
                {
                    ArtV_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleNo = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    Style = table.Column<string>(nullable: true),
                    ArticleDetailsArtD_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleVariants", x => x.ArtV_Id);
                    table.ForeignKey(
                        name: "FK_ArticleVariants_ArticleDetails_ArticleDetailsArtD_Id",
                        column: x => x.ArticleDetailsArtD_Id,
                        principalTable: "ArticleDetails",
                        principalColumn: "ArtD_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNo = table.Column<string>(nullable: true),
                    CustomerID = table.Column<int>(nullable: true),
                    PMethod = table.Column<string>(nullable: true),
                    GTotal = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Order_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerProfileInfos",
                columns: table => new
                {
                    CustP_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryAddressDeAdd_Id = table.Column<int>(nullable: true),
                    RecieverName = table.Column<string>(nullable: true),
                    RecieverPhoneNo = table.Column<string>(nullable: true),
                    BuyDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerProfileInfos", x => x.CustP_Id);
                    table.ForeignKey(
                        name: "FK_CustomerProfileInfos_DeliveryAddresses_DeliveryAddressDeAdd_Id",
                        column: x => x.DeliveryAddressDeAdd_Id,
                        principalTable: "DeliveryAddresses",
                        principalColumn: "DeAdd_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    OrderItemID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<long>(nullable: true),
                    ItemID = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.OrderItemID);
                    table.ForeignKey(
                        name: "FK_OrderItem_Item_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Item",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleImageVarients_ArticleDetailsArtD_Id",
                table: "ArticleImageVarients",
                column: "ArticleDetailsArtD_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleVariants_ArticleDetailsArtD_Id",
                table: "ArticleVariants",
                column: "ArticleDetailsArtD_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProfileInfos_DeliveryAddressDeAdd_Id",
                table: "CustomerProfileInfos",
                column: "DeliveryAddressDeAdd_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerID",
                table: "Order",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ItemID",
                table: "OrderItem",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderID",
                table: "OrderItem",
                column: "OrderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleImageVarients");

            migrationBuilder.DropTable(
                name: "ArticleMatrices");

            migrationBuilder.DropTable(
                name: "ArticleVariants");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categorys");

            migrationBuilder.DropTable(
                name: "CustomerInstallationInfos");

            migrationBuilder.DropTable(
                name: "CustomerProfileInfos");

            migrationBuilder.DropTable(
                name: "HaltArticles");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "OtherInformations");

            migrationBuilder.DropTable(
                name: "Pricings");

            migrationBuilder.DropTable(
                name: "SoldArticles");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "TestClass1s");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vats");

            migrationBuilder.DropTable(
                name: "ArticleDetails");

            migrationBuilder.DropTable(
                name: "DeliveryAddresses");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
