using Repository.Base;
using Repository.MobileContracts;
using ShopModels.MobileViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repository.MobileImplementation
{
    public class GetAddToCartArticleRepository : IGetAddToCartArticleRepository
    {
        public List<AddToCartGetVM> GetAddToCartArticle(long CustId)
        {
            string connection = Constants.Connection;
            using (SqlConnection sqlConn = new SqlConnection(connection))
            {
                sqlConn.Open();
                List<AddToCartGetVM> dt = new List<AddToCartGetVM>();
                using (SqlCommand sqlComm = new SqlCommand("SP_GET_ADDTOCART_ARTICLE", sqlConn))
                {

                    sqlComm.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlComm.Parameters.AddWithValue("@customerId", CustId);
                    sqlComm.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader sdr = sqlComm.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            try
                            {
                                AddToCartGetVM dtc = new AddToCartGetVM();

                                dtc.CustomerId = (long)sdr["CustomerId"];
                                dtc.ArticleId = (long)sdr["ArticleId"];
                                dtc.ArticleTitle = sdr["ArticleTitle"].ToString();
                                dtc.ArticleSubtitle = sdr["ArticleSubtitle"].ToString();
                                dtc.ArticleNo = sdr["ArticleNo"].ToString();
                                dtc.Discount = (double)sdr["Discount"];
                                dtc.Price = (double)sdr["Price"];
                                dtc.Quantity = (Int32)sdr["Quantity"];
                                dtc.ImageName = sdr["ImageName"].ToString();
                                dtc.VatRate = (double)sdr["Vat_Rat"];
                                dtc.IsDelivery = (bool)sdr["IsDelivery"];
                                dtc.Size = (Int32)sdr["Size"];
                                dtc.Color = sdr["Color"].ToString();
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
