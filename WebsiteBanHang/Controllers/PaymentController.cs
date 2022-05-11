using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;
using WebsiteBanHang.Models;

namespace WebsiteBanHang.Controllers
{
    public class PaymentController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();
        // GET: Payment
        public ActionResult Index()
        {
            if (Session["idUser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                //Lấy thông tin giỏi hàng từ biến session
                var lstCart = (List<CartModel>)Session["cart"];
                //Gán dữ liệu cho Model
                Order objOrder = new Order();
                objOrder.Name = "DonHang-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                objOrder.UserId = int.Parse(Session["idUser"].ToString());
                objOrder.CreatedOnUtc = DateTime.Now;
                objOrder.Status = 1;
                objWebsiteBanHangEntities.Orders.Add(objOrder);
                //Lưu thông tin dữ liệu vào bảng Order
                objWebsiteBanHangEntities.SaveChanges();

                //lây OrderID vừa mới tạo để lưu vào bảng OrderDetail
                int intOrderID = objOrder.OrderId;

                List<OrderDetail> lstOrderDetail = new List<OrderDetail>();

                foreach(var item in lstCart)
                {
                    OrderDetail obj = new OrderDetail();
                    obj.Quantity = item.Quantity;
                    obj.OrderId = intOrderID;
                    obj.ProductId = item.Product.Id;
                    lstOrderDetail.Add(obj);
                }
                //objWebsiteBanHangEntities.OrderDetails.AddRange(lstOrderDetail);
                objWebsiteBanHangEntities.SaveChanges();
            }
            return View();
        }
    }
}