using Repository.Base;
using Repository.MobileContracts;
using ShopModels.MobileViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repository.MobileImplementation
{
    public class GetBillingAddressListRepository : IGetBillingAddressListRepository
    {
        public List<DefaultAddressVM> GetBillingAddressList(long CustId)
        {

            string connection = Constants.Connection;
            using (SqlConnection sqlConn = new SqlConnection(connection))
            {
                sqlConn.Open();
                List<DefaultAddressVM> dt = new List<DefaultAddressVM>();
                using (SqlCommand sqlComm = new SqlCommand("SP_BillingAddress_List", sqlConn))
                {

                    sqlComm.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlComm.Parameters.AddWithValue("@custId", CustId);
                    sqlComm.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader sdr = sqlComm.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            try
                            {
                                DefaultAddressVM dtc = new DefaultAddressVM();

                                dtc.CustomerId = (long)sdr["CustomerId"];
                                dtc.RegionId = (long)sdr["RegionId"];
                                dtc.CityId = (long)sdr["CityId"];
                                dtc.AreaId = (long)sdr["AreaId"];
                                dtc.BillingAdd_Id = (long)sdr["BillingAdd_Id"];
                                dtc.Address = sdr["Address"].ToString();
                                dtc.CustName = sdr["CustName"].ToString();
                                dtc.CustPhone = sdr["CustPhone"].ToString();
                                dtc.RegionName = sdr["RegionName"].ToString();
                                dtc.CityName = sdr["CityName"].ToString();
                                dtc.AreaName = sdr["AreaName"].ToString();
                                dtc.IsDeafultAddress = (bool)sdr["IsDeafultAddress"];
                                dtc.IsHome = (bool)sdr["IsHome"];
                                dtc.IsOffice = (bool)sdr["IsOffice"];
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
