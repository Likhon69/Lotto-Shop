using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ECommerceDbContext;
using FirebaseAdmin.Messaging;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.MobileContracts;
using ShopModels.MobileViewModel;

namespace E_CommerceApp.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class MobilePostController : ControllerBase
    {
        private readonly IRegCustomerPostManager _regCustomerPost;
        private readonly IOrderCustomerPostManager _orderCustomerPost;
        private readonly ICustomerInfoManager _customerInfo;
        private readonly IRemoveAddToCartItemManager _removeAddToCartItem;
        private readonly IOrderPostManager _orderPost;
        private readonly ECommerceDatabaseContext _db;
        private readonly IPostCustomerAddressManager _postCustomerAddress;
        public MobilePostController(IRegCustomerPostManager regCustomerPost,
        IOrderCustomerPostManager orderCustomerPost,
        ICustomerInfoManager customerInfo,
        IRemoveAddToCartItemManager removeAddToCartItem,
        IOrderPostManager orderPost,
        ECommerceDatabaseContext db,
        IPostCustomerAddressManager postCustomerAddress
        )
        {
            _regCustomerPost = regCustomerPost;
            _orderCustomerPost = orderCustomerPost;
            _customerInfo = customerInfo;
            _removeAddToCartItem = removeAddToCartItem;
            _orderPost = orderPost;
            _db = db;
            _postCustomerAddress = postCustomerAddress;
        }

        [HttpPost]
        public IActionResult PostRegCustomer(RegCustomerVm model)
        {

            var res = _regCustomerPost.PostregCustomer(model);
            if (res == "success")
            {
                return Ok(new {status= "success",code="1",message="User Created",CustomerId = _customerInfo .CustomerInfoId(model.MobileNo)});
            }
            else
            {
                return BadRequest(new { status = "failed", code = "0", message = "Error message that you want to show to the user" });
            }
            
        }

        [HttpPost]
        public IActionResult PostOrderAddToCart(OrderVM order)
        {
            var id = order.CustomerId;
            List<long> artList = new List<long>();
            Guid orderHeaderPId = _db.OrderHeaders.Where(c => c.CustomerId == id && c.PartialApproved == "Y").Select(c => c.OrderHeaderId).FirstOrDefault();
            if (orderHeaderPId != Guid.Empty)
            {
                var artilIdList = _db.OrderDetails.Where(c => c.OrderHeaderId == orderHeaderPId && c.Approved=="N").ToList();
                foreach(var list in artilIdList)
                {
                    artList.Add(list.ArticleId);
                }

            }
            var res = _orderCustomerPost.OrderPost(order, artList);
            if(res == "Data saved Succesfully!" || res == "Data Updated Succesfully!")
            {
                return Ok(new { status="200",Message="Added To Cart" });
            }
            else
            {
                return BadRequest(new { status = "500", Message = "Sorry Service Unavailable" });
            }
            
        }

        [HttpPost]
        public IActionResult RemoveAddToCartItem(RemoveAddToCartVM cartItem)
        {
            var res = _removeAddToCartItem.RemoveAddToCartItem(cartItem);
            if(res == "Success")
            {
                return Ok(new { Status = "200", Massage = "Remove item from Cart!" });
            }
            else
            {
                return BadRequest(new { Status = "500", Massage = "Error!" });
            }
        }
        [HttpPost]
        public IActionResult OrderPost(List<OrderArticleVM> articleList,long ShipingId,long BillingId, double TotalAmount)
        {
            var id = articleList[0].CustomerId;
            Guid OrderHeaderId = _db.OrderHeaders.Where(c => c.CustomerId == id && c.Approved == "N").Select(c => c.OrderHeaderId).FirstOrDefault();
            int cnt = _db.OrderDetails.Where(c => c.OrderHeaderId == OrderHeaderId && c.Approved == "N").Count();
            var res = _orderPost.OrderFinalPost(articleList,cnt, ShipingId, BillingId, TotalAmount);
            if(res == "Success")
            {
                return Ok(new {Status="200",Massage="Order Confirmed!"});
            }
            else
            {
                return BadRequest(new { Status = "500", Massage = "Order Pending!" });
            }
            
        }

        [HttpPost]
        public IActionResult PostCustomerShippingAndBillingAddress(DeliveryAddressVM address)
        {
            var res = _postCustomerAddress.PostDeliveryAddress(address);
            if (res == "Success")
            {
                return Ok(new { Status = "200", Massage = "Saved Succesfulley!" });
            }
            else
            {
                return BadRequest(new { Status = "500", Massage = "Sorry Address not  Saved!" });
            }
        }
        [HttpPost]
       public IActionResult Notification(string tle,string message)
        {
            try
            {
                var applicationID = "AAAAh8LbVi4:APA91bGyLdbywY0TqBw-wy1UycOjB0TZm3LYj3w4n64CyjO_0m8-9LKazdmydOh84P7Mq90UHtpj4d814Cm1iqBZte4-zmuX7_R74YX49RpEZSGiJJyH6DWUpEFZN_oMlfD9dOXa74VR";

                //var senderId = "57-------55";

                string deviceId = "/topics/offers_on_going";

                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");

                tRequest.Method = "post";

                tRequest.ContentType = "application/json";

                var data = new

                {

                    to = deviceId,

                    notification = new

                    {

                        body = message,

                        title =tle,

                      

                    }
                };

                var Data = JsonConvert.SerializeObject(data);

                Byte[] byteArray = Encoding.UTF8.GetBytes(Data);

                tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));

                //tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));


                tRequest.ContentLength = byteArray.Length;
                using (Stream dataStream = tRequest.GetRequestStream())
                {

                    dataStream.Write(byteArray, 0, byteArray.Length);



                    using (WebResponse tResponse = tRequest.GetResponse())
                    {

                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {

                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {

                                String sResponseFromServer = tReader.ReadToEnd();

                                string str = sResponseFromServer;

                            }
                        }
                    }
                }
                return Ok("Success");
            }

            catch (Exception ex)
            {

                string str = ex.Message;
                return BadRequest(str);

            }

        }
    }
    
}
