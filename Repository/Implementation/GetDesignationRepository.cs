using Repository.Base;
using Repository.Contracts;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repository.Implementation
{
    public class GetEmployeeDetails : IGetDesignationRepository
    {
        public List<DesignationListVm> GetAllDesignationList()
        {
            string connection = Constants.Connection;
            using (SqlConnection sqlConn = new SqlConnection(connection))
            {
                sqlConn.Open();
                List<DesignationListVm> dt = new List<DesignationListVm>();
                using (SqlCommand sqlComm = new SqlCommand("USP_LIST_DESIGNATION", sqlConn))
                {

                    sqlComm.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlComm.Parameters.AddWithValue("@DESIGNATION_ID", 1);
                    using (SqlDataReader sdr = sqlComm.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            try
                            {
                                DesignationListVm dtc = new DesignationListVm();

                                dtc.ID = (Int32)sdr["ID"];
                                dtc.NAME = sdr["NAME"].ToString();
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

