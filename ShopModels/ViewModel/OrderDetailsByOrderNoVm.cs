using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.ViewModel
{
    public class OrderDetailsByOrderNoVm
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
        public string IMAGE_NAME { get; set; }
        public string ARTICLE { get; set; }
        public string SIZE { get; set; }
        public int Quantity { get; set; }
        public decimal Gross_Amount { get; set; }
        //public decimal Discount_Amount { get; set; }
        public decimal Net_Amount { get; set; }
        public decimal Courier_Charge { get; set; }
        public int Total_Quantity { get; set; }
        public decimal Total_payable_Amount { get; set; }
        public decimal Paid_Amount { get; set; }
        public decimal Balance_Amount { get; set; }
        public decimal Vat_Amount { get; set; }
        public decimal Invocie_Gross_Amount { get; set; }
        //public decimal Invocie_Disc_Amount { get; set; }
        public decimal Invoice_Net_Amount { get; set; }
    }
}
