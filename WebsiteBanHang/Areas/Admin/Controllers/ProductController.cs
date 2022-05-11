using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();
        // GET: Admin/Product
        public ActionResult Index( string SearchString)
        {
            var lstProduct = objWebsiteBanHangEntities.Products.Where(n => n.Name.Contains(SearchString)).ToList();
            return View(lstProduct);
        }


        public ActionResult Details(int Id)
        {
            var objProduct = objWebsiteBanHangEntities.Products.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }

        [HttpGet] 
        public ActionResult Delete(int Id)
        {
            var objProduct = objWebsiteBanHangEntities.Products.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Delete(Product product)
        {
            var objProduct = objWebsiteBanHangEntities.Products.Where(n => n.Id == product.Id).FirstOrDefault();

            objWebsiteBanHangEntities.Products.Remove(objProduct);
            objWebsiteBanHangEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var objProduct = objWebsiteBanHangEntities.Products.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
                if (product.ImageUpLoad != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(product.ImageUpLoad.FileName);
                    string extension = Path.GetExtension(product.ImageUpLoad.FileName);
                    fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                    //product.Avartar = fileName;
                    product.ImageUpLoad.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                }
            objWebsiteBanHangEntities.Entry(product).State = EntityState.Modified;
            objWebsiteBanHangEntities.SaveChanges();
            return View(product);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                if(product.ImageUpLoad != null)//Kiểm tra đối tượng imageUpLoad có load được hay không
                {
                    string fileName = Path.GetFileNameWithoutExtension(product.ImageUpLoad.FileName);//Lấy tên hình ảnh lưu vào 
                    string extension = Path.GetExtension(product.ImageUpLoad.FileName);
                    fileName = fileName + "_" + long.Parse(DateTime.Now . ToString("yyyyMMddhhmmss")) + extension;
                   // product.Avartar = fileName;//Lấy tên hình ảnh gán vào biến avatar
                    product.ImageUpLoad.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                }
                objWebsiteBanHangEntities.Products.Add(product);
                objWebsiteBanHangEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                return RedirectToAction("Index");
            }
        }
    }
}