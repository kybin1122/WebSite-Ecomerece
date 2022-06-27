using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoanMonHoc.Models;

namespace DoanMonHoc.Controllers
{
    public class ShopFashionController : Controller
    {

        // tạo đối tượng quản lý cơ sở dũ liệu
        ShopFaShionDataContext data = new ShopFaShionDataContext();
        private List<SanPham> Laysanpham(int count)
        {

            return data.SanPhams.OrderByDescending(a => a.NgayCapNhat).Take(count).ToList();
        }


        // GET: ShopFashion
        public ActionResult Index()
        {
            var SanPhammoi = Laysanpham(6);
            return View(SanPhammoi);
        }
        public ActionResult LoaiSP()
        {
            var LoaiSP = from cd in data.LoaiSPs select cd;
            return PartialView(LoaiSP);
        }
        public ActionResult NhaSanXuat()
        {
            var NhaSanXuat = from cd in data.NhaSanXuats select cd;
            return PartialView(NhaSanXuat);
        }
    }
}