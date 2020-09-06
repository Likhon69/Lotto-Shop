using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ECommerceDbContext.ECOMDBENTITIES
{
    public partial class ECOMDBContext : DbContext
    {
        public ECOMDBContext()
        {
        }

        public ECOMDBContext(DbContextOptions<ECOMDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AreaRate> AreaRate { get; set; }
        public virtual DbSet<Articlemaster> Articlemaster { get; set; }
        public virtual DbSet<Articlematrix> Articlematrix { get; set; }
        public virtual DbSet<Articlepricemaster> Articlepricemaster { get; set; }
        public virtual DbSet<CourierAgreementMaster> CourierAgreementMaster { get; set; }
        public virtual DbSet<CourierCompanyMasters> CourierCompanyMasters { get; set; }
        public virtual DbSet<CourierContactPersons> CourierContactPersons { get; set; }
        public virtual DbSet<CustomerAddressLabel> CustomerAddressLabel { get; set; }
        public virtual DbSet<CustomerAddressMaster> CustomerAddressMaster { get; set; }
        public virtual DbSet<CustomerMaster> CustomerMaster { get; set; }
        public virtual DbSet<DistrictAreaMaster> DistrictAreaMaster { get; set; }
        public virtual DbSet<DistrictMaster> DistrictMaster { get; set; }
        public virtual DbSet<Imagemaster> Imagemaster { get; set; }
        public virtual DbSet<Matrixmaster> Matrixmaster { get; set; }
        public virtual DbSet<SalesOrderDetails> SalesOrderDetails { get; set; }
        public virtual DbSet<SalesOrderDetailsTmp> SalesOrderDetailsTmp { get; set; }
        public virtual DbSet<SalesOrderHeader> SalesOrderHeader { get; set; }
        public virtual DbSet<Sysdocsrno> Sysdocsrno { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=192.168.5.17,1555;Database=ECOMDB;Trusted_Connection=False;User ID=sa;Password=sa9");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AreaRate>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AREA_RATE");

                entity.Property(e => e.DistAreaId).HasColumnName("DIST_AREA_ID");

                entity.Property(e => e.Rate)
                    .HasColumnName("RATE")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.WeightKg).HasColumnName("WEIGHT_KG");
            });

            modelBuilder.Entity<Articlemaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ARTICLEMASTER");

                entity.Property(e => e.ArtCode).HasColumnName("ART_CODE");

                entity.Property(e => e.ArtName)
                    .HasColumnName("ART_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ArtSource)
                    .HasColumnName("ART_SOURCE")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ArtType)
                    .HasColumnName("ART_TYPE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ArtexCode)
                    .HasColumnName("ARTEX_CODE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Artno)
                    .HasColumnName("ARTNO")
                    .HasMaxLength(50);

                entity.Property(e => e.BrandId).HasColumnName("BRAND_ID");

                entity.Property(e => e.CatId).HasColumnName("CAT_ID");

                entity.Property(e => e.ColorId).HasColumnName("COLOR_ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("CREATED_AT")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(30);

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.DesignId).HasColumnName("DESIGN_ID");

                entity.Property(e => e.DisApply).HasColumnName("DIS_APPLY");

                entity.Property(e => e.Discounted).HasColumnName("DISCOUNTED");

                entity.Property(e => e.FashionId).HasColumnName("FASHION_ID");

                entity.Property(e => e.FlavourId).HasColumnName("FLAVOUR_ID");

                entity.Property(e => e.GendirId).HasColumnName("GENDIR_ID");

                entity.Property(e => e.GradeId).HasColumnName("GRADE_ID");

                entity.Property(e => e.LoyaErn).HasColumnName("LOYA_ERN");

                entity.Property(e => e.MaterialId).HasColumnName("MATERIAL_ID");

                entity.Property(e => e.NewArr)
                    .HasColumnName("NEW_ARR")
                    .HasMaxLength(50);

                entity.Property(e => e.Online)
                    .HasColumnName("ONLINE")
                    .HasMaxLength(50);

                entity.Property(e => e.OrgId).HasColumnName("ORG_ID");

                entity.Property(e => e.Particle).HasColumnName("PARTICLE");

                entity.Property(e => e.Pimage)
                    .HasColumnName("PIMAGE")
                    .HasMaxLength(150);

                entity.Property(e => e.Rptop1)
                    .HasColumnName("rptop1")
                    .HasMaxLength(20);

                entity.Property(e => e.Rptop2)
                    .HasColumnName("rptop2")
                    .HasMaxLength(20);

                entity.Property(e => e.SegId).HasColumnName("SEG_ID");

                entity.Property(e => e.SessionId).HasColumnName("SESSION_ID");

                entity.Property(e => e.Shortname)
                    .HasColumnName("SHORTNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SizeId).HasColumnName("SIZE_ID");

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.Property(e => e.StyleId).HasColumnName("STYLE_ID");

                entity.Property(e => e.SubId).HasColumnName("SUB_ID");

                entity.Property(e => e.SupCode).HasColumnName("SUP_CODE");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("UPDATED_AT")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasMaxLength(50);

                entity.Property(e => e.VatRat).HasColumnName("VAT_RAT");
            });

            modelBuilder.Entity<Articlematrix>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ARTICLEMATRIX");

                entity.Property(e => e.Artmid).HasColumnName("ARTMID");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Discode)
                    .HasColumnName("DISCODE")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Extid)
                    .HasColumnName("EXTID")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Matrixid).HasColumnName("MATRIXID");
            });

            modelBuilder.Entity<Articlepricemaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ARTICLEPRICEMASTER");

                entity.Property(e => e.ArtCode).HasColumnName("ART_CODE");

                entity.Property(e => e.BookingQty)
                    .HasColumnName("BOOKING_QTY")
                    .HasColumnType("decimal(18, 9)");

                entity.Property(e => e.BunitId).HasColumnName("BUNIT_ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("CREATED_AT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(20);

                entity.Property(e => e.DsPrice)
                    .HasColumnName("DS_PRICE")
                    .HasColumnType("decimal(18, 9)");

                entity.Property(e => e.FrPrice)
                    .HasColumnName("FR_PRICE")
                    .HasColumnType("decimal(18, 9)");

                entity.Property(e => e.InPrice)
                    .HasColumnName("IN_PRICE")
                    .HasColumnType("decimal(18, 9)");

                entity.Property(e => e.Instanceid).HasColumnName("INSTANCEID");

                entity.Property(e => e.Loyaltycearn)
                    .HasColumnName("LOYALTYCEARN")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Loyltyearn)
                    .HasColumnName("LOYLTYEARN")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Mrppurchase)
                    .HasColumnName("MRPPURCHASE")
                    .HasColumnType("decimal(18, 9)");

                entity.Property(e => e.Mrpsales)
                    .HasColumnName("MRPSALES")
                    .HasColumnType("decimal(18, 9)");

                entity.Property(e => e.OnPrice)
                    .HasColumnName("ON_PRICE")
                    .HasColumnType("decimal(18, 9)");

                entity.Property(e => e.OrgId).HasColumnName("ORG_ID");

                entity.Property(e => e.OtPrice)
                    .HasColumnName("OT_PRICE")
                    .HasColumnType("decimal(18, 9)");

                entity.Property(e => e.PickingQty)
                    .HasColumnName("PICKING_QTY")
                    .HasColumnType("decimal(18, 9)");

                entity.Property(e => e.Purchacost)
                    .HasColumnName("PURCHACOST")
                    .HasColumnType("decimal(18, 9)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("QUANTITY")
                    .HasColumnType("decimal(18, 9)");

                entity.Property(e => e.ReorderLevel)
                    .HasColumnName("REORDER_LEVEL")
                    .HasColumnType("decimal(18, 9)");

                entity.Property(e => e.ReorderSize)
                    .HasColumnName("REORDER_SIZE")
                    .HasColumnType("decimal(18, 9)");

                entity.Property(e => e.SalesPrice)
                    .HasColumnName("SALES_PRICE")
                    .HasColumnType("decimal(18, 9)");

                entity.Property(e => e.SeftystkLevel)
                    .HasColumnName("SEFTYSTK_LEVEL")
                    .HasColumnType("decimal(18, 9)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("UPDATED_AT")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasMaxLength(50);

                entity.Property(e => e.VatRate)
                    .HasColumnName("VAT_RATE")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.WhPrice)
                    .HasColumnName("WH_PRICE")
                    .HasColumnType("decimal(18, 9)");
            });

            modelBuilder.Entity<CourierAgreementMaster>(entity =>
            {
                entity.HasKey(c=>c.AgreementId);

                entity.ToTable("courierAgreementMaster");

                entity.Property(e => e.AgreementId)
                
                    .HasColumnName("AGREEMENT_ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Amount)
                    .HasColumnName("AMOUNT")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CourierId).HasColumnName("COURIER_ID");

                entity.Property(e => e.DistAreaId).HasColumnName("DIST_AREA_ID");
            });

            modelBuilder.Entity<CourierCompanyMasters>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("courierCompanyMasters");

                entity.Property(e => e.CompanyId).HasColumnName("company_Id");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnName("companyName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPerson)
                    .IsRequired()
                    .HasColumnName("contactPerson")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_By")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .IsRequired()
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Website)
                    .IsRequired()
                    .HasColumnName("website")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CourierContactPersons>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("courierContactPersons");

                entity.Property(e => e.CourierCompanyMastercompanyId).HasColumnName("CourierCompanyMastercompany_Id");

                entity.Property(e => e.CreatedAt).HasColumnName("Created_At");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_By")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PersonId).HasColumnName("person_Id");

                entity.Property(e => e.PersonName)
                    .IsRequired()
                    .HasColumnName("personName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone1)
                    .IsRequired()
                    .HasColumnName("phone1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone2)
                    .IsRequired()
                    .HasColumnName("phone2")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerAddressLabel>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CUSTOMER_ADDRESS_LABEL");

                entity.Property(e => e.LabelId).HasColumnName("LABEL_ID");

                entity.Property(e => e.LabelName)
                    .HasColumnName("LABEL_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerAddressMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CUSTOMER_ADDRESS_MASTER");

                entity.Property(e => e.AddressDetails)
                    .HasColumnName("ADDRESS_DETAILS")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.AddressId).HasColumnName("ADDRESS_ID");

                entity.Property(e => e.AddressLabel).HasColumnName("ADDRESS_LABEL");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("CREATED_AT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerId).HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.DistAreaId).HasColumnName("DIST_AREA_ID");

                entity.Property(e => e.DistrictId).HasColumnName("DISTRICT_ID");

                entity.Property(e => e.IsDefault).HasColumnName("IS_DEFAULT");

                entity.Property(e => e.ReceipientFirstname)
                    .HasColumnName("RECEIPIENT_FIRSTNAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReceipientLastname)
                    .HasColumnName("RECEIPIENT_LASTNAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RecipientMobile)
                    .HasColumnName("RECIPIENT_MOBILE")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.SpecialInstruction)
                    .HasColumnName("SPECIAL_INSTRUCTION")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("UPDATED_AT")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CUSTOMER_MASTER");

                entity.Property(e => e.AddressId).HasColumnName("ADDRESS_ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("CREATED_AT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustomerEmail)
                    .HasColumnName("CUSTOMER_EMAIL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerFirstname)
                    .HasColumnName("CUSTOMER_FIRSTNAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerId).HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.CustomerLastname)
                    .HasColumnName("CUSTOMER_LASTNAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerMobile)
                    .HasColumnName("CUSTOMER_MOBILE")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DistrictAreaMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DISTRICT_AREA_MASTER");

                entity.Property(e => e.DistAreaId).HasColumnName("DIST_AREA_ID");

                entity.Property(e => e.DistAreaName)
                    .IsRequired()
                    .HasColumnName("DIST_AREA_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DistId).HasColumnName("DIST_ID");
            });

            modelBuilder.Entity<DistrictMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DISTRICT_MASTER");

                entity.Property(e => e.DistId).HasColumnName("DIST_ID");

                entity.Property(e => e.DistName)
                    .IsRequired()
                    .HasColumnName("DIST_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Imagemaster>(entity =>
            {
                entity.HasKey(e => e.ImageId);

                entity.ToTable("IMAGEMASTER");

                entity.Property(e => e.ImageId)
                    .HasColumnName("IMAGE_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArtCode).HasColumnName("ART_CODE");

                entity.Property(e => e.Article)
                    .HasColumnName("ARTICLE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("CREATED_AT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayOrder).HasColumnName("DISPLAY_ORDER");

                entity.Property(e => e.ImageName)
                    .HasColumnName("IMAGE_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsDefault).HasColumnName("IS_DEFAULT");
            });

            modelBuilder.Entity<Matrixmaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MATRIXMASTER");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Matrixid).HasColumnName("MATRIXID");
            });

            modelBuilder.Entity<SalesOrderDetails>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SALES_ORDER_DETAILS");

                entity.Property(e => e.ArticleCode).HasColumnName("Article_Code");

                entity.Property(e => e.ArticleNo)
                    .HasColumnName("Article_No")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BusinessUnitId).HasColumnName("BusinessUnit_ID");

                entity.Property(e => e.CostPrice).HasColumnType("money");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("Created_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DiscountAmount)
                    .HasColumnName("Discount_Amount")
                    .HasColumnType("money");

                entity.Property(e => e.DiscountRefType).HasColumnName("DiscountRef_Type");

                entity.Property(e => e.GrossAmount)
                    .HasColumnName("Gross_Amount")
                    .HasColumnType("money");

                entity.Property(e => e.InstanceId).HasColumnName("Instance_ID");

                entity.Property(e => e.LineNo).HasColumnName("Line_No");

                entity.Property(e => e.OrderNo)
                    .HasColumnName("Order_No")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentMethod).HasColumnName("Payment_method");

                entity.Property(e => e.PaymentStatus).HasColumnName("Payment_Status");

                entity.Property(e => e.RefId).HasColumnName("Ref_ID");

                entity.Property(e => e.SBarcode)
                    .HasColumnName("sBarcode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SalesPrice).HasColumnType("money");
            });

            modelBuilder.Entity<SalesOrderDetailsTmp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SALES_ORDER_DETAILS_TMP");

                entity.Property(e => e.ArtCode).HasColumnName("Art_Code");

                entity.Property(e => e.ArticleNo)
                    .HasColumnName("Article_No")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CostPrice).HasColumnType("money");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("Created_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DiscountAmount)
                    .HasColumnName("Discount_Amount")
                    .HasColumnType("money");

                entity.Property(e => e.DiscountRefType).HasColumnName("DiscountRef_Type");

                entity.Property(e => e.GrossAmount)
                    .HasColumnName("Gross_Amount")
                    .HasColumnType("money");

                entity.Property(e => e.InstanceId).HasColumnName("Instance_ID");

                entity.Property(e => e.LineNo).HasColumnName("Line_No");

                entity.Property(e => e.OrderNo)
                    .HasColumnName("Order_No")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RefId).HasColumnName("Ref_ID");

                entity.Property(e => e.SalesPrice).HasColumnType("money");
            });

            modelBuilder.Entity<SalesOrderHeader>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SALES_ORDER_HEADER");

                entity.Property(e => e.BusinessUnitId).HasColumnName("BusinessUnit_ID");

                entity.Property(e => e.CancelDate)
                    .HasColumnName("Cancel_Date")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("Created_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("Customer_ID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DeviceId).HasColumnName("Device_ID");

                entity.Property(e => e.ExternalId)
                    .HasColumnName("External_ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GrossAmount)
                    .HasColumnName("Gross_Amount")
                    .HasColumnType("money");

                entity.Property(e => e.InstanceId).HasColumnName("Instance_ID");

                entity.Property(e => e.IsPosted).HasColumnName("Is_Posted");

                entity.Property(e => e.NetAmount)
                    .HasColumnName("Net_Amount")
                    .HasColumnType("money");

                entity.Property(e => e.OrderDate)
                    .HasColumnName("Order_Date")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.OrderNo)
                    .HasColumnName("Order_No")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PostingDate)
                    .HasColumnName("Posting_Date")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.RefId).HasColumnName("Ref_ID");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SalesEmployeeId).HasColumnName("Sales_Employee_ID");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("Updated_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");

                entity.Property(e => e.ValidFromDate)
                    .HasColumnName("ValidFrom_Date")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.ValidToDate)
                    .HasColumnName("ValidTo_Date")
                    .HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<Sysdocsrno>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SYSDOCSRNO");

                entity.Property(e => e.Documentid)
                    .HasColumnName("DOCUMENTID")
                    .HasMaxLength(100);

                entity.Property(e => e.ForMat)
                    .HasColumnName("FOR_MAT")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Format1)
                    .HasColumnName("FORMAT")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lastserialno).HasColumnName("LASTSERIALNO");

                entity.Property(e => e.Regid).HasColumnName("REGID");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.UserId)
                    .HasColumnName("User_Id")
                    .ValueGeneratedOnAdd();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
