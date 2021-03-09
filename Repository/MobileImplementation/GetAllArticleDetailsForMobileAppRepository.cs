using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.MobileContracts;
using ShopModels.MobileViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repository.MobileImplementation
{
    public class GetAllArticleDetailsForMobileAppRepository :IGetAllArticleDetailsForMobileAppRepository
    {
        public List<ArticleDetailsVMForMobileHomePage> GetAllArticleDetailsForMobile()
        {
            string connection = Constants.Connection;
            using (SqlConnection sqlConn = new SqlConnection(connection))
            {
                sqlConn.Open();
                List<ArticleDetailsVMForMobileHomePage> dt = new List<ArticleDetailsVMForMobileHomePage>();
                using (SqlCommand sqlComm = new SqlCommand("SP_GetAllArticleDetailsForMobileHomepage", sqlConn))
                {

                    sqlComm.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader sdr = sqlComm.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            try
                            {
                                ArticleDetailsVMForMobileHomePage dtc = new ArticleDetailsVMForMobileHomePage();

                                dtc.ArtD_Id = (long)sdr["ArtD_Id"];
                                dtc.ArticleTitle = sdr["ArticleTitle"].ToString();
                                dtc.ArticleSubtitle = sdr["ArticleSubtitle"].ToString();
                                dtc.Description = sdr["Description"].ToString();
                                dtc.DiscountPercentage = (int)sdr["DiscountPercentage"];
                                dtc.StandardPrice = (decimal)sdr["StandardPrice"];
                                dtc.IsDiscount = (bool)sdr["IsDiscount"];
                                dtc.ImageName = sdr["ImageName"].ToString();
                                dtc.Vat = (double)sdr["Vat"];
                                dtc.DiscountPrice = (decimal)sdr["DiscountPrice"];
                                dtc.IsDelivery = (bool)sdr["IsDelivery"];
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
