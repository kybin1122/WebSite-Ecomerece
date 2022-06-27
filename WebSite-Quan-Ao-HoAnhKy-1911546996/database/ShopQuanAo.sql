
Drop Database ShopQuanAo
Create Database ShopQuanAo
Go
Use ShopQuanAo
Go
--Drop table KhachHang
--Go
Create Table	KhachHang
(
	MaKH	Int	Identity(1,1),
	HoTen	Nvarchar(50)	Not Null,
	TaiKhoan	Varchar(50)	Unique,
	MatKhau	Varchar(50)	Not Null,
	Email	Varchar(100)	Unique,
	DiachiKH	Nvarchar(200),
	DienThoaiKH	Varchar(50),
	NgaySinh	DateTime,
	Constraint	Pk_KhachHang	Primary Key(MaKH)
)
Go
--Drop table LoaiSP
--Go
Create Table	LoaiSP
(
	MaLoai	Int	Identity(1,1),
	TenLoai	Nvarchar(50)	Not Null,
	Constraint Pk_LoaiSP Primary Key(MaLoai)
)
Go
--Drop table NhaSanXuat
--Go
Create Table	NhaSanXuat
(
	MaNSX	Int Identity(1,1),
	TenNSX	Nvarchar(50)	Not Null,
	DiaChi	Nvarchar(200),
	DienThoai	Varchar(50),
	Constraint	Pk_NhaSanXuat Primary Key(MaNSX),
)
Go
--Drop table SanPham
--Go
Create Table	SanPham
(
	MaSP	Int	Identity(1,1),
	TenSP	Nvarchar(100)	Not Null,
	GiaBan	Decimal(18,0)	Check(GiaBan>=0),
	MoTa	Nvarchar(Max),
	AnhBia	Varchar(50),
	NgayCapNhat	DateTime,
	SoLuongTon	Int,
	MaLoai	Int,
	MaNSX	Int,
	Constraint	Pk_SanPham	Primary Key(MaSP),
	Constraint	Fk_LoaiSP	Foreign	Key(MaLoai) References	LoaiSP(MaLoai),
	Constraint	Fk_NhaSanXuat	Foreign Key(MaNSX) References	NhaSanXuat(MaNSX)
)
Go

--Drop table DonDatHang
--Go
Create Table	DonDatHang
(
	SoDH	Int Identity(1,1),
	MaKH	Int,
	NgayDH	DateTime,
	NgayGiao	DateTime,
	DaThanhToan	Bit,
	TinhTrangGiaoHang	Bit,
	Constraint	Pk_DonDatHang	Primary Key(SoDH),
	Constraint	Fk_KhachHang	Foreign	Key(MaKH)	References	KhachHang(MaKH)
)
Go
--Drop table ChiTietDatHang
--Go
Create Table	ChiTietDatHang
(
	SoDH	Int,
	MaSP	Int,
	SoLuong	Int	Check(SoLuong>0),
	DonGia Decimal(18,0)	Check(DonGia>=0),
	Constraint	Pk_ChiTietDatHang	Primary Key(SoDH,MaSP),
	Constraint	Fk_DonHang	Foreign	Key(SoDH)	References	DonDatHang(SoDH),
	Constraint	Fk_SanPham	Foreign Key(MaSP)	References	SanPham(MaSP)
)
Go
--Thêm dữ liệu:
---Loại Sản Phẩm
	Insert into LoaiSP Values (N'SPORTSWEAR')
	Insert into LoaiSP Values (N'MENS')
	Insert into LoaiSP values (N'WOMENS')
	Insert into LoaiSP values (N'KIDS')
	Insert into LoaiSP values (N'FASHION')
	Insert into LoaiSP values (N'HOUSEHOLDS')
	Insert into LoaiSP values (N'INTERIORS')
	Insert into LoaiSP values (N'CLOTHING')
	Insert into LoaiSP values (N'BAGS')
	Insert into LoaiSP values (N'SHOES')
select *from LoaiSP
---Nhà Sản Xuất
---	Insert into NhaSanXuat values (N'',N'','')
	Insert into NhaSanXuat values (N'Shop Hoa Hồng',N' 161 B Lý Chính Thắng - Phường 7 - Quận 3 - Thành phố Hồ Chí Minh','84839316289')
	Insert into NhaSanXuat values (N'Shop Áo Thun',N'161 B Pham Ngọc Thạch - Phường 6 - Quận 3','0972112919')
	Insert into NhaSanXuat values (N'Phong Vũ',N'453 A Sa đéc','0787984397')
	Insert into NhaSanXuat values (N'Linh Lan',N'','063687389')
	Insert into NhaSanXuat values (N'Heo Ú',N'','039483738')
	Insert into NhaSanXuat values (N'Bông Tím',N'','03974348948')
	Insert into NhaSanXuat values (N'Aoi Sama',N'','043743759385')
	SET IDENTITY_INSERT tableA OFF
select *from NhaSanXuat
---SanPham
	Insert into SanPham values (N' Áo Nam Tay ngắn Sơ Mi',25000,N' ','product1.jpg','01/04/2016',15,1,1)
	Insert into SanPham values (N'Áo nữ Tay Dài ',15000,N' ','product2.jpg','01/04/2016',17,1,1)
	Insert into SanPham values (N' Đầm Đen Nữ',35000,N' ','product3.jpg','02/04/2016',30,1,2)
	Insert into SanPham values (N'Áo Polo nam',75000,N' ','product4.jpg','03/04/2016',5,1,3)
	Insert into SanPham values (N' Áo cardigan ngắn Nữ',45000,N' ','product5.jpg','04/04/2016',9,1,4)
select *from SanPham

--Dữ liệu cập nhật: Tài khoản quản trị
Create table Admin
(
	UserAdmin varchar(30) primary key,
	PassAdmin varchar(30) not null,
	Hoten nVarchar(50)
)
Insert into Admin values('admin','123456','HoAnhKy')
Insert into Admin values('user','1234567','RenNin')
select *from Admin