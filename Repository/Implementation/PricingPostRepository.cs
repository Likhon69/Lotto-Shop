using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Contracts;
using ShopModels.Models;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Repository.Implementation
{
    public class PricingPostRepository : BaseShopRepository<Pricing>, IPricingPostRepository
    {
        public PricingPostRepository(DbContext db) : base(db)
        {
            

        }

        public List<ArticleDetailsData> articleDetails()
        {
            
            string connection = Constants.Connection;
            using (SqlConnection sqlConn = new SqlConnection(connection))
            {
                sqlConn.Open();
                List<ArticleDetailsData> dt = new List<ArticleDetailsData>();
                using (SqlCommand sqlComm = new SqlCommand("ArticleDetailsProcedure", sqlConn))
                {
                   
                    sqlComm.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader sdr = sqlComm.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            try
                            {
                                ArticleDetailsData dtc = new ArticleDetailsData();

                                dtc.ArtD_Id = (int)sdr["ArtD_Id"];
                                dtc.Quantity = (int)sdr["Quantity"];
                                dtc.StandardPrice = (decimal)sdr["StandardPrice"];
                                dtc.Description = sdr["Description"].ToString();
                                dtc.DiscontPrice = (int)sdr["DiscontPrice"];
                                dtc.DiscountRate = (decimal)sdr["DiscountRate"];
                                dtc.ArticleTitle = sdr["ArticleTitle"].ToString();
                                dtc.ArticleSubTitle = sdr["ArticleSubTitle"].ToString();
                                dtc.ArticleMasterImage = sdr["ArticleMasterImage"].ToString();
                                dt.Add(dtc);

                            }
                            catch (Exception ex)
                            {

                                throw;
                            }

                        }
                        sdr.Close();
                    }


                       
                   
                }
                return dt;

            }
            
        }
    }
}
