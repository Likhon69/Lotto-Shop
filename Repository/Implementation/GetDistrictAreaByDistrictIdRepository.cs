using Repository.Contracts;
using ShopModels.ViewModel;
using System;
using Repository.Base;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Repository.Implementation
{
    public class GetDistrictAreaByDistrictIdRepository : IGetDistrictAreaByDistrictIdRepository
    {
        public List<DistrictAreaVm> GetDistrictAreaByDistrictId(int id)
        {
            string connection = Constants.Connection;
            using (SqlConnection sqlConn = new SqlConnection(connection))
            {
                sqlConn.Open();
                List<DistrictAreaVm> dt = new List<DistrictAreaVm>();
                using (SqlCommand sqlComm = new SqlCommand("USP_LIST_DISTRICT_AREA", sqlConn))
                {

                    sqlComm.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlComm.Parameters.AddWithValue("@DIST_ID", id);
                    using (SqlDataReader sdr = sqlComm.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            try
                            {
                                DistrictAreaVm dtc = new DistrictAreaVm();

                                dtc.DIST_ID = (Int16)sdr["DIST_ID"];
                                dtc.DIST_AREA_ID = (int)sdr["DIST_AREA_ID"];
                                dtc.DIST_AREA_NAME = sdr["DIST_AREA_NAME"].ToString();


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
