using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceDbContext.Migrations
{
    public partial class All : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    AreaId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.AreaId);
                });

            migrationBuilder.CreateTable(
                name: "ArticleDetails",
                columns: table => new
                {
                    ArtD_Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleTitle = table.Column<string>(nullable: false),
                    ArticleSubtitle = table.Column<string>(nullable: false),
                    CategoryC_Id = table.Column<long>(nullable: false),
                    SubCategoryS_Id = table.Column<long>(nullable: false),
                    Description = table.Column<string>(maxLength: 900, nullable: false),
                    Brand_Id = table.Column<int>(nullable: false),
                    Vat_Id = table.Column<int>(nullable: false),
                    IsDiscount = table.Column<bool>(nullable: false),
                    SubSubCategoryS_Id = table.Column<long>(nullable: false),
                    SubSubSubCategoryS_Id = table.Column<long>(nullable: false),
                    DateOfEntry = table.Column<DateTime>(nullable: false),
                    EnteredBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    IsNewAraival = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleDetails", x => x.ArtD_Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleMatrices",
                columns: table => new
                {
                    ArtM_Id = table.Column<long>(nullable: false)
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
                    Brand_Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Brand_Id);
                });

            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    C_Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: false),
                    status = table.Column<bool>(nullable: false),
                    CatImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.C_Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "courierCompanyMasters",
                columns: table => new
                {
                    company_Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyName = table.Column<string>(nullable: false),
                    contactPerson = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    website = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Remarks = table.Column<string>(maxLength: 600, nullable: false),
                    status = table.Column<string>(nullable: true),
                    created_At = table.Column<DateTime>(nullable: false),
                    created_By = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courierCompanyMasters", x => x.company_Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerInstallationInfos",
                columns: table => new
                {
                    CusPIn_Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(nullable: false),
                    CustomerMobileNo = table.Column<string>(nullable: false),
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
                    CustomerID = table.Column<long>(nullable: false)
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
                    DeAdd_Id = table.Column<long>(nullable: false)
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
                name: "DiscountTimes",
                columns: table => new
                {
                    DiscountTimeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountFromDate = table.Column<DateTime>(nullable: false),
                    DiscountTimeTo = table.Column<DateTime>(nullable: false),
                    DateOfEntry = table.Column<DateTime>(nullable: false),
                    EnteredBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountTimes", x => x.DiscountTimeId);
                });

            migrationBuilder.CreateTable(
                name: "DiscountTypes",
                columns: table => new
                {
                    DiscountTypeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountName = table.Column<string>(nullable: false),
                    DateOfEntry = table.Column<DateTime>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountTypes", x => x.DiscountTypeId);
                });

            migrationBuilder.CreateTable(
                name: "HaltArticles",
                columns: table => new
                {
                    HArt_Id = table.Column<long>(nullable: false)
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
                name: "OrderHeaders",
                columns: table => new
                {
                    OrderHeaderId = table.Column<Guid>(nullable: false),
                    CustomerId = table.Column<long>(nullable: false),
                    TotalAmount = table.Column<double>(nullable: false),
                    OrderAmount = table.Column<double>(nullable: false),
                    RecieveAmount = table.Column<double>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    DateOfEntry = table.Column<DateTime>(nullable: false),
                    Approved = table.Column<string>(nullable: true),
                    Sattelled = table.Column<double>(nullable: false),
                    FullySattelled = table.Column<string>(nullable: true),
                    PartialApproved = table.Column<string>(nullable: true),
                    ApprovedDate = table.Column<DateTime>(nullable: false),
                    PartialApprovedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHeaders", x => x.OrderHeaderId);
                });

            migrationBuilder.CreateTable(
                name: "OtherInformations",
                columns: table => new
                {
                    Oth_Id = table.Column<long>(nullable: false)
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
                    ArticleDetails_Id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pricings", x => x.Pricing_Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    RegionId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionId);
                });

            migrationBuilder.CreateTable(
                name: "SoldArticles",
                columns: table => new
                {
                    SArt_Id = table.Column<long>(nullable: false)
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
                name: "Users",
                columns: table => new
                {
                    User_Id = table.Column<long>(nullable: false)
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
                    Img_Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(nullable: true),
                    ArticleDetailsArtD_Id = table.Column<long>(nullable: true),
                    IsMaster = table.Column<bool>(nullable: false)
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
                    ArtV_Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleNo = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    Style = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    ArticleDetailsArtD_Id = table.Column<long>(nullable: true)
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
                name: "SubCategories",
                columns: table => new
                {
                    S_Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    status = table.Column<bool>(nullable: false),
                    CategoryC_Id = table.Column<long>(nullable: true),
                    Brand_Id = table.Column<long>(nullable: true),
                    SubCatImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.S_Id);
                    table.ForeignKey(
                        name: "FK_SubCategories_Brands_Brand_Id",
                        column: x => x.Brand_Id,
                        principalTable: "Brands",
                        principalColumn: "Brand_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categorys_CategoryC_Id",
                        column: x => x.CategoryC_Id,
                        principalTable: "Categorys",
                        principalColumn: "C_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "courierContactPersons",
                columns: table => new
                {
                    person_Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    personName = table.Column<string>(nullable: false),
                    phone1 = table.Column<string>(nullable: false),
                    phone2 = table.Column<string>(nullable: false),
                    status = table.Column<string>(nullable: true),
                    created_By = table.Column<string>(nullable: true),
                    Created_At = table.Column<DateTime>(nullable: false),
                    CourierCompanyMastercompany_Id = table.Column<long>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNo = table.Column<string>(nullable: true),
                    CustomerID = table.Column<int>(nullable: true),
                    PMethod = table.Column<string>(nullable: true),
                    GTotal = table.Column<decimal>(nullable: true),
                    CustomerID1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Order_Customers_CustomerID1",
                        column: x => x.CustomerID1,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerProfileInfos",
                columns: table => new
                {
                    CustP_Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryAddressDeAdd_Id = table.Column<long>(nullable: true),
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
                name: "BasketValueDiscount",
                columns: table => new
                {
                    BasketValueDiscountId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<long>(nullable: false),
                    BasketValueDiscountPercentage = table.Column<int>(nullable: false),
                    DateOfEntry = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    EnteredBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    DiscountTimeId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketValueDiscount", x => x.BasketValueDiscountId);
                    table.ForeignKey(
                        name: "FK_BasketValueDiscount_DiscountTimes_DiscountTimeId",
                        column: x => x.DiscountTimeId,
                        principalTable: "DiscountTimes",
                        principalColumn: "DiscountTimeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DiscountDetails",
                columns: table => new
                {
                    DiscountDetailId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountTypeId = table.Column<long>(nullable: false),
                    ArticleId = table.Column<long>(nullable: false),
                    DiscountPercentage = table.Column<int>(nullable: false),
                    DateOfEntry = table.Column<DateTime>(nullable: false),
                    EnteredBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    DiscountTimeId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountDetails", x => x.DiscountDetailId);
                    table.ForeignKey(
                        name: "FK_DiscountDetails_DiscountTimes_DiscountTimeId",
                        column: x => x.DiscountTimeId,
                        principalTable: "DiscountTimes",
                        principalColumn: "DiscountTimeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<Guid>(nullable: false),
                    OrderHeaderId = table.Column<Guid>(nullable: false),
                    ArticleId = table.Column<long>(nullable: false),
                    Discount = table.Column<double>(nullable: false),
                    VatAmount = table.Column<double>(nullable: false),
                    DateOfEntry = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    SalesQty = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    ArticleNo = table.Column<string>(nullable: true),
                    Approved = table.Column<string>(nullable: true),
                    ApprovedDate = table.Column<DateTime>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false),
                    SalesTotalPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_OrderHeaders_OrderHeaderId",
                        column: x => x.OrderHeaderId,
                        principalTable: "OrderHeaders",
                        principalColumn: "OrderHeaderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sub_SubCategories",
                columns: table => new
                {
                    Sub_S_Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    status = table.Column<bool>(nullable: false),
                    SubCategoryS_Id = table.Column<long>(nullable: true),
                    Brand_Id = table.Column<long>(nullable: true),
                    SubSubCatImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sub_SubCategories", x => x.Sub_S_Id);
                    table.ForeignKey(
                        name: "FK_Sub_SubCategories_Brands_Brand_Id",
                        column: x => x.Brand_Id,
                        principalTable: "Brands",
                        principalColumn: "Brand_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sub_SubCategories_SubCategories_SubCategoryS_Id",
                        column: x => x.SubCategoryS_Id,
                        principalTable: "SubCategories",
                        principalColumn: "S_Id",
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

            migrationBuilder.CreateTable(
                name: "Sub_Sub_SubCategories",
                columns: table => new
                {
                    SubSub_S_Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    status = table.Column<bool>(nullable: false),
                    Sub_SubCategorySub_S_Id = table.Column<long>(nullable: true),
                    SubSubSubCatImage = table.Column<string>(nullable: true),
                    Brand_Id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sub_Sub_SubCategories", x => x.SubSub_S_Id);
                    table.ForeignKey(
                        name: "FK_Sub_Sub_SubCategories_Brands_Brand_Id",
                        column: x => x.Brand_Id,
                        principalTable: "Brands",
                        principalColumn: "Brand_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sub_Sub_SubCategories_Sub_SubCategories_Sub_SubCategorySub_S_Id",
                        column: x => x.Sub_SubCategorySub_S_Id,
                        principalTable: "Sub_SubCategories",
                        principalColumn: "Sub_S_Id",
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
                name: "IX_BasketValueDiscount_DiscountTimeId",
                table: "BasketValueDiscount",
                column: "DiscountTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_courierContactPersons_CourierCompanyMastercompany_Id",
                table: "courierContactPersons",
                column: "CourierCompanyMastercompany_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProfileInfos_DeliveryAddressDeAdd_Id",
                table: "CustomerProfileInfos",
                column: "DeliveryAddressDeAdd_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountDetails_DiscountTimeId",
                table: "DiscountDetails",
                column: "DiscountTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerID1",
                table: "Order",
                column: "CustomerID1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderHeaderId",
                table: "OrderDetails",
                column: "OrderHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ItemID",
                table: "OrderItem",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderID",
                table: "OrderItem",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Sub_Sub_SubCategories_Brand_Id",
                table: "Sub_Sub_SubCategories",
                column: "Brand_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sub_Sub_SubCategories_Sub_SubCategorySub_S_Id",
                table: "Sub_Sub_SubCategories",
                column: "Sub_SubCategorySub_S_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sub_SubCategories_Brand_Id",
                table: "Sub_SubCategories",
                column: "Brand_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sub_SubCategories_SubCategoryS_Id",
                table: "Sub_SubCategories",
                column: "SubCategoryS_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_Brand_Id",
                table: "SubCategories",
                column: "Brand_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryC_Id",
                table: "SubCategories",
                column: "CategoryC_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "ArticleImageVarients");

            migrationBuilder.DropTable(
                name: "ArticleMatrices");

            migrationBuilder.DropTable(
                name: "ArticleVariants");

            migrationBuilder.DropTable(
                name: "BasketValueDiscount");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "courierContactPersons");

            migrationBuilder.DropTable(
                name: "CustomerInstallationInfos");

            migrationBuilder.DropTable(
                name: "CustomerProfileInfos");

            migrationBuilder.DropTable(
                name: "DiscountDetails");

            migrationBuilder.DropTable(
                name: "DiscountTypes");

            migrationBuilder.DropTable(
                name: "HaltArticles");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "OtherInformations");

            migrationBuilder.DropTable(
                name: "Pricings");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "SoldArticles");

            migrationBuilder.DropTable(
                name: "Sub_Sub_SubCategories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vats");

            migrationBuilder.DropTable(
                name: "ArticleDetails");

            migrationBuilder.DropTable(
                name: "courierCompanyMasters");

            migrationBuilder.DropTable(
                name: "DeliveryAddresses");

            migrationBuilder.DropTable(
                name: "DiscountTimes");

            migrationBuilder.DropTable(
                name: "OrderHeaders");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Sub_SubCategories");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categorys");
        }
    }
}
