using Repository.Base;
using Repository.MobileContracts;
using ShopModels.MobileViewModel;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repository.MobileImplementation
{
    public class GetArticleWiseImageRepository : IGetArticleWiseImageRepository
    {
        public List<ArticleImageMobileVM> GetArticleIamge(long id)
        {
            string connection = Constants.Connection;
            using (SqlConnection sqlConn = new SqlConnection(connection))
            {
                sqlConn.Open();
                List<ArticleImageMobileVM> dt = new List<ArticleImageMobileVM>();
                using (SqlCommand sqlComm = new SqlCommand("SP_ArticleImage", sqlConn))
                {

                    sqlComm.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlComm.Parameters.AddWithValue("@artId", id);
                    using (SqlDataReader sdr = sqlComm.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            try
                            {
                                ArticleImageMobileVM dtc = new ArticleImageMobileVM();

                              
                                dtc.Description = sdr["Description"].ToString();
                                dtc.ImageName = sdr["ImageName"].ToString();
                                
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
