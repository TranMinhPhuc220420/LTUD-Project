-- TABLE CHUCVU
CREATE PROC sp_InsertChucVu(@maCV VARCHAR(12), @tenCV NVARCHAR(500)) -- ADD
AS
	INSERT INTO CHUCVU(MaCV, TenCV)
	VALUES(@maCV, @tenCV)
GO
 
CREATE PROC sp_DeleteChucVu(@maCV VARCHAR(12)) -- DELETE
AS 
	DELETE FROM CHUCVU WHERE CHUCVU.MaCV = @maCV
GO
 
CREATE PROC sp_UpdateChucVu(@maCV VARCHAR(12), @tenCV VARCHAR(500)) -- UPDATE
AS
	UPDATE CHUCVU
	SET TenCV = @tenCV
	WHERE CHUCVU.MaCV = @maCV
GO

CREATE PROC sp_SelectAllChucVu -- SELECT ALL
AS
	SELECT * FROM CHUCVU
GO

CREATE PROC sp_SelectChucVuByMaCV(@maCV VARCHAR(12)) -- SELECT BY MaCV
AS
	SELECT * FROM CHUCVU
	WHERE CHUCVU.MaCV = @maCV
GO



-- TABLE HOPDONGLAODONG
CREATE PROC sp_InsertHopDongLaoDong(@maHD VARCHAR(12), @loaiHD NVARCHAR(500), @tuNgay DATE, @denNgay DATE) --INSERT
AS 
	INSERT INTO HOPDONGLAODONG(MaHD, LoaiHD, TuNgay,DenNgay)
	VALUES (@maHD, @loaiHD, @tuNgay, @denNgay)
GO

CREATE PROC sp_DeleteHopDongLaoDong(@maHD VARCHAR(12)) -- DELETE
AS
	DELETE FROM HOPDONGLAODONG WHERE HOPDONGLAODONG.MaHD = @maHD
GO

CREATE PROC sp_UpdateHopDongLaoDong(@maHD VARCHAR(12), @loaiHD NVARCHAR(500), @tuNgay DATE, @denNgay DATE) --UPDATE
AS
	UPDATE HOPDONGLAODONG
	SET LoaiHD = @loaiHD,
		TuNgay = @tuNgay,
		DenNgay = @denNgay
	WHERE MaHD = @maHD
GO

CREATE PROC sp_SelectAllHopDongLaoDong -- SELECT ALL
AS
	SELECT * FROM HOPDONGLAODONG
GO
exec sp_SelectAllHopDongLaoDong
CREATE PROC sp_SelectHopDongLaoDongByMaHD(@maHD VARCHAR(12)) -- SELECT BY MaHD
AS
	SELECT * FROM HOPDONGLAODONG
	WHERE HOPDONGLAODONG.MaHD = @maHD
GO


-- TABLE LUONG
CREATE PROC sp_InsertLuong(@batLuong INT, @luongCB INT, @HSLuong INT, @HSPhuCap INT) -- INSERT
AS
	INSERT INTO LUONG(BacLuong, LuongCB, HSLuong, HSPhuCap)
	VALUES (@batLuong, @luongCB, @HSLuong, @HSPhuCap)
GO

CREATE PROC sp_DeleteLuong(@bacLuong INT) -- DELETE
AS 
	DELETE FROM LUONG WHERE LUONG.BacLuong = @bacLuong
GO

CREATE PROC sp_UpdateLuong(@batLuong INT, @luongCB INT, @HSLuong INT, @HSPhuCap INT) -- UPDATE
AS 
	UPDATE LUONG
	SET LuongCB = @luongCB,
		HSLuong = @HSLuong,
		HSPhuCap = @HSPhuCap
	WHERE BacLuong = @batLuong
GO

CREATE PROC sp_SelectLuong -- SELECT ALL TABLE LUONG
AS
	SELECT * FROM LUONG
GO

CREATE PROC sp_SelectLuongByBacLuong(@bacLuong INT) -- SELECT LUONG BY BACLUONG
AS
	SELECT * FROM LUONG 
	WHERE LUONG.BacLuong = @bacLuong
GO



