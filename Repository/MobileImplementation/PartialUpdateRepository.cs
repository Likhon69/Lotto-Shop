using Repository.Base;
using Repository.MobileContracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repository.MobileImplementation
{
    public class PartialUpdateRepository : IPartialUpdateRepository
    {
        public string Partialupdate(Guid partialId, Guid uupdateId)
        {
              string connection = Constants.Connection;
            using (SqlConnection sqlConn = new SqlConnection(connection))
            {
                sqlConn.Open();
                
                using (SqlCommand sqlComm = new SqlCommand("SP_PartialOrderUpdate", sqlConn))
                {

                    sqlComm.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlComm.Parameters.AddWithValue("@PartialId", partialId);
                    sqlComm.Parameters.AddWithValue("@updateId", uupdateId);
                    using (SqlDataReader sdr = sqlComm.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            try
                            {
                              

                            }
                            catch (Exception ex)
                            {

                                throw ex;
                            }

                        }
                        sdr.Close();
                    }




                }
                return "Success";

            }
        }
    }
}
