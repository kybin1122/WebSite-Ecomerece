using DoanMonHoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Documents;

namespace DoanMonHoc.Controllers
{
    public class GioHangController : Controller
    {
        // tạo đối tượng quản lý cơ sở dũ liệu
        ShopFaShionDataContext data = new ShopFaShionDataContext();
        // GET: GioHang
    
        public List<GioHang> LayGioHang()
        {

            List<GioHang> lstGiohang = Session["Giohang"] as List<GioHang>;
            if (lstGiohang == null)
            {
                lstGiohang = new List<GioHang>();
                Session["Giohang"] = lstGiohang;
            }
            return lstGiohang;
        }
        public ActionResult ThemGioHang(int iMaSP, string strURL)
        {
            List<GioHang> lstGiohang = Session["Giohang"] as List<GioHang>;
            //Kiểm tra sản phẩm đã cho vào giỏ hàng chưa
            GioHang sanpham = lstGiohang.Find(n => n.iMaSP == iMaSP);
            if (sanpham == null)
            {
                sanpham = new GioHang(iMaSP);
                lstGiohang.Add(sanpham);
                return Redirect(strURL);

            }
            else
            {
                sanpham.iSoLuong++;
                return Redirect(strURL);

            }

        }
        // Tổng số lượng
        private int TongSoLuong()
        {
            int iTongsoluong = 0;
            List<GioHang> lstGiohang = Session["Giohang"] as List<GioHang>;
            if (lstGiohang == null)
            {
                iTongsoluong = lstGiohang.Sum(n => n.iSoLuong);

            }
            return iTongsoluong;
        }
        // Tinh Tổng Tiền
        private double TongTien()
        {
            double iTongTien = 0;
           List<GioHang> lstGiohang = Session["Giohang"] as List<GioHang>;
           if(lstGiohang!=null)
              {
                iTongTien = lstGiohang.Sum(n => n.dThanhtien);
              }
            return iTongTien;
            }
        //Tạo Giỏ Hàng
        public ActionResult Giohang()
        {
            List<GioHang> lstGiohang = LayGioHang();
            if (lstGiohang.Count == 0)
            {
                return RedirectToAction("Index", "ShopFashion");
            }
                ViewBag.Tongsoluong = TongSoLuong();
                ViewBag.Tongtien = TongTien();
                return View(lstGiohang);

            }

        }


               }
    
        






     
 
 
        







