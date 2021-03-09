using Repository.Base;
using Repository.Contracts;
using ShopModels.ViewModel;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repository.Implementation
{
    public class OrderDetailsTempRepository : IOrderDetailsTempRepository
    {
        public int PostOrderDetailsTmp(OrderDetailsTmpVm model)
        {
            try
            {
                string connection = Constants.Connection;
                int i = 0;
                using (SqlConnection sqlConn = new SqlConnection(connection))
                {

                    if (sqlConn.State == 0)
                    {
                        sqlConn.Open();
                    }
                    using (SqlCommand sqlComm = new SqlCommand("USP_INS_SALES_ORDER_TMP", sqlConn))
                    {


                        sqlComm.CommandType = System.Data.CommandType.StoredProcedure;


                        sqlComm.Parameters.AddWithValue("@Article", model.Article);
                        sqlComm.Parameters.AddWithValue("@Size", model.Size);
                        sqlComm.Parameters.AddWithValue("@Qty", model.Qty);
                        sqlComm.Parameters.AddWithValue("@DiscPrcnt", model.DiscPrcnt);
                        sqlComm.Parameters.AddWithValue("@Created_By", model.Created_By);
                        sqlComm.Parameters.AddWithValue("@CustomerID", model.CustomerID);



                        i = sqlComm.ExecuteNonQuery();


                        sqlConn.Close();
                        return i;


                    }



                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
