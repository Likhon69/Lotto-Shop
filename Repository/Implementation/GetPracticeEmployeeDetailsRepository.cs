using Repository.Base;
using Repository.Contracts;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repository.Implementation
{
    public class GetPracticeEmployeeDetailsRepository : IGetPracticeEmployeeDetailsRepository
    {
        public List<PracticeEmployeeVm> GetEmployeePracticeDetails(int id)
        {
            string connection = Constants.Connection;
            using (SqlConnection sqlConn = new SqlConnection(connection))
            {
                sqlConn.Open();
                List<PracticeEmployeeVm> dt = new List<PracticeEmployeeVm>();
                using (SqlCommand sqlComm = new SqlCommand("USP_LIST_PRACTICE_EMPLOYEE_VIEW", sqlConn))
                {

                    sqlComm.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlComm.Parameters.AddWithValue("@PRACTICE_ID", id);
                    using (SqlDataReader sdr = sqlComm.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            try
                            {
                                PracticeEmployeeVm dtc = new PracticeEmployeeVm();

                                dtc.ID = (Int32)sdr["ID"];
                                dtc.NAME = sdr["NAME"].ToString();
                                dtc.ADDRESS = sdr["ADDRESS"].ToString();
                                dtc.DESIGNATION = (Int32)sdr["DESIGNATION"];
                                dtc.DESIGNATION_NAME = sdr["DESIGNATION_NAME"].ToString();
                                dtc.SALARY = (decimal)sdr["SALARY"];
                                dtc.NATIONALITY = sdr["NATIONALITY"].ToString();
                                dtc.MOTTHER_NAME = sdr["MOTTHER_NAME"].ToString();
                                dtc.FATHER_NAME = sdr["FATHER_NAME"].ToString();
                                dtc.JOB_LOCATION = sdr["JOB_LOCATION"].ToString();

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
