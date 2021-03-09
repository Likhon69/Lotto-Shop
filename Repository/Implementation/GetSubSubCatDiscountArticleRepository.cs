using Repository.Base;
using Repository.Contracts;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repository.Implementation
{
    public class GetSubSubCatDiscountArticleRepository : IGetSubSubCatDiscountArticleRepository
    {
        public List<DiscountCatArticleVM> GetForSubSubCatDiscountArticle(long id)
        {
            string connection = Constants.Connection;
            using (SqlConnection sqlConn = new SqlConnection(connection))
            {
                sqlConn.Open();
                List<DiscountCatArticleVM> dt = new List<DiscountCatArticleVM>();
                using (SqlCommand sqlComm = new SqlCommand("SP_ForGetSubSubCatDiscountArticle", sqlConn))
                {

                    sqlComm.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlComm.Parameters.AddWithValue("@catId", id);
                    using (SqlDataReader sdr = sqlComm.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            try
                            {
                                DiscountCatArticleVM dtc = new DiscountCatArticleVM();
                                dtc.ArticleTitle = sdr["ArticleTitle"].ToString();
                                dtc.ArtD_Id = (long)sdr["ArtD_Id"];
                                dtc.BrandName = sdr["BrandName"].ToString();
                                dtc.StandardPrice = (decimal)sdr["StandardPrice"];
                                dt.Add(dtc);

                            }
                            catch (Exception ex)
                            {

                                throw ex;
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
