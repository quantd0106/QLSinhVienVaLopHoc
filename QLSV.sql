-- Tạo Database
CREATE DATABASE QLSinhVienVaLopHocDB;
GO

USE QLSinhVienVaLopHocDB;
GO

-- Tạo bảng SinhVien
CREATE TABLE SinhVien (
    MaSV NVARCHAR(50) PRIMARY KEY,
    HoTen NVARCHAR(100),
    GioiTinh NVARCHAR(10),
    NgaySinh DATE,
    Lop NVARCHAR(50)
);
GO

-- Thêm thử vài dữ liệu mẫu
INSERT INTO SinhVien (MaSV, HoTen, GioiTinh, NgaySinh, Lop)
VALUES 
('0022568', N'quanTD', N'Nam', '2005-03-11', 'IT01'),
('0022569', N'Nguyễn Văn A', N'Nam', '2005-05-15', 'IT02');

-- Tạo bảng Lớp Học
CREATE TABLE LopHoc (
    MaLop NVARCHAR(50) PRIMARY KEY,
    TenLop NVARCHAR(100),
    Khoa NVARCHAR(100)
);
GO

-- Thêm thử vài dữ liệu mẫu
INSERT INTO LopHoc (MaLop, TenLop, Khoa)
VALUES 
('IT01', N'Công nghệ thông tin 01', N'Công nghệ thông tin'),
('IT02', N'Công nghệ thông tin 02', N'Công nghệ thông tin'),
('KT01', N'Kế toán doanh nghiệp 01', N'Kinh tế');
GO