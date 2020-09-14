using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.ViewModel
{
    public class OrderHeaderVm
    {
        public string Order_No { get; set; }
        public string Ref_ID { get; set; }
        public long Customer_ID { get; set; }
        public string Shipment_To { get; set; }
        public string Shipment_Mobile_No { get; set; }
        public string Shipment_Address { get; set; }
        public string Shipment_Area { get; set; }
        public string Shipment_District { get; set; }
        public string Billing_To { get; set; }
        public string Billing_Mobile_No { get; set; }
        public string Billing_Address { get; set; }
        public string Billing_Area { get; set; }
        public string Billing_District { get; set; }
        public DateTime Order_Date { get; set; }
        public DateTime ValidTo_Date { get; set; }
        public int Total_Quantity { get; set; }
        public decimal Gross_Amount { get; set; }
        public decimal Discount_Amount { get; set; }
        public decimal Net_Amount { get; set; }
        public decimal Courier_Charge { get; set; }
        public string Payment_Through { get; set; }
        public decimal Total_payable_Amount { get; set; }
        public decimal Paid_Amount { get; set; }
        public decimal Balance_Amount { get; set; }


    }
}
