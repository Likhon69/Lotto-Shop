using Repository.Base;
using Repository.Contracts;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repository.Implementation
{
    public class GetPracticeRepository : IGetPracticeRepository
    {
        public List<EmployeeVm> GetEmployeeDetails()
        {
            string connection = Constants.Connection;
            using (SqlConnection sqlConn = new SqlConnection(connection))
            {
                sqlConn.Open();
                List<EmployeeVm> dt = new List<EmployeeVm>();
                using (SqlCommand sqlComm = new SqlCommand("USP_LIST_PRACTICE", sqlConn))
                {

                    sqlComm.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlComm.Parameters.AddWithValue("@PRACTICE_ID", 1);
                    using (SqlDataReader sdr = sqlComm.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            try
                            {
                                EmployeeVm dtc = new EmployeeVm();

                                dtc.Id = (Int32)sdr["Id"];
                                dtc.Name = sdr["Name"].ToString();
                                dtc.Address = sdr["Address"].ToString();
                                dtc.Designation = (Int32)sdr["Designation"];
                                dtc.Salary = (decimal)sdr["Salary"];

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
