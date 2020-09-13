using Repository.Base;
using Repository.Contracts;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repository.Implementation
{
    public class OrderCreateRepository : IOrderCreateRepository
    {
        public int PostOrderCreate(string combindedString,OrderCreateInfVm order)
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
                    using (SqlCommand sqlComm = new SqlCommand("USP_INS_CREATE_ORDER", sqlConn))
                    {


                        sqlComm.CommandType = System.Data.CommandType.StoredProcedure;

                      

                        sqlComm.Parameters.AddWithValue("@ArtCodeString", combindedString);
                        sqlComm.Parameters.AddWithValue("@CustomerID", order.CustomerId);
                        sqlComm.Parameters.AddWithValue("@ShipAddrID", order.ShipmentAddId);
                        sqlComm.Parameters.AddWithValue("@BillingAddrID", order.BillingAddId);
                    
                        sqlComm.Parameters.AddWithValue("@Remarks", "");
                        sqlComm.Parameters.AddWithValue("@PaymnetType", order.PaymentType);
                        sqlComm.Parameters.AddWithValue("@PaidAmt", order.PaidAmount);
                        



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