-- TABLE NHAN VIEN
CREATE PROC sp_InsertNhanVien(@maNV VARCHAR(12), @tenNV NVARCHAR(500), @SDT VARCHAR(12), @gioiTinh BIT,
							  @ngaySinh DATE, @danToc NVARCHAR(50), @queQuan NVARCHAR(500), @diaChi NVARCHAR(1000), @CMND VARCHAR(12),
							  @maPB VARCHAR(12),
							  @maCV VARCHAR(12),
							  @maTDHV VARCHAR(12),
							  @bacLuong INT,
							  @maHD VARCHAR(12)) -- INSERT
AS
	INSERT INTO NHANVIEN(MaNV, TenNV, SDT, GIOITINH, NgaySinh, DanToc, QueQuan, DiaChi, CMND, MaPB, MaCV, MaTDHV, BacLuong, MaHD)
	VALUES (@maNV, @tenNV, @SDT, @gioiTinh, @ngaySinh, @danToc, @queQuan, @diaChi, @CMND, @maPB, @maCV, @maTDHV, @bacLuong, @maHD)
GO

CREATE PROC sp_DeleteNhanVien(@maNV VARCHAR(12)) -- DELETE
AS
	DELETE NHANVIEN WHERE NHANVIEN.MaNV = @maNV
GO

CREATE PROC sp_UpdateNhanVien(@maNV VARCHAR(12), @tenNV NVARCHAR(500), @SDT VARCHAR(12), @gioiTinh BIT,
							  @ngaySinh DATE, @danToc NVARCHAR(50), @queQuan NVARCHAR(500), @diaChi NVARCHAR(1000), @CMND VARCHAR(12),
							  @maPB VARCHAR(12),
							  @maCV VARCHAR(12),
							  @maTDHV VARCHAR(12),
							  @bacLuong INT,
							  @maHD VARCHAR(12)) -- UPDATE
AS
	UPDATE NHANVIEN
	SET TenNV = @tenNV,
		SDT = @SDT,
		GIOITINH = @gioiTinh,
		NgaySinh = @ngaySinh,
		DanToc = @danToc,
		QueQuan = @queQuan,
		DiaChi = @diaChi,
		CMND = @CMND,
		MaPB = @maPB,
		MaCV = @maCV,
		MaTDHV = @maTDHV,
		BacLuong = @bacLuong,
		MaHD = @maHD
	WHERE NHANVIEN.MaNV = @maNV
GO

CREATE PROC sp_SelectAllNhanVien -- SELECT ALL NHANVIEN
AS 
	SELECT MaNV, TenNV, SDT, GIOITINH, NgaySinh, DanToc, QueQuan, nv.DiaChi, CMND,
		pb.TenPB, cv.TenCV, tdhv.TenTDHV, l.LuongCB, hdld.LoaiHD
	 FROM NHANVIEN nv
	 JOIN PHONGBAN pb
		ON pb.MaPB = nv.MaPB
	 JOIN CHUCVU cv
		ON cv.MaCV = nv.MaCV
	 JOIN TRINHDOHOCVAN tdhv
		ON tdhv.MaTDHV = nv.MaTDHV
	 JOIN LUONG l
		ON l.BacLuong = nv.BacLuong
	 JOIN HOPDONGLAODONG hdld
		ON hdld.MaHD = nv.MaHD
GO

exec sp_SelectAllNhanVien

CREATE PROC sp_SelectNhanVienByMaNV(@maNV VARCHAR(12)) -- SELECT NHAN VIEN BY IN
AS
	SELECT MaNV, TenNV, SDT, GIOITINH, NgaySinh, DanToc, QueQuan, nv.DiaChi, CMND,
		pb.TenPB, cv.TenCV, tdhv.TenTDHV, l.LuongCB, hdld.LoaiHD
	 FROM NHANVIEN nv 
	 JOIN PHONGBAN pb
		ON pb.MaPB = nv.MaPB
	 JOIN CHUCVU cv
		ON cv.MaCV = nv.MaCV
	 JOIN TRINHDOHOCVAN tdhv
		ON tdhv.MaTDHV = nv.MaTDHV
	 JOIN LUONG l
		ON l.BacLuong = nv.BacLuong
	 JOIN HOPDONGLAODONG hdld
		ON hdld.MaHD = nv.MaHD
	 WHERE nv.MaNV = @maNV

GO

