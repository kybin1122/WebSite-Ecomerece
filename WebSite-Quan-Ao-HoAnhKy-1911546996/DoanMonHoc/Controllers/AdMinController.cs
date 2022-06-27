using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoanMonHoc.Models;
namespace DoanMonHoc.Controllers
{
    public class AdMinController : Controller
    {

        // tạo đối tượng quản lý cơ sở dũ liệu
        ShopFaShionDataContext db = new ShopFaShionDataContext();
        // GET: AdMin
        public ActionResult Index()
        {
            return View();
        }
        // GET: AdMin
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(FormCollection collection)
        {
            var tendn = collection["username"];
            var matkhau = collection["Password"];
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Ten Dang Nhap Khong De Trong";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {

                ViewData["Loi2"] = "Mat Khau Khong De Trong";
            }
            else
            {
                //gán giá trị và lấy session
                Admin admin= db.Admins.SingleOrDefault(n => n.UserAdmin == tendn && n.PassAdmin == matkhau);
                if (admin != null)
                {
                    ViewBag.ThongBao = "Ban da dang nhap thanh cong";
                    Session["TaiKhoan"] = admin;
                    return RedirectToAction("index", "Admin");
                }
                else
                {
                    ViewBag.ThongBao = "Ten Dang Nhap Hoac Mat Khau Khong Dung";
                }
            }
            return View();
        }
    }
}