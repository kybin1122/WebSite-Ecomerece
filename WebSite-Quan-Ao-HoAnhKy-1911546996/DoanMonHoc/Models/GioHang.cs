using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoanMonHoc.Models
{
    public class GioHang
    {
        // tạo đối tượng quản lý cơ sở dũ liệu
        ShopFaShionDataContext data = new ShopFaShionDataContext();

        public int iMaSP { set; get; }
        public String sTenSP { set; get; }
        public String sAnhbia { set; get; }
        public Double dDongia { set; get; }
        public int iSoLuong { set; get; }
        public Double dThanhtien
        {
            get { return iSoLuong * dDongia; }
        }
        public GioHang(int MaSP)
        {
            iMaSP = MaSP;
            SanPham sanpham = data.SanPhams.Single(n => n.MaSP == iMaSP);
            sTenSP = sanpham.TenSP;
            sAnhbia = sanpham.AnhBia;
            dDongia = double.Parse(sanpham.GiaBan.ToString());
            iSoLuong = 1;

        }
        
        

    }
}