using Repository.Base;
using Repository.MobileContracts;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repository.MobileImplementation
{
    public class GetArticleVariantsRepository : IGetArticleVariantsRepository
    {
        public List<ArticleVariantDto> GetArticlevariant(long id)
        {
            string connection = Constants.Connection;
            using (SqlConnection sqlConn = new SqlConnection(connection))
            {
                sqlConn.Open();
                List<ArticleVariantDto> dt = new List<ArticleVariantDto>();
                using (SqlCommand sqlComm = new SqlCommand("SP_ArticleVariant", sqlConn))
                {

                    sqlComm.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlComm.Parameters.AddWithValue("@artId", id);
                    using (SqlDataReader sdr = sqlComm.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            try
                            {
                                ArticleVariantDto dtc = new ArticleVariantDto();


                                dtc.ArtD_Id = (long)sdr["ArtD_Id"];
                                dtc.ArticleNo = sdr["ArticleNo"].ToString();
                                dtc.Color = sdr["Color"].ToString();
                                dtc.Size= (Int32)sdr["Size"];
                                dtc.Quantity = (Int32)sdr["Quantity"];

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
