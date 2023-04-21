create database dbQuanLyBanHang_TBMayTinh
go 
use dbQuanLyBanHang_TBMayTinh
go
create table tblNhomHang
(
sManhom nvarchar(10) not null,
sTennhom nvarchar(30)
)
--drop table tblNhomHang
go
alter table tblNhomHang
ADD CONSTRAINT PK_tblNhomhang primary key(sManhom)
go
create table tblHangHoa
(
sMahang nvarchar(10) not null,
sTenhang nvarchar(30),
sMausac nvarchar(20),
fKichthuoc float,
sDactinhkythuat nvarchar(30),
sManhom nvarchar(10)
)
go
alter table tblHanghoa
ADD CONSTRAINT PK_tblHanghoa primary key(sMahang),
CONSTRAINT FK_nhom_Hanghoa foreign key(sManhom)
references tblNhomhang(sManhom)
alter table tblHanghoa
add fSoluong float
go
CREATE TABLE tblKhachHang
(
iMaKH int primary key,
sTenKH nvarchar(30) not null,
sDiachi nvarchar(50) not null,
sDienthoai nvarchar(12)
);
go
CREATE TABLE tblNhanVien
(
iMaNV int primary key,
sTenNV nvarchar(30) not null,
sDiachi nvarchar(50) not null,
sDienthoai nvarchar(12) not null,
dNgaysinh datetime,
dNgayvaolam datetime,
);
alter table tblNhanvien
add sGioitinh nvarchar(5)
alter table tblNhanVien
add constraint CK_GT CHECK(sGioitinh =N'Nam' or sGioitinh=N'Nữ')
go
CREATE TABLE tblNhaCungCap
(
iMaNCC int  not null,
sTenNhaCC nvarchar(50) ,
sDienthoai nvarchar(12) null,
sDiachi nvarchar(50)
CONSTRAINT PK_tblNhaCungCap PRIMARY Key(iMaNCC)
);
alter table tblNhaCungCap
add sDiachi nvarchar(50)

