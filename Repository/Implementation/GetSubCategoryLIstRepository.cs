using Repository.Base;
using Repository.Contracts;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repository.Implementation
{
    public class GetSubCategoryLIstRepository : IGetSubCategoryLIstRepository
    {
        public List<SubCategoryListVm> GetAllSubCategoryList(int id)
        {
            string connection = Constants.Connection;
            using (SqlConnection sqlConn = new SqlConnection(connection))
            {
                sqlConn.Open();
                List<SubCategoryListVm> dt = new List<SubCategoryListVm>();
                using (SqlCommand sqlComm = new SqlCommand("USP_LIST_CATEGORY", sqlConn))
                {

                    sqlComm.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlComm.Parameters.AddWithValue("@CAT_TYPE_ID", id);
                    using (SqlDataReader sdr = sqlComm.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            try
                            {
                                SubCategoryListVm dtc = new SubCategoryListVm();

                                dtc.CAT_ID = (Int32)sdr["CAT_ID"];
                                dtc.CAT_DESC = sdr["CAT_DESC"].ToString();
                                dtc.CAT_IMG = sdr["CAT_IMG"].ToString();


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
