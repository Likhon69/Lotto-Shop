using Repository.Contracts;
using ShopModels.ViewModel;
using Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Repository.Implementation
{
    public class GetDistrictMasterRepository : IGetDistrictMasterRepository
    {
        public List<DistrictMasterVm> GetAllDistrictMaster()
        {
            string connection = Constants.Connection;
            using (SqlConnection sqlConn = new SqlConnection(connection))
            {
                sqlConn.Open();
                List<DistrictMasterVm> dt = new List<DistrictMasterVm>();
                using (SqlCommand sqlComm = new SqlCommand("USP_LIST_DISTRICT", sqlConn))
                {

                    sqlComm.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader sdr = sqlComm.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            try
                            {
                                DistrictMasterVm dtc = new DistrictMasterVm();

                                dtc.DIST_ID= (Int16)sdr["DIST_ID"];
                                dtc.DIST_NAME = sdr["DIST_NAME"].ToString();
                               

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
