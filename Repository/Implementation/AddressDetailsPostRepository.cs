using Repository.Base;
using Repository.Contracts;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repository.Implementation
{
    public class AddressDetailsPostRepository : IAddressDetailsPostRepository
    {
        public int PostAddressDetails(AddressDetailsVm model)
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
                    using (SqlCommand sqlComm = new SqlCommand("USP_INS_CUSTOMER_ADDRESS", sqlConn))
                    {


                        sqlComm.CommandType = System.Data.CommandType.StoredProcedure;



                        sqlComm.Parameters.AddWithValue("@ReceipientFirstName", model.ReceipientFirstName);
                        sqlComm.Parameters.AddWithValue("@ReceipientLastname ", model.ReceipientLastname);
                        sqlComm.Parameters.AddWithValue("@RecipientMobile", model.RecipientMobile);
                        sqlComm.Parameters.AddWithValue("@DistrictId ", model.DistrictId);

                        sqlComm.Parameters.AddWithValue("@DistAreaId ", model.DistAreaId);
                        sqlComm.Parameters.AddWithValue("@AddressDetails", model.AddressDetails);
                        sqlComm.Parameters.AddWithValue("@SpecialInstruction", model.SpecialInstruction);
                        sqlComm.Parameters.AddWithValue("@AddressLabel", model.AddressLabel);
                        sqlComm.Parameters.AddWithValue("@IsDefault", model.IsDefault);
                        sqlComm.Parameters.AddWithValue("@CustomerId", model.CustomerId);
                        sqlComm.Parameters.AddWithValue("@Created_by", model.Created_by);




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
