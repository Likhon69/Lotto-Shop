using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Contracts;
using ShopModels.Models;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repository.Implementation
{
    public class CourierMasterPostRepository : ICourierMasterPostRepository
    {
        public int PostCourierMaster(CourierDetailsVm model1, ContactPersonVm model2)
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
                    using (SqlCommand sqlComm = new SqlCommand("USP_INS_COURIER_CONTACT", sqlConn))
                    {
                        

                        sqlComm.CommandType = System.Data.CommandType.StoredProcedure;

                        sqlComm.Parameters.AddWithValue("@Type", 0);
                        sqlComm.Parameters.AddWithValue("@CompanyName", model1.companyName);
                        sqlComm.Parameters.AddWithValue("@ContactPerson", model1.contactPerson);
                        sqlComm.Parameters.AddWithValue("@Email", model1.email);
                        sqlComm.Parameters.AddWithValue("@Website", model1.website);
                        sqlComm.Parameters.AddWithValue("@Phone", model1.phone);
                        sqlComm.Parameters.AddWithValue("@Remarks", model1.Remarks);
                        sqlComm.Parameters.AddWithValue("@Status", model1.status);
                        sqlComm.Parameters.AddWithValue("@Created_by", model1.createdBy);
                        sqlComm.Parameters.AddWithValue("@PersonName",model2.personName);
                        sqlComm.Parameters.AddWithValue("@Phone1", model2.phone1);
                        sqlComm.Parameters.AddWithValue("@Phone2", model2.phone2);
                        sqlComm.Parameters.AddWithValue("@Stat", model2.status);
                        sqlComm.Parameters.AddWithValue("@CourierName", model1.companyName);
                        sqlComm.Parameters.AddWithValue("@CreatedBy", model2.created_By);


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
