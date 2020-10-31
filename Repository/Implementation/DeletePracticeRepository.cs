using Repository.Base;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repository.Implementation
{
    public class DeletePracticeRepository : IDeletePracticeRepository
    {
        public int DeletePracticeMaster(int id)
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
                    using (SqlCommand sqlComm = new SqlCommand("SP_DELETE_PRACTICE", sqlConn))
                    {


                        sqlComm.CommandType = System.Data.CommandType.StoredProcedure;

                        // sqlComm.Parameters.AddWithValue("@Type", 0);
                        sqlComm.Parameters.AddWithValue("@PRACTICE_ID", id);
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
