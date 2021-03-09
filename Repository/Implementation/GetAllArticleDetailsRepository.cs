using Repository.Contracts;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using Repository.Base;
using System.Data.SqlClient;

namespace Repository.Implementation
{
    public class GetAllArticleDetailsRepository : IGetAllArticleRepository
    {
        public List<EArticleDetailsVm> GetEArticleDetails()
        {
            string connection = Constants.Connection;
            using (SqlConnection sqlConn = new SqlConnection(connection))
            {
                sqlConn.Open();
                List<EArticleDetailsVm> dt = new List<EArticleDetailsVm>();
                using (SqlCommand sqlComm = new SqlCommand("USP_LIST_ARTICLES", sqlConn))
                {

                    sqlComm.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader sdr = sqlComm.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            try
                            {
                                EArticleDetailsVm dtc = new EArticleDetailsVm();

                                dtc.ArticleName = sdr["NAME"].ToString();
                                dtc.ArticleNo = sdr["ARTICLE"].ToString();
                                dtc.Art_Code = (long)sdr["ART_CODE"];
                                dtc.ArticlePrice = (decimal)sdr["MRP"];

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
