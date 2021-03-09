using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CommonUnitOfWork;
using ECommerceDbContext;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Repository.Contracts;
using Repository.Implementation;
using Repository.MobileContracts;
using Repository.MobileImplementation;
using Services.Contracts;
using Services.Implementation;
using Services.MobileContracts;
using Services.MobileImplementation;
using UserManagement.Contracts;
using UserManagement.Implementation;
using static UserManagement.Implementation.CustomEcommerceAuthenticationHandler;

namespace E_CommerceApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
         
            services.AddTransient<DbContext, ECommerceDatabaseContext>();
            services.AddDbContext<ECommerceDatabaseContext>(config =>
            {
                config.UseSqlServer(Configuration.GetConnectionString("SqlConnection"));
             
                
            });


            services.Configure<FormOptions>(config =>
            {
                config.ValueLengthLimit = int.MaxValue;
                config.MultipartBodyLengthLimit = int.MaxValue;
                config.MemoryBufferThreshold = int.MaxValue;
            });
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    
                );

                

            });

            services.AddScoped<IUnitOfWork, UnitofWork>();
            services.AddTransient<IShoePost, ShoePost>();
            services.AddTransient<IPostDataServices, PostDataServices>();
            services.AddTransient<IArticleDetailsPostService, ArticleDetailsPostService>();
            services.AddTransient<IArticleDetailsPostRepository, ArticleDetailsPostRepository>();
            services.AddTransient<IPricingPostRepository, PricingPostRepository>();
            services.AddTransient<ITokenEcommerceAuthentication, TokenEcommerceAuthentication>();
            services.AddTransient<IGetProcedure, GetProcedure>();
            services.AddTransient<IGetAllArticleRepository, GetAllArticleDetailsRepository>();
            services.AddTransient<IGetAllArticleDetailsManager, GetAllArtilceDetailsManager>();
            services.AddTransient<IPostArticleImageManager, PostArticleImageManager>();
            services.AddTransient<IPostArticleImageRepository, PostArticleImageRepository>();
            services.AddTransient<IGetDistrictMasterRepository, GetDistrictMasterRepository>();
            services.AddTransient<IGetDistrictMasterManager, GetDistrictMasterManager>();
            services.AddTransient<IGetDistrictAreaByDistrictIdRepository, GetDistrictAreaByDistrictIdRepository>();
            services.AddTransient<IGetDistrictAreaByDistrictIdManager, GetDistrictAreaByDistrictIdManager>();
            services.AddTransient<ICourierMasterPostRepository, CourierMasterPostRepository>();
            services.AddTransient<ICourierMasterPostManager, CourierMasterPostManager>();
            services.AddTransient<IGetCourierCompnayListRepository, GetCourierCompnayListRepository>();
            services.AddTransient<IGetCourierCompanyListManager, GetCourierCompanyListManager>();
            services.AddTransient<IOrderDetailsTempManager, OrderDetailsTempManager>();
            services.AddTransient<IOrderDetailsTempRepository, OrderDetailsTempRepository>();
            services.AddTransient<IPostCourierAgreementManager, PostCourierAgreementManager>();
            services.AddTransient<IPostCourierAgreementRepository, PostCourierAgreementRepository>();
            services.AddTransient<IOrderCreateManager, OrderCreateManager>();
            services.AddTransient<IOrderCreateRepository, OrderCreateRepository>();
            services.AddTransient<IAddressDetailsPostRepository, AddressDetailsPostRepository>();
            services.AddTransient<IAddressDetailsPostManager, AddressDetailsPostManager>();
            services.AddTransient<IOrderHeaderDetailsManager, OrderHeaderDetailsManager>();
            services.AddTransient<IOrderHeaderDetailsRepository, OrderHeaderDetailsRepository>();
            services.AddTransient<IOrderDetailsByOrderNoRepository, OrderDetailsByOrderNoRepository>();
            services.AddTransient<IOrderDetailsByOrderNoManager, OrderDetailsByOrderNoManager>();
            services.AddTransient<IOrderPickerManager, OrderPickerManager>();
            services.AddTransient<IOrderPickerRepository, OrderPickerRepository>();
            services.AddTransient<IOrderProcessManager, OrderProcessManager>();
            services.AddTransient<IOrderProcessRepository, OrderProcessRepository>();
            services.AddTransient<IGetAllArticleDetailsForMobileHomePageManager, GetAllArticleDetailsForMobileHomePageManager>();
            services.AddTransient<IGetAllArticleDetailsForMobileAppRepository, GetAllArticleDetailsForMobileAppRepository>();
            services.AddTransient<IGetArticleWiseImageManager, GetArticleWiseImageManager>();
            services.AddTransient<IGetArticleWiseImageRepository, GetArticleWiseImageRepository>();
            services.AddTransient<IGetArticleVariantsManager, GetArticleVariantsManager>();
            services.AddTransient<IGetArticleVariantsRepository, GetArticleVariantsRepository>();
            services.AddTransient<IRegCustomerPostManager, RegCustomerPostManager>();
            services.AddTransient<IRegCustomerPostRepository, RegCustomerPostRepository>();
            services.AddTransient<IGetNewArraivalsArticleManager, GetNewArraivalsArticleManager>();
            services.AddTransient<IGetNewArraivalsArticleRepository, GetNewArraivalsArticleRepository>();
            services.AddTransient<IGetAllBeastDealsArticleManager, GetAllBeastDealsArticleManager>();
            services.AddTransient<IGetAllBeastDealsArticleRepository, GetAllBeastDealsArticleRepository>();
            services.AddTransient<IGetAllKidsArticleManager, GetAllKidsArticleManager>();
            services.AddTransient<IGetAllKidsAricleRepository, GetAllKidsAricleRepository>();
            services.AddTransient<IGetAllMansArticleManager, GetAllMansArticleManager>();
            services.AddTransient<IGetAllMansArticleRepository, GetAllMansArticleRepository>();
            services.AddTransient<IGetAllWomensArticleManager, GetAllWomensArticleManager>();
            services.AddTransient<IGetAllWomensArticleRepository, GetAllWomensArticleRepository>();
            services.AddTransient<IGetCategorizedArticleManager, GetCategorizedArticleManager>();
            services.AddTransient<IGetCategorizedArticleRepository, GetCategorizedArticleRepository>();
            services.AddTransient<IOrderCustomerPostRepository, OrderCustomerPostRepository>();
            services.AddTransient<IOrderCustomerPostManager, OrderCustomerPostManager>();
            services.AddTransient<IOrderDetailsPostRepository, OrderDetailsPostRepository>();
            services.AddTransient<ICustomerInfoManager,CustomerInfoManager>();
            services.AddTransient<IGetAddToCartArticleRepository, GetAddToCartArticleRepository>();
            services.AddTransient<IGetAddToCartArticleManager, GetAddToCartArticleManager>();
            services.AddTransient<IRemoveAddToCartItemManager, RemoveAddToCartItemManager>();
            services.AddTransient<IOrderPostManager, OrderPostManager>();
            services.AddTransient<IPartialUpdateRepository, PartialUpdateRepository>();
            services.AddTransient<IPostShippingAddressRepository, PostShippingAddressRepository>();
            services.AddTransient<IPostBillingAddressRepository, PostBillingAddressRepository>();
            services.AddTransient<IPostCustomerAddressManager, PostCustomerAddressManager>();
            services.AddTransient<IGetDefaultBillingAddressRepository, GetDefaultBillingAddressRepository>();
            services.AddTransient<IGetDefaultBillingAddressManager, GetDefaultBillingAddressManager>();
            services.AddTransient<IGetDefaultShippingAddressRepository, GetDefaultShippingAddressRepository>();
            services.AddTransient<IGetDefaultShippingAddressManager, GetDefaultShippingAddressManager>();
            services.AddTransient<IGetShippingAddressListRepository, GetShippingAddressListRepository>();
            services.AddTransient<IGetShippingAddressListManager, GetShippingAddressListManager>();
            services.AddTransient<IGetBillingAddressListRepository, GetBillingAddressListRepository>();
            services.AddTransient<IGetBillingAddressListManager, GetBillingAddressListManager>();
            services.AddTransient<IGetArticleCatDiscountRepository, GetArticleCatDiscountRepository>();
            services.AddTransient<IGetSubCatDiscountArticleRepository, GetSubCatDiscountArticleRepository>();
            services.AddTransient<IGetArticleCatDiscountManager, GetArticleCatDiscountManager>();
            services.AddTransient<IGetSubCatDiscountArticleManager, GetSubCatDiscountArticleManager>();
            services.AddTransient<IGetSubSubCatDiscountArticleRepository, GetSubSubCatDiscountArticleRepository>();
            services.AddTransient<IGetSubSubCatDiscountArticleManager, GetSubSubCatDiscountArticleManager>();
            services.AddTransient<IGetSubSubSCatDiscountArticleRepository, GetSubSubSCatDiscountArticleRepository>();
            services.AddTransient<IGetSubSubSCatDiscountArticleManager, GetSubSubSCatDiscountArticleManager>();
            services.AddTransient<IDiscountDetailsSettingsRepository, DiscountDetailsSettingsRepository>();
            services.AddTransient<ISettingsDiscountTimeRepository, SettingsDiscountTimeRepository>();
            services.AddTransient<ISettingsDiscoutBannerRepository, SettingsDiscoutBannerRepository>();
            services.AddTransient<IDiscountSettingsManager, DiscountSettingsManager>();
            services.AddAuthentication("Basic")
                .AddScheme<BasicAuthenticationSchemeOptions, CustomauthenticationHandler>("Basic", null);
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

           /* var googleCredential = env.ContentRootPath;
            var filePath = Configuration.GetSection("https://fcm.googleapis.com/fcm/send")["fileName"];
            googleCredential = Path.Combine(googleCredential, filePath);
            var credential = GoogleCredential.FromFile(googleCredential);
            FirebaseApp.Create(new AppOptions()
            {

                Credential = credential
            });*/
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", " E-Commerece API v1");
            });
            app.UseRouting();
            app.UseStaticFiles();
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
