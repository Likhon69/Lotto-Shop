using Repository.Contracts;
using ShopModels.ViewModel;
using System;
using Repository.Base;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Repository.Implementation
{
    public class GetCourierCompnayListRepository : IGetCourierCompnayListRepository
    {
        public List<CourierDetailsVm> GetCourierDetailsList()
        {
            string connection = Constants.Connection;
            using (SqlConnection sqlConn = new SqlConnection(connection))
            {
                sqlConn.Open();
                List<CourierDetailsVm> dt = new List<CourierDetailsVm>();
                using (SqlCommand sqlComm = new SqlCommand("USP_LIST_COURIER_COMPANY", sqlConn))
                {

                    sqlComm.CommandType = System.Data.CommandType.StoredProcedure;
                  
                    using (SqlDataReader sdr = sqlComm.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            try
                            {
                                CourierDetailsVm dtc = new CourierDetailsVm();

                                dtc.company_Id = (int)sdr["company_Id"];
                                dtc.companyName = sdr["companyName"].ToString();
                              


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
