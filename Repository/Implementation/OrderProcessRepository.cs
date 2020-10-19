using Repository.Base;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repository.Implementation
{
    public class OrderProcessRepository : IOrderProcessRepository
    {
        public int OrderProcess(string orderNo, string created_By)
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
                    using (SqlCommand sqlComm = new SqlCommand("USP_INS_SALES_ORDER_ERP", sqlConn))
                    {


                        sqlComm.CommandType = System.Data.CommandType.StoredProcedure;

                        sqlComm.Parameters.AddWithValue("@OrdNo", orderNo);
                        sqlComm.Parameters.AddWithValue("@CreatedBy", created_By);
                      


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
