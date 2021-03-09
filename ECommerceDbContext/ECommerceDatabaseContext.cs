using Microsoft.EntityFrameworkCore;
using ShopModels.Models;
using ShopModels.OrderModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceDbContext
{
    public class ECommerceDatabaseContext:DbContext
    {
        public ECommerceDatabaseContext(DbContextOptions<ECommerceDatabaseContext> options):base(options)
        {

        }



        public DbSet<Category> Categorys { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Sub_SubCategory> Sub_SubCategories { get; set; }
        public DbSet<ArticleDetails> ArticleDetails { get; set; }
        public DbSet<ArticleImageVarient> ArticleImageVarients { get; set; }
        public DbSet<ArticleMatrix> ArticleMatrices { get; set; }
        public DbSet<ArticleVariant> ArticleVariants { get; set; }
        public DbSet<CustomerInstallationInfo> CustomerInstallationInfos { get; set; }
        public DbSet<BillingAddress> BillingAddresses { get; set; }
        public DbSet<ShippingAddress> ShippingAddresses { get; set; }
        public DbSet<HaltArticle> HaltArticles { get; set; }
        public DbSet<OtherInformation> OtherInformations { get; set; }
        public DbSet<Pricing> Pricings { get; set; }
        public DbSet<SoldArticle> SoldArticles { get; set; }
        public DbSet<User> Users { get; set; }
       
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DiscountType> DiscountTypes { get; set; }
        public DbSet<DiscountTime> DiscountTimes { get; set; }
        public DbSet<DiscountDetail> DiscountDetails { get; set; }
        public DbSet<Vat> Vats { get; set; }
        public DbSet<CourierCompanyMaster> courierCompanyMasters { get; set; }
        public DbSet<CourierContactPerson> courierContactPersons { get; set; }
        public DbSet<Sub_Sub_SubCategory> Sub_Sub_SubCategories { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<BannerInfo> BannerInfo { get; set; }
        public DbSet<DeliveryInfoDetails> DeliveryInfoDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here
            //DeliveryInfoDetails
            modelBuilder.Entity<DeliveryInfoDetails>()
                      .HasKey(c => c.Del_InId);
            //BannerInfo
            modelBuilder.Entity<BannerInfo>()
                       .HasKey(c => c.BannerId);
            //BillingAddress
            modelBuilder.Entity<BillingAddress>()
                        .HasKey(c => c.BillingAdd_Id);
            //ShippingAddress
            modelBuilder.Entity<ShippingAddress>()
                       .HasKey(c => c.ShippingAdd_Id);
            //Region
            modelBuilder.Entity<Region>()
                     .HasKey(c => c.RegionId);
            //Region
            modelBuilder.Entity<City>()
                     .HasKey(c => c.CityId);
            //Region
            modelBuilder.Entity<Area>()
                     .HasKey(c => c.AreaId);
            //OrderHeader
            modelBuilder.Entity<OrderHeader>()
                        .HasKey(c => c.OrderHeaderId);
            //OrderDetail
            modelBuilder.Entity<OrderDetail>()
                   .HasKey(c => c.OrderDetailId);
            //DiscouintDetails
            modelBuilder.Entity<DiscountDetail>()
                        .HasKey(c => c.DiscountDetailId);
            modelBuilder.Entity<DiscountDetail>()
                        .Property(c => c.DiscountPercentage)
                        .IsRequired();
            //DiscouyntType
            modelBuilder.Entity<DiscountType>()
                        .HasKey(c => c.DiscountTypeId);
            modelBuilder.Entity<DiscountType>()
                        .Property(c => c.DiscountName)
                        .IsRequired();
            modelBuilder.Entity<DiscountType>()
                        .Property(c => c.DateOfEntry)
                        .IsRequired();
            modelBuilder.Entity<DiscountTime>()
                        .HasKey(c => c.DiscountTimeId);
            modelBuilder.Entity<DiscountTime>()
                        .Property(c => c.DiscountFromDate)
                        .IsRequired();
            modelBuilder.Entity<DiscountTime>()
                         .Property(c => c.DiscountTimeTo)
                         .IsRequired();
            //CourierCompanyMaster
            modelBuilder.Entity<CourierCompanyMaster>()
                        .HasKey(c => c.company_Id);
            modelBuilder.Entity<CourierCompanyMaster>()
                        .Property(c => c.companyName)
                        .IsRequired();
            modelBuilder.Entity<CourierCompanyMaster>()
                        .Property(c => c.contactPerson)
                        .IsRequired();
            modelBuilder.Entity<CourierCompanyMaster>()
                        .Property(c => c.Email)
                        .IsRequired();
            modelBuilder.Entity<CourierCompanyMaster>()
                        .Property(c => c.Phone)
                        .IsRequired();
            modelBuilder.Entity<CourierCompanyMaster>()
                        .Property(c => c.website)
                        .IsRequired();
            modelBuilder.Entity<CourierCompanyMaster>()
                        .Property(c => c.Remarks)
                        .IsRequired()
                        .HasMaxLength(600);
            //CourierContactPerson
            modelBuilder.Entity<CourierContactPerson>()
                        .HasKey(c => c.person_Id);
            modelBuilder.Entity<CourierContactPerson>()
                        .Property(c => c.personName)
                        .IsRequired();
            modelBuilder.Entity<CourierContactPerson>()
                        .Property(c => c.phone1)
                        .IsRequired();
            modelBuilder.Entity<CourierContactPerson>()
                        .Property(c => c.phone2)
                        .IsRequired();
           

            //Property Configurations
            //TestClass1
           
            //Category
            modelBuilder.Entity<Category>()
                    .HasKey(c => c.C_Id);
            modelBuilder.Entity<Category>()
                        .Property(c => c.description)
                        .IsRequired();
            modelBuilder.Entity<Category>()
                        .Property(c => c.Name)
                        .IsRequired();
            //SubCategory
            modelBuilder.Entity<SubCategory>()
                        .HasKey(c => c.S_Id);
            modelBuilder.Entity<SubCategory>()
                        .Property(c => c.Name)
                        .IsRequired();
            //Sub_SubCategory
            modelBuilder.Entity<Sub_SubCategory>()
                        .HasKey(c => c.Sub_S_Id);
            modelBuilder.Entity<Sub_SubCategory>()
                        .Property(c => c.Name)
                        .IsRequired();
            //Sub_Sub_SubCategory
            modelBuilder.Entity<Sub_Sub_SubCategory>()
                        .HasKey(c => c.SubSub_S_Id);
            modelBuilder.Entity<Sub_Sub_SubCategory>()
                        .Property(c => c.Name)
                        .IsRequired();
            //ArticleDetails
            modelBuilder.Entity<ArticleDetails>()
                   .HasKey(c => c.ArtD_Id);
            modelBuilder.Entity<ArticleDetails>()
                        .Property(c => c.ArticleTitle)
                        .IsRequired();
            modelBuilder.Entity<ArticleDetails>()
                       .Property(c => c.ArticleSubtitle)
                       .IsRequired();
          
            modelBuilder.Entity<ArticleDetails>()
                        .Property(c => c.Description)
                        .IsRequired()
                        .HasMaxLength(900);

          

            //one to one Relationship ArticleDetails with Pricing
            /*   modelBuilder.Entity<ArticleDetails>()
             .HasOne<Pricing>(s => s.Pricing)
             .WithOne(ad => ad.ArticleDetails)
             .HasForeignKey<Pricing>(ad => ad.ArticleDetails_Id);*/

            //ArticleImageVarient
            modelBuilder.Entity<ArticleImageVarient>()
                        .HasKey(c => c.Img_Id);
            modelBuilder.Entity<ArticleImageVarient>()
                        .Property(c => c.ImageName);
            //ArticleMatrix
            modelBuilder.Entity<ArticleMatrix>()
                        .HasKey(c => c.ArtM_Id);
            modelBuilder.Entity<ArticleMatrix>()
                        .Property(c => c.Description);
            //ArticleVariant
            modelBuilder.Entity<ArticleVariant>()
                        .HasKey(c => c.ArtV_Id);
            modelBuilder.Entity<ArticleVariant>()
                        .Property(c => c.ArticleNo);
            modelBuilder.Entity<ArticleVariant>()
                        .Property(c => c.Gender);
            modelBuilder.Entity<ArticleVariant>()
                       .Property(c => c.Color);
            modelBuilder.Entity<ArticleVariant>()
                     .Property(c => c.Size);

            //CustomerInstallationInfo
            modelBuilder.Entity<CustomerInstallationInfo>()
                        .HasKey(c => c.CusPIn_Id);
            modelBuilder.Entity<CustomerInstallationInfo>()
                        .Property(c => c.CustomerName)
                        .IsRequired();
            modelBuilder.Entity<CustomerInstallationInfo>()
                        .Property(c => c.CustomerMobileNo)
                        .IsRequired();
            modelBuilder.Entity<CustomerInstallationInfo>()
                  .Property(c => c.InstallationDate);
          
            //HaltArticle
            modelBuilder.Entity<HaltArticle>()
                        .HasKey(c => c.HArt_Id);
            modelBuilder.Entity<HaltArticle>()
                        .Property(c => c.ArticleName);
            modelBuilder.Entity<HaltArticle>()
                .Property(c => c.ArticleNo);
            modelBuilder.Entity<HaltArticle>()
               .Property(c => c.Size);
            modelBuilder.Entity<HaltArticle>()
               .Property(c => c.Brand);
            //OtherInformation
            modelBuilder.Entity<OtherInformation>()
                        .HasKey(c => c.Oth_Id);
            modelBuilder.Entity<OtherInformation>()
                        .Property(c => c.RptCategory);
            modelBuilder.Entity<OtherInformation>()
                       .Property(c => c.RptSubCategory);

            //Pricing
            modelBuilder.Entity<Pricing>()
                        .HasKey(c => c.Pricing_Id);
            modelBuilder.Entity<Pricing>()
                        .Property(c => c.StandardPrice);
            //soldarticle
            modelBuilder.Entity<SoldArticle>()
                        .HasKey(c => c.SArt_Id);
            modelBuilder.Entity<SoldArticle>()
                        .Property(c => c.ArticleName);
            modelBuilder.Entity<SoldArticle>()
                      .Property(c => c.ArticleNo);
            modelBuilder.Entity<SoldArticle>()
                    .Property(c => c.Color);
            modelBuilder.Entity<SoldArticle>()
                 .Property(c => c.Size);
            modelBuilder.Entity<SoldArticle>()
                 .Property(c => c.Brand);

            //User
            modelBuilder.Entity<User>()
                        .HasKey(c => c.User_Id);
            modelBuilder.Entity<User>()
                        .Property(c => c.UserName);
            modelBuilder.Entity<User>()
                       .Property(c => c.LoginId);
            modelBuilder.Entity<User>()
                    .Property(c => c.Email);
            modelBuilder.Entity<User>()
                    .Property(c => c.MobileNo);
            modelBuilder.Entity<User>()
                  .Property(c => c.Roles);

            //Brand
            modelBuilder.Entity<Brand>()
                        .HasKey(c => c.Brand_Id);
            modelBuilder.Entity<Brand>()
                        .Property(c => c.BrandName)
                        .IsRequired();
            //Vat

            modelBuilder.Entity<Vat>()
                        .HasKey(c => c.Vat_Id);
            modelBuilder.Entity<Vat>()
                        .Property(c => c.VatTypeName);
            modelBuilder.Entity<Vat>()
                        .Property(c => c.Vat_Rat)
                        .IsRequired();

            //OrderModel

            //Customer

            modelBuilder.Entity<Customer>()
                        .HasKey(c => c.CustomerID);
            modelBuilder.Entity<Customer>()
                        .Property(c => c.Name);
            //Order
            modelBuilder.Entity<Order>()
                        .HasKey(c => c.OrderID);
            //item
            modelBuilder.Entity<Item>()
                        .HasKey(c => c.ItemID);

            //OrderItem
            modelBuilder.Entity<OrderItem>()
                        .HasKey(c => c.OrderItemID);


        }

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("User ID=sa;password=sa9;Initial Catalog=E-CommerceAppDb;Data Source=192.168.5.17,1555;Persist Security Info=False;Connection Timeout=1000;");

        }*/


    }
}
