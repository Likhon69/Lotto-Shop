using Repository.Base;
using Repository.Contracts;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repository.Implementation
{
    public class OrderPickerRepository : IOrderPickerRepository
    {
        public List<OrderPickerVm> GetOrderPickerByOrderNo(string orderNo)
        {
            string connection = Constants.Connection;
            using (SqlConnection sqlConn = new SqlConnection(connection))
            {
                sqlConn.Open();
                List<OrderPickerVm> dt = new List<OrderPickerVm>();
                using (SqlCommand sqlComm = new SqlCommand("USP_LIST_ORDER_SUMMARY", sqlConn))
                {

                    sqlComm.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlComm.Parameters.AddWithValue("@OrderNo", orderNo);

                    using (SqlDataReader sdr = sqlComm.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            try
                            {
                                OrderPickerVm dtc = new OrderPickerVm();

                                dtc.Order_No = sdr["Order_No"].ToString();
                                dtc.Ref_ID = sdr["Ref_ID"].ToString();
                                dtc.Customer_ID = (long)sdr["Customer_ID"];
                                dtc.Order_Date = (DateTime)sdr["Order_Date"];
                                dtc.ValidTo_Date = (DateTime)sdr["ValidTo_Date"];
                                dtc.Shipment_To = sdr["Shipment_To"].ToString();
                                dtc.Shipment_Mobile_No = sdr["Shipment_Mobile_No"].ToString();
                                dtc.Shipment_Address = sdr["Shipment_Address"].ToString();
                                dtc.Shipment_Area = sdr["Shipment_Area"].ToString();
                                dtc.Shipment_District = sdr["Shipment_District"].ToString();
                                dtc.Billing_To = sdr["Billing_To"].ToString();
                                dtc.Billing_Mobile_No = sdr["Billing_Mobile_No"].ToString();
                                dtc.Billing_Address = sdr["Billing_Address"].ToString();
                                dtc.Billing_Area = sdr["Billing_Area"].ToString();
                                dtc.Billing_District = sdr["Billing_District"].ToString();
                                dtc.Total_Quantity = (int)sdr["Total_Quantity"];
                                dtc.Gross_Amount = (decimal)sdr["Gross_Amount"];
                                dtc.Discount_Amount = (decimal)sdr["Discount_Amount"];
                                dtc.Net_Amount = (decimal)sdr["Net_Amount"];
                                dtc.Courier_Charge = (decimal)sdr["Courier_Charge"];
                                dtc.Payment_Through = sdr["Payment_Through"].ToString();
                                dtc.Balance_Amount = (decimal)sdr["Balance_Amount"];

                                dtc.Total_payable_Amount = (decimal)sdr["Total_payable_Amount"];
                                dtc.Paid_Amount = (decimal)sdr["Paid_Amount"];


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
