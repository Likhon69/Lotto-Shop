using Repository.Base;
using Repository.MobileContracts;
using ShopModels.MobileViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repository.MobileImplementation
{
    public class GetCategorizedArticleRepository : IGetCategorizedArticleRepository
    {
        public List<CategorizedGetArticleVM> GetCategorizedArticle(long id)
        {
            string connection = Constants.Connection;
            using (SqlConnection sqlConn = new SqlConnection(connection))
            {
                sqlConn.Open();
                List<CategorizedGetArticleVM> dt = new List<CategorizedGetArticleVM>();
                using (SqlCommand sqlComm = new SqlCommand("SP_GetAllCategorizedArticle", sqlConn))
                {
                    sqlComm.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlComm.Parameters.AddWithValue("@catId", id);
                    sqlComm.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader sdr = sqlComm.ExecuteReader())
                    {
                        
                        while (sdr.Read())
                        {
                            try
                            {
                                CategorizedGetArticleVM dtc = new CategorizedGetArticleVM();

                                dtc.ArtD_Id = (long)sdr["ArtD_Id"];
                                dtc.ArticleTitle = sdr["ArticleTitle"].ToString();
                                dtc.ArticleSubtitle = sdr["ArticleSubtitle"].ToString();
                                dtc.Description = sdr["Description"].ToString();
                                dtc.ArticleDetailsArtD_Id = (long)sdr["ArticleDetailsArtD_Id"];
                                dtc.StandardPrice = (decimal)sdr["StandardPrice"];
                                dtc.IsDiscount = (bool)sdr["IsDiscount"];
                                dtc.ImageName = sdr["ImageName"].ToString();
                                dtc.CategoryC_Id = (long)sdr["CategoryC_Id"];
                                dtc.SubCategoryS_Id = (long)sdr["SubCategoryS_Id"];
                                dtc.SubSubCategoryS_Id = (long)sdr["SubSubCategoryS_Id"];
                                dtc.SubSubSubCategoryS_Id = (long)sdr["SubSubSubCategoryS_Id"];
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