-- TABLE PHONGBAN
CREATE PROC sp_InsertPhongBan(@maPB VARCHAR(12), @tenPB NVARCHAR(500), @diaChi NVARCHAR(1000), @maTrgPhong VARCHAR(12)) -- INSERT
AS
	INSERT INTO PHONGBAN(MaPB, TenPB, DiaChi, MaTRPHONG)
	VALUES (@maPB, @tenPB, @diaChi, @maTrgPhong)
GO

CREATE PROC sp_DeletePhongBan(@maPB VARCHAR(12)) -- DELETE
AS
	DELETE PHONGBAN WHERE PHONGBAN.MaPB = @maPB
GO

CREATE PROC sp_UpdatePhongBan(@maPB VARCHAR(12), @tenPB NVARCHAR(500), @diaChi NVARCHAR(1000), @maTrgPhong VARCHAR(12)) --UPDATE
AS
	UPDATE PHONGBAN 
	SET TenPB = @tenPB,
		DiaChi = @diaChi,
		@maTrgPhong = @maTrgPhong
	WHERE MaPB = @maPB
GO

CREATE PROC sp_SelectAllPhongBan --SELECT ALL TABLE PHONGBAN
AS
	SELECT * FROM PHONGBAN
GO

CREATE PROC sp_SelectPhongBanByMaPB(@maPB VARCHAR(12))
AS 
	SELECT * FROM PHONGBAN WHERE MaPB = @maPB
GO

-- TABLE TRINHDOHOCVAN
CREATE PROC sp_InsertTrinhDoHocVan(@maTDHV VARCHAR(12), @tenTDHV NVARCHAR(500), @cNganh NVARCHAR(500)) --INSERT
AS
	INSERT INTO TRINHDOHOCVAN(MaTDHV, TenTDHV, CNGANH)
	VALUES (@maTDHV, @tenTDHV, @cNganh)
GO

CREATE PROC sp_DeleteTrinhDoHocVan(@maTDHV VARCHAR(12)) -- DELETE
AS
	DELETE TRINHDOHOCVAN WHERE MaTDHV = @maTDHV
GO

CREATE PROC sp_UpdateTrinhDoHocVan(@maTDHV VARCHAR(12), @tenTDHV NVARCHAR(500), @cNganh NVARCHAR(500)) -- UPDATE
AS
	UPDATE TRINHDOHOCVAN 
	SET	TenTDHV = @tenTDHV,
		CNGANH = @cNganh
	WHERE MaTDHV = @maTDHV
GO

CREATE PROC sp_SelectAllTrinhDoHocVan -- SELECT ALL TABLE TRINHDOHOCVAN
AS
	SELECT * FROM TRINHDOHOCVAN
GO

CREATE PROC sp_SelectTrinhDoHocVanByMaTDHV(@maTDHV VARCHAR(12)) -- SELECT BY MaTHDV 
AS
	SELECT * FROM TRINHDOHOCVAN WHERE MaTDHV = @maTDHV
GO

-- TABLE TAIKHOAN
CREATE PROC sp_InsertTaiKhoan(@maNV VARCHAR(12), @matKhau VARCHAR(12), @vaiTro INT) -- INSERT 
AS
	INSERT INTO TAIKHOAN(MaNV, MatKhau, VaiTro)
	VALUES (@maNV, @matKhau, @vaiTro)
GO

CREATE PROC sp_DeleteTaiKhoan(@maNV VARCHAR(12)) -- DELETE
AS
	DELETE TAIKHOAN WHERE TAIKHOAN.MaNV = @maNV
GO

CREATE PROC sp_UpdateTaiKhoan(@maNV VARCHAR(12), @matKhau VARCHAR(12), @vaiTro INT) -- UPDATE
AS
	UPDATE TAIKHOAN
	SET MatKhau = @matKhau,
		VaiTro = @vaiTro
	WHERE MaNV = @maNV
GO

CREATE PROC sp_SelectAllTaiKhoan -- SELECT ALL
AS
	SELECT * FROM TAIKHOAN
GO

CREATE PROC sp_SelectTaiKhoanByMaNV(@maNV VARCHAR(12)) -- SELECT TAIKHOAN BY MaNV
AS
	SELECT * FROM TAIKHOAN 
	WHERE MaNV = @maNV
GO