go
create table tblHoaDonNhapHang
(
sMaHDnhap nvarchar(10) not null,
dNgaynhap datetime,
iMaNV int references tblNhanVien(iMaNV),
iMaNCC int
)
alter table tblHoaDonNhapHang
ADD constraint FK_DNH_NCC foreign key(iMaNCC)
references tblNhaCungCap(iMaNCC)
--drop table tblHoaDonNhapHang
go
alter table tblHoaDonNhapHang
ADD CONSTRAINT PK_tblHoaDonNH primary key(sMaHDnhap)
go
create table tblCTHoaDonNhapHang
(
sMaHDnhap nvarchar(10) not null,
sMahang nvarchar(10) not null,
fSoluong float,
fGianhap float
constraint PK_CTHDNH primary key(sMaHDnhap,sMaHang)
)
alter table tblCTHoaDonNhapHang
add  fThanhtien_CTnhap float
go
alter table tblCTHoaDonNhapHang
ADD CONSTRAINT FK_CTDNH_sMaHang foreign key(sMahang)
references tblHangHoa(sMahang),
CONSTRAINT FK_CTDNH_sMaHDnhap foreign key(sMaHDnhap)
references tblHoaDonNhapHang(sMaHDnhap)
go
create table tblHoaDonBanHang
(
sMaHDban nvarchar(10) primary key,
iMaNV int references tblNhanVien(iMaNV),
iMaKH int references tblKhachHang(iMaKH),
dNgayban datetime,
)
create table tblCTHoaDonBanHang
(
sMaHDban nvarchar(10) not null,
sMahang nvarchar(10) not null,
fSoluong float,
fGiaban float,
fBaohanh float
constraint PK_CTHDBH primary key(sMaHDban,sMaHang)
)
go
alter table tblCTHoaDonBanHang
ADD CONSTRAINT FK_CTDBH_sMaHang foreign key(sMahang)
references tblHangHoa(sMahang),
CONSTRAINT FK_CTDBH_sMaHDnhap foreign key(sMaHDban)
references tblHoaDonBanHang(sMaHDban)
go
--alter table tblCTHoaDonBanHang
--add  fThanhtien_CTban float
go
create table Account
(
	sTenTK int primary key,
	sMatkhau nvarchar(50),
	--iMaNV int references tblNhanVien(iMaNV)
)
--drop table Account
alter table Account
Add constraint FK_stentk foreign key(sTenTK)
references tblNhanVien(iMaNV)
--alter table tblCTHoaDonBanHang
--drop column  fThanhtien_CTban
--alter table tblCTHoaDonNhapHang
--drop column  fThanhtien_CTnhap
alter table tblHangHoa
drop column fKichthuoc
insert into tblKhachHang(iMaKH,sTenKH,sDiachi,sDienthoai)
VALUES  (234233, N'Nguyễn Văn Tùng ', N'320 Đường Thành - Hà Nội', N'0165372945'),
		(242222, N'Nguyễn Văn Nam', N'34 Hai Bà Trưng - Hà Nội', N'098376472'),
		(277565, N'Nguyễn Thị Hoa', N'13 Hoàn Kiếm - Hà Nội', N'015329445'),
		(284355, N'Nguyễn Văn Tùng', N'12 Giải Phóng - Hà Nội', N'016363943'),
		(293453, N'Trần Thị Li', N'Thường Tín - Hà Nội', N'0173636492'),
		(306356, N'Trần Thanh Thảo', N'Minh Cường - Thường Tín', N'015234304'),
		(312453, N'Kiều Tuấn Anh', N'	Minh Khai - Hà Nội', N'123745383'),
		(323333, N'Trần Thị Trà', N'	Tiên Du - Bắc Ninh', N'	0987654321'),
		(336757, N'Triệu Chí Bình', N'79 Giải Phóng - Hà Nội', N'0987654321'),
		(344343, N'Vũ Tuấn Lê', N'Giải Phóng - Hà Nội', N'0162339440'),
		(354344, N'Nguyễn Thị Thủy', N'Quân 5 - Hồ Chí Minh', N'097364345'),
		(364343, N'Đặng Thị Hạnh', N'Kí túc xá Pháp Vân', N'01836439'),
		(374343, N'Đỗ Hà', N'Thanh Oai - Hà Nội', N'0165359345'),
		(384344, N'Nguyễn Thị Ninh', N'Tiên Du - Bắc Ninh', N'093305324'),
		(392234, N'Nguyễn Ánh Vân ', N'Thành phố Lạng Sơn', N'06399545'),
		(405455, N'Đỗ Minh Trường', N'Thị trấn Thường Tín-Hà Nội', N'01697533'),
		(416464, N'Lê Thanh Hương', N'Láng Hòa Lạc - Thạch Thất', N'09324926492'),
		(425355, N'Nguyễn Ngọc Chinh', N'Minh Cường - Thường Tín', N'015234304'),
		(438785, N'Nguyễn Thị Hiếu', N'Thanh Oai - Hà Nội', N'015234304'),
		(444342, N'Nguyễn Ngọc Chinh', N'Minh Cường - Thường Tín', N'015234304'),
		(454244, N'Nguyễn Thị Nhường', N'Thường Tín - Hà Nội', N'0337850181'),
		(460444, N'Phạm Quốc Khánh', N'Định Công - Hà Nội', N'015234304'),
		(472428, N'Nguyễn Thị Thủy', N'Việt Yên-Bắc Giang', N'015234304'),
		(480439, N'Trần Văn Bình', N'Việt Yên-Bắc Giang', N'0843829323'),
		(790439, N'Nguyễn Thị An', N'Việt Yên-Bắc Giang', N'0369404911'),
		(820943, N'Phạm thị Hằng', N'99 Định Công - Hà Nội', N'0368404911'),
		(840243, N'TRần Duy Hùng', N'100 Định Công - Hà Nội', N'0369202911'),
		(860000, N'Tống Bá Hưng', N'101 Định Công - Hà Nội', N'0369404922'),
		(911111, N'Tống Văn Tạo', N'Văn Giang - Hưng Yên', N'0369404933'),
		(932332, N'Nguyễn Danh Tú', N'Chương Mỹ - Hà Nội', N'0369404844')

go
create proc getAllNhanVien
as
begin
	select [iMaNV], [sTenNV], [sDiachi], [sDienthoai], [dNgaysinh], dNgayvaolam, [sGioitinh] 
	from [dbo].[tblNhanVien];
end
go

create proc insertNhanVien(
	@iMaNV int ,
	@sTenNV nvarchar(50), 
	@sDiachi nvarchar(50), 
	@sDienthoai nvarchar(50), 
	@dNgaysinh date, 
	@dNgayvaolam date, 
	@sGioitinh nvarchar(50)
)
as
begin
	insert into [dbo].[tblNhanVien]([iMaNV], [sTenNV], [sDiachi], [sDienthoai], [dNgaysinh], dNgayvaolam, [sGioitinh])
	values(@iMaNV ,@sTenNV , @sDiachi , @sDienthoai , @dNgaysinh , @dNgayvaolam , @sGioitinh )
end

go
create proc DeleteNhanVien
@maNV int
as
begin
	DELETE FROM [dbo].[tblNhanVien] WHERE iMaNV = @maNV
end
go

create proc UpdateNhanVien(
	@iMaNV int ,
	@sTenNV nvarchar(50), 
	@sDiachi nvarchar(50), 
	@sDienthoai nvarchar(50), 
	@dNgaysinh date, 
	@dNgayvaolam date, 
	@sGioitinh nvarchar(50))
as
begin
	UPDATE [dbo].[tblNhanVien] 
	SET 
	iMaNV = @iMaNV,
	sTenNV = @sTenNV,
	sDiachi = @sDiachi,
	sDienthoai = @sDienthoai,
	dNgaysinh = @dNgaysinh,
	dNgayvaolam = @dNgayvaolam,
	sGioitinh = @sGioitinh
	WHERE iMaNV = @iMaNV;
end
go