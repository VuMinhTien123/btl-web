using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Controllers
{
    public class CategoryController : Controller
    {
        WebsiteBanHangEntities db = new WebsiteBanHangEntities();
        // GET: Category
        public ActionResult Index()
        {
            return PartialView(db.Products.ToList());
        }
        public ActionResult LayoutCategory()
        {
            return View();
        }
        public PartialViewResult RenderCategory()
        {
            return PartialView(db.Categories.OrderBy(n => n.Name).ToList());
        }
        // laptop theo Category
        public ViewResult LaptopTheoCategory (int CateId=0)
        {
            // Kiểm tra CateId có tồn tại hay không
            Category cd = db.Categories.SingleOrDefault(n => n.CateId == CateId);
            if(cd==null)
                {
                Response.StatusCode = 404;
                     return null;
                }
            //Truy xuất danh sách các laptop theo category
            List<Product> lstLaptop = db.Products.Where(n => n.CateId == CateId).OrderBy(n=>n.Price).ToList();
            if (lstLaptop.Count == 0)
            {
                ViewBag.Laptop = "Không có sản phẩm nào thuộc hàng Laptop này";
            }
            return View(lstLaptop);
        }
        //Hiển thị tất cả các sản phẩm Laptop
    }
}