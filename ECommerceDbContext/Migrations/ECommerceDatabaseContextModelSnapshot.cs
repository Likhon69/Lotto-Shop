﻿// <auto-generated />
using System;
using ECommerceDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECommerceDbContext.Migrations
{
    [DbContext(typeof(ECommerceDatabaseContext))]
    partial class ECommerceDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShopModels.Models.ArticleDetails", b =>
                {
                    b.Property<int>("ArtD_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArticleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CategoryC_Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(900)")
                        .HasMaxLength(900);

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SubCategoryS_Id")
                        .HasColumnType("int");

                    b.HasKey("ArtD_Id");

                    b.HasIndex("CategoryC_Id");

                    b.HasIndex("SubCategoryS_Id");

                    b.ToTable("ArticleDetails");
                });

            modelBuilder.Entity("ShopModels.Models.ArticleImageVarient", b =>
                {
                    b.Property<int>("Img_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArticleDetailsArtD_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<int>("Created_By")
                        .HasColumnType("int");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated_At")
                        .HasColumnType("datetime2");

                    b.Property<int>("Updated_By")
                        .HasColumnType("int");

                    b.HasKey("Img_Id");

                    b.HasIndex("ArticleDetailsArtD_Id");

                    b.ToTable("ArticleImageVarients");
                });

            modelBuilder.Entity("ShopModels.Models.ArticleMatrix", b =>
                {
                    b.Property<int>("ArtM_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArtM_Id");

                    b.ToTable("ArticleMatrices");
                });

            modelBuilder.Entity("ShopModels.Models.ArticleVariant", b =>
                {
                    b.Property<int>("ArtV_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArticleDetailsArtD_Id")
                        .HasColumnType("int");

                    b.Property<string>("ArticleNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<string>("Style")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArtV_Id");

                    b.HasIndex("ArticleDetailsArtD_Id");

                    b.ToTable("ArticleVariants");
                });

            modelBuilder.Entity("ShopModels.Models.Category", b =>
                {
                    b.Property<int>("C_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("shortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("C_Id");

                    b.ToTable("Categorys");
                });

            modelBuilder.Entity("ShopModels.Models.CustomerInstallationInfo", b =>
                {
                    b.Property<int>("CusPIn_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerMobileNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InstallationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CusPIn_Id");

                    b.ToTable("CustomerInstallationInfos");
                });

            modelBuilder.Entity("ShopModels.Models.CustomerProfileInfo", b =>
                {
                    b.Property<int>("CustP_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BuyDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeliveryAddressDeAdd_Id")
                        .HasColumnType("int");

                    b.Property<string>("RecieverName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecieverPhoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustP_Id");

                    b.HasIndex("DeliveryAddressDeAdd_Id");

                    b.ToTable("CustomerProfileInfos");
                });

            modelBuilder.Entity("ShopModels.Models.DeliveryAddress", b =>
                {
                    b.Property<int>("DeAdd_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HouseNo")
                        .HasColumnType("int");

                    b.Property<int>("RoadNo")
                        .HasColumnType("int");

                    b.Property<string>("SubDistrict")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("floorNo")
                        .HasColumnType("int");

                    b.HasKey("DeAdd_Id");

                    b.ToTable("DeliveryAddresses");
                });

            modelBuilder.Entity("ShopModels.Models.HaltArticle", b =>
                {
                    b.Property<int>("HArt_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArticleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArticleNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("HArt_Id");

                    b.ToTable("HaltArticles");
                });

            modelBuilder.Entity("ShopModels.Models.OtherInformation", b =>
                {
                    b.Property<int>("Oth_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RptCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RptSubCategory")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Oth_Id");

                    b.ToTable("OtherInformations");
                });

            modelBuilder.Entity("ShopModels.Models.Pricing", b =>
                {
                    b.Property<int>("Pricing_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArticleDetails_Id")
                        .HasColumnType("int");

                    b.Property<decimal>("DealerPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("DiscontPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("DiscountRate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("FranchisePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("InstitutePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("OtherPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PurchaseCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("StandardPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("VatRate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("WholeSalePrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Pricing_Id");

                    b.HasIndex("ArticleDetails_Id")
                        .IsUnique();

                    b.ToTable("Pricings");
                });

            modelBuilder.Entity("ShopModels.Models.SoldArticle", b =>
                {
                    b.Property<int>("SArt_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArticleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArticleNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("SArt_Id");

                    b.ToTable("SoldArticles");
                });

            modelBuilder.Entity("ShopModels.Models.SubCategory", b =>
                {
                    b.Property<int>("S_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("shortName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("S_Id");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("ShopModels.Models.User", b =>
                {
                    b.Property<int>("User_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LoginId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Roles")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("User_Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ShopModels.Models.ArticleDetails", b =>
                {
                    b.HasOne("ShopModels.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryC_Id");

                    b.HasOne("ShopModels.Models.SubCategory", "SubCategory")
                        .WithMany()
                        .HasForeignKey("SubCategoryS_Id");
                });

            modelBuilder.Entity("ShopModels.Models.ArticleImageVarient", b =>
                {
                    b.HasOne("ShopModels.Models.ArticleDetails", "ArticleDetails")
                        .WithMany("ArticleImageVarients")
                        .HasForeignKey("ArticleDetailsArtD_Id");
                });

            modelBuilder.Entity("ShopModels.Models.ArticleVariant", b =>
                {
                    b.HasOne("ShopModels.Models.ArticleDetails", "ArticleDetails")
                        .WithMany("ArticleVariants")
                        .HasForeignKey("ArticleDetailsArtD_Id");
                });

            modelBuilder.Entity("ShopModels.Models.CustomerProfileInfo", b =>
                {
                    b.HasOne("ShopModels.Models.DeliveryAddress", "DeliveryAddress")
                        .WithMany()
                        .HasForeignKey("DeliveryAddressDeAdd_Id");
                });

            modelBuilder.Entity("ShopModels.Models.Pricing", b =>
                {
                    b.HasOne("ShopModels.Models.ArticleDetails", "ArticleDetails")
                        .WithOne("Pricing")
                        .HasForeignKey("ShopModels.Models.Pricing", "ArticleDetails_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
