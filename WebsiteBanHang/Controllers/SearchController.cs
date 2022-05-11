using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;



namespace WebsiteBanHang.Controllers
{
    public class SearchController : Controller
    {
        WebsiteBanHangEntities db = new WebsiteBanHangEntities();
        [HttpPost]
        // GET: Search
        public ActionResult KetQuaTimKiem(FormCollection f)
        {
            string key = f["txtTimKiem"].ToString();
            List<Product> lstKQTK = db.Products.Where(n => n.Name.Contains(key)).ToList();
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào";
                return View(db.Products.OrderBy(n => n.Name).ToList());
            }
            ViewBag.ThongBao = "Đã tìm thấy" + lstKQTK + "kết quả";
            return View(lstKQTK.OrderBy(n=>n.Name).ToList());
        }
    }
}