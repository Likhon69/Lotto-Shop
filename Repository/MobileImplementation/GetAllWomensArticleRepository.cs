using Repository.Base;
using Repository.MobileContracts;
using ShopModels.MobileViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repository.MobileImplementation
{
    public class GetAllWomensArticleRepository : IGetAllWomensArticleRepository
    {
        public List<NewArraivalsVM> GetAllWomensArticle()
        {
            string connection = Constants.Connection;
            using (SqlConnection sqlConn = new SqlConnection(connection))
            {
                sqlConn.Open();
                List<NewArraivalsVM> dt = new List<NewArraivalsVM>();
                using (SqlCommand sqlComm = new SqlCommand("SP_WOMENSARTICLE", sqlConn))
                {

                    sqlComm.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader sdr = sqlComm.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            try
                            {
                                NewArraivalsVM dtc = new NewArraivalsVM();

                                dtc.ArtD_Id = (long)sdr["ArtD_Id"];
                                dtc.ArticleTitle = sdr["ArticleTitle"].ToString();
                                dtc.ArticleSubtitle = sdr["ArticleSubtitle"].ToString();
                                dtc.Description = sdr["Description"].ToString();
                                dtc.ArticleDetailsArtD_Id = (long)sdr["ArticleDetailsArtD_Id"];
                                dtc.StandardPrice = (decimal)sdr["StandardPrice"];
                                dtc.IsDiscount = (bool)sdr["IsDiscount"];
                                dtc.IsDelivery = (bool)sdr["IsDelivery"];
                                dtc.ImageName = sdr["ImageName"].ToString();
                                dtc.DiscountPercentage = (Int32)sdr["DiscountPercentage"];
                                dtc.Vat = (double)sdr["Vat"];
                                dtc.DiscountPrice = (decimal)sdr["DiscountPrice"];
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
