using Repository.Base;
using Repository.Contracts;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repository.Implementation
{
    public class AddPracticePostRepository: IAddPracticePostRepository
    {
        public int PostPracticeMaster(EmployeeVm employeeVm)
        {
           
            try
            {
                if (employeeVm.Id==0)
                {
                    string connection = Constants.Connection;
                    int i = 0;
                    using (SqlConnection sqlConn = new SqlConnection(connection))
                    {

                        if (sqlConn.State == 0)
                        {
                            sqlConn.Open();
                        }
                        using (SqlCommand sqlComm = new SqlCommand("SP_PRACTICE", sqlConn))
                        {


                            sqlComm.CommandType = System.Data.CommandType.StoredProcedure;

                            // sqlComm.Parameters.AddWithValue("@Type", 0);
                            sqlComm.Parameters.AddWithValue("@practiceId", employeeVm.Id);
                            sqlComm.Parameters.AddWithValue("@name", employeeVm.Name);
                            sqlComm.Parameters.AddWithValue("@address", employeeVm.Address);
                            sqlComm.Parameters.AddWithValue("@designation", employeeVm.Designation);
                            sqlComm.Parameters.AddWithValue("@salary", employeeVm.Salary);
                            sqlComm.Parameters.AddWithValue("@sT", 1);

                            i = sqlComm.ExecuteNonQuery();


                            sqlConn.Close();
                            return i;


                        }


                    }


                }
                else
                {
                    string connection = Constants.Connection;
                    int i = 0;
                    using (SqlConnection sqlConn = new SqlConnection(connection))
                    {

                        if (sqlConn.State == 0)
                        {
                            sqlConn.Open();
                        }
                        using (SqlCommand sqlComm = new SqlCommand("SP_PRACTICE", sqlConn))
                        {


                            sqlComm.CommandType = System.Data.CommandType.StoredProcedure;

                            // sqlComm.Parameters.AddWithValue("@Type", 0);
                            sqlComm.Parameters.AddWithValue("@practiceId", employeeVm.Id);
                            sqlComm.Parameters.AddWithValue("@name", employeeVm.Name);
                            sqlComm.Parameters.AddWithValue("@address", employeeVm.Address);
                            sqlComm.Parameters.AddWithValue("@designation", employeeVm.Designation);
                            sqlComm.Parameters.AddWithValue("@salary", employeeVm.Salary);
                            sqlComm.Parameters.AddWithValue("@sT", 2);

                            i = sqlComm.ExecuteNonQuery();


                            sqlConn.Close();
                            return i;


                        }


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
