using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoanMonHoc.Models;
namespace DoanMonHoc.Controllers
{
    public class NguoidungController : Controller
    {
        // tạo đối tượng quản lý cơ sở dũ liệu
        ShopFaShionDataContext db = new ShopFaShionDataContext();
        // GET: Nguoidung
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        // GET: Nguoidung
        [HttpPost]
        public ActionResult DangKy(FormCollection collection, KhachHang kh )
        {
            //gan gia tri vao form
            var hoten = collection["HotenKH"];
            var tendn = collection["TenDN"];
            var matkhau = collection["MatKhau"];
            var matkhaunhaplai = collection["MatKhauNhapLai"];
            var email = collection["Email"];
            var diachi = collection["DiaChi"];
            var dienthoai = collection["DienThoai"];
            var ngaysinh = String.Format("(0:MM/dd/yyyy)", collection["NgaySinh"]);
            if (String.IsNullOrEmpty(hoten))
            {
                ViewData["Loi1"] = "Họ Tên khách hàng không được để trống";

            }

            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi2"] = "Tài Khoản khách hàng không được để trống";

            }
            if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi3"] = "Mật Khẩu khách hàng không được để trống";

            }
            if (String.IsNullOrEmpty(matkhaunhaplai))
            {
                ViewData["Loi4"] = "Mật Khẩu nhập lại  khách hàng không được để trống";

            }
            if (String.IsNullOrEmpty(email))
            {
                ViewData["Loi5"] = "Email khách hàng không được để trống";

            }
            if (String.IsNullOrEmpty(dienthoai))
            {
                ViewData["Loi6"] = "Điện Thoại khách hàng không được để trống";

            }
           else
            {
                //Gán Giá Trị Vào Database
                kh.HoTen = hoten;
                kh.TaiKhoan = tendn;
                kh.MatKhau = matkhau;
                kh.Email = email;
                kh.DiachiKH = diachi;
                kh.DienThoaiKH = dienthoai;
                kh.NgaySinh = DateTime.Parse(ngaysinh);
                db.KhachHangs.InsertOnSubmit(kh);
                db.SubmitChanges();
                return RedirectToAction("Dangnhap");
            }
            return this.DangKy();
        }

       
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
            var tendn = collection["TenDN"];
            var matkhau = collection["MatKhau"];
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
                KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.TaiKhoan == tendn && n.MatKhau == matkhau);
                if (kh !=null)
                {
                    ViewBag.ThongBao = "Ban da dang nhap thanh cong";
                    Session["TaiKhoan"] = kh;
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