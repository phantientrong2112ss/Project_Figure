USE [master]
GO
/****** Object:  Database [FIGUREWA]    Script Date: 19/7/2023 5:34:42 PM ******/
CREATE DATABASE [FIGUREWA]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FIGUREWA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\FIGUREWA.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FIGUREWA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\FIGUREWA_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [FIGUREWA] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FIGUREWA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FIGUREWA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FIGUREWA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FIGUREWA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FIGUREWA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FIGUREWA] SET ARITHABORT OFF 
GO
ALTER DATABASE [FIGUREWA] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [FIGUREWA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FIGUREWA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FIGUREWA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FIGUREWA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FIGUREWA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FIGUREWA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FIGUREWA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FIGUREWA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FIGUREWA] SET  ENABLE_BROKER 
GO
ALTER DATABASE [FIGUREWA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FIGUREWA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FIGUREWA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FIGUREWA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FIGUREWA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FIGUREWA] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FIGUREWA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FIGUREWA] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FIGUREWA] SET  MULTI_USER 
GO
ALTER DATABASE [FIGUREWA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FIGUREWA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FIGUREWA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FIGUREWA] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FIGUREWA] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FIGUREWA] SET QUERY_STORE = OFF
GO
USE [FIGUREWA]
GO
/****** Object:  Table [dbo].[bill_detail_ban]    Script Date: 19/7/2023 5:34:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bill_detail_ban](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_bill_ban] [int] NOT NULL,
	[id_sp] [int] NOT NULL,
	[unit_prices] [int] NOT NULL,
	[sl] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bill_detail_nhap]    Script Date: 19/7/2023 5:34:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bill_detail_nhap](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_bill_nhap] [int] NOT NULL,
	[id_sp] [int] NOT NULL,
	[sl] [int] NOT NULL,
	[don_vi] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bills_ban]    Script Date: 19/7/2023 5:34:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bills_ban](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_kh] [int] NULL,
	[date_order] [date] NULL,
	[tong_tien] [float] NULL,
	[payment] [nvarchar](200) NULL,
	[status] [nvarchar](20) NOT NULL,
	[note] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bills_nhap]    Script Date: 19/7/2023 5:34:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bills_nhap](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_ncc] [int] NULL,
	[id_nhanvien] [int] NOT NULL,
	[date_order] [date] NULL,
	[tong_tien] [float] NULL,
	[thanh_toan] [nvarchar](200) NULL,
	[note] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[khach_hang]    Script Date: 19/7/2023 5:34:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[khach_hang](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ten_kh] [nvarchar](100) NOT NULL,
	[email] [nvarchar](255) NOT NULL,
	[dia_chi] [nvarchar](255) NOT NULL,
	[sdt] [nvarchar](20) NOT NULL,
	[note] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[loai_sp]    Script Date: 19/7/2023 5:34:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[loai_sp](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tenloai] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[tenloai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[news]    Script Date: 19/7/2023 5:34:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[news](
	[id_new] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](200) NOT NULL,
	[content] [nvarchar](max) NOT NULL,
	[image] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_new] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nha_cung_cap]    Script Date: 19/7/2023 5:34:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nha_cung_cap](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ten_ncc] [nvarchar](100) NOT NULL,
	[diachi_ncc] [nvarchar](max) NOT NULL,
	[email] [nvarchar](255) NOT NULL,
	[sdt] [nvarchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nhan_vien]    Script Date: 19/7/2023 5:34:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nhan_vien](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ten_nhanvien] [nvarchar](255) NOT NULL,
	[gioitinh] [nvarchar](10) NOT NULL,
	[ngaysinh] [date] NOT NULL,
	[quequan] [nvarchar](100) NOT NULL,
	[sdt] [nvarchar](20) NOT NULL,
	[email] [nvarchar](255) NOT NULL,
	[capbac] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[san_pham]    Script Date: 19/7/2023 5:34:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[san_pham](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[id_loai_sp] [int] NULL,
	[id_ncc] [int] NOT NULL,
	[mota_sp] [nvarchar](max) NULL,
	[unit_price] [float] NULL,
	[gia_km] [float] NULL,
	[so_luong] [int] NOT NULL,
	[image] [nvarchar](255) NULL,
	[img2] [nvarchar](255) NULL,
	[img3] [nvarchar](255) NULL,
	[don_vi_tinh] [nvarchar](255) NULL,
	[newss] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 19/7/2023 5:34:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[full_name] [nvarchar](50) NOT NULL,
	[users_name] [nvarchar](50) NOT NULL,
	[email] [nvarchar](255) NOT NULL,
	[password] [nvarchar](255) NOT NULL,
	[phone] [nvarchar](20) NOT NULL,
	[address] [nvarchar](255) NOT NULL,
	[image] [text] NULL,
	[capquyen] [int] NOT NULL,
	[remember_token] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[users_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[san_pham] ADD  DEFAULT ((0)) FOR [newss]
GO
ALTER TABLE [dbo].[bill_detail_nhap]  WITH CHECK ADD FOREIGN KEY([id_bill_nhap])
REFERENCES [dbo].[bills_nhap] ([id])
GO
ALTER TABLE [dbo].[san_pham]  WITH CHECK ADD FOREIGN KEY([id_loai_sp])
REFERENCES [dbo].[loai_sp] ([id])
GO
/****** Object:  StoredProcedure [dbo].[P_bb]    Script Date: 19/7/2023 5:34:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[P_bb]
@id int,
@id_kh nvarchar(50),
@date_order date,
@tong_tien float,
@payment nvarchar(200),
@status nvarchar(20),
@note nvarchar(500),
@type nvarchar(50)
AS 
BEGIN 
IF (@type='getall')
	BEGIN 
	SELECT * FROM bills_ban
	END
ELSE IF(@type='getid')
	BEGIN 
		SELECT * FROM bills_ban
		WHERE id=@id
	END
ELSE IF(@type='insert')
	BEGIN 
		INSERT INTO bills_ban(id_kh,date_order,tong_tien,payment,status,note) 
		Values (@id_kh,@date_order,@tong_tien,@payment,@status,@note)
	END
ELSE IF(@type='update')
	BEGIN 
		UPDATE bills_ban
		SET id_kh=@id_kh,
			date_order=@date_order,
			tong_tien=@tong_tien,
			payment=@payment,
			status=@status,
			note=@note
		WHERE id=@id
	END
ELSE IF(@type='delete')
	BEGIN 
		DELETE FROM bills_ban
		WHERE id=@id
	END
END
GO
/****** Object:  StoredProcedure [dbo].[P_bbd]    Script Date: 19/7/2023 5:34:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[P_bbd]
@id int,
@id_bill_ban  int,
@id_sp  int,
@unit_prices  int,
@sl  int,
@type nvarchar(50)
AS 
BEGIN 
IF (@type='getall')
	BEGIN 
	SELECT * FROM bill_detail_ban
	END
ELSE IF(@type='getid')
	BEGIN 
		SELECT * FROM bill_detail_ban
		WHERE id=@id
	END
ELSE IF(@type='insert')
	BEGIN 
		INSERT INTO bill_detail_ban(id_bill_ban,id_sp,unit_prices,sl) 
		Values (@id_bill_ban,@id_sp,@unit_prices,@sl)
	END
ELSE IF(@type='update')
	BEGIN 
		UPDATE bill_detail_ban
		SET id_bill_ban=@id_bill_ban,
			id_sp=@id_sp,
			unit_prices=@unit_prices,
			sl=@sl
		WHERE id=@id
	END
ELSE IF(@type='delete')
	BEGIN 
		DELETE FROM bill_detail_ban
		WHERE id=@id
	END
END
GO
/****** Object:  StoredProcedure [dbo].[P_bn]    Script Date: 19/7/2023 5:34:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[P_bn]
@id int,
@id_ncc nvarchar(50),
@id_nhanvien nvarchar(50),
@date_order date,
@tong_tien float,
@thanh_toan nvarchar(20),
@note nvarchar(500),
@type nvarchar(50)
AS 
BEGIN 
IF (@type='getall')
	BEGIN 
	SELECT * FROM bills_nhap
	END
ELSE IF(@type='getid')
	BEGIN 
		SELECT * FROM bills_nhap
		WHERE id=@id
	END
ELSE IF(@type='insert')
	BEGIN 
		INSERT INTO bills_nhap(id_ncc,id_nhanvien,date_order,tong_tien,thanh_toan,note) 
		Values (@id_ncc,@id_nhanvien,@date_order,@tong_tien,@thanh_toan,@note)
	END
ELSE IF(@type='update')
	BEGIN 
		UPDATE bills_nhap
		SET id_ncc=@id_ncc,
			id_nhanvien=@id_nhanvien,
			date_order=@date_order,
			tong_tien=@tong_tien,
			thanh_toan=@thanh_toan,
			note=@note
		WHERE id=@id
	END
ELSE IF(@type='delete')
	BEGIN 
		DELETE FROM bills_nhap
		WHERE id=@id
	END
END
GO
/****** Object:  StoredProcedure [dbo].[P_bnd]    Script Date: 19/7/2023 5:34:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[P_bnd]
@id int,
@id_bill_nhap  int,
@id_sp  int,
@sl  int,
@don_vi  nvarchar(50),
@type nvarchar(50)
AS 
BEGIN 
IF (@type='getall')
	BEGIN 
	SELECT * FROM bill_detail_nhap
	END
ELSE IF(@type='getid')
	BEGIN 
		SELECT * FROM bill_detail_nhap
		WHERE id=@id
	END
ELSE IF(@type='insert')
	BEGIN 
		INSERT INTO bill_detail_nhap(id_bill_nhap,id_sp,sl,don_vi) 
		Values (@id_bill_nhap,@id_sp,@sl,@don_vi)
	END
ELSE IF(@type='update')
	BEGIN 
		UPDATE bill_detail_nhap
		SET id_bill_nhap=@id_bill_nhap,
			id_sp=@id_sp,
			sl=@sl,
			don_vi=@don_vi
		WHERE id=@id
	END
ELSE IF(@type='delete')
	BEGIN 
		DELETE FROM bill_detail_nhap
		WHERE id=@id
	END
END
GO
/****** Object:  StoredProcedure [dbo].[P_getcurrentidofbb]    Script Date: 19/7/2023 5:34:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[P_getcurrentidofbb]
AS 
BEGIN 
		SELECT IDENT_CURRENT('bills_ban')  
	
END
GO
/****** Object:  StoredProcedure [dbo].[P_getdtofbb]    Script Date: 19/7/2023 5:34:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[P_getdtofbb]
@id int,
@type nvarchar(50)
AS 
BEGIN 
IF (@type='getsbyid')
	BEGIN 
	SELECT dtbb.*,sp.name,sp.image
	From bill_detail_ban dtbb inner Join san_pham sp ON dtbb.id_sp=sp.id
	Where dtbb.id_bill_ban =@id
	END
END
GO
/****** Object:  StoredProcedure [dbo].[P_getdtofbn]    Script Date: 19/7/2023 5:34:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[P_getdtofbn]
@id int,
@type nvarchar(50)
AS 
BEGIN 
IF (@type='getsbyid')
	BEGIN 
	SELECT dtbn.*,sp.name,sp.image,sp.unit_price
	From bill_detail_nhap dtbn inner Join san_pham sp ON dtbn.id_sp=sp.id
	Where dtbn.id_bill_nhap = @id
	END
END
GO
/****** Object:  StoredProcedure [dbo].[P_getspbyidlsp]    Script Date: 19/7/2023 5:34:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROC [dbo].[P_getspbyidlsp]
@id int,
@type nvarchar(50)
AS 
BEGIN 
IF (@type='getsbyid')
	BEGIN 
	SELECT * FROM san_pham
	Where id_loai_sp =@id
	END
END
GO
/****** Object:  StoredProcedure [dbo].[P_kh]    Script Date: 19/7/2023 5:34:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROC [dbo].[P_kh]
@id int,
@ten_kh nvarchar(100),
@email nvarchar(255),
@dia_chi nvarchar(255),
@sdt nvarchar(20),
@note nvarchar(MAX),
@type nvarchar(50)
AS 
BEGIN 
IF (@type='getall')
	BEGIN 
	SELECT * FROM khach_hang
	END
ELSE IF(@type='getid')
	BEGIN 
		SELECT * FROM khach_hang
		WHERE id=@id
	END
ELSE IF(@type='insert')
	BEGIN 
		INSERT INTO khach_hang(ten_kh,email,dia_chi,sdt,note) 
		Values (@ten_kh,@email,@dia_chi,@sdt,@note)
	END
ELSE IF(@type='update')
	BEGIN 
		UPDATE khach_hang
		SET 
			ten_kh=@ten_kh,
			email=@email,
			dia_chi=@dia_chi,
			sdt=@sdt,
			note=@note
		WHERE id=@id
	END
ELSE IF(@type='delete')
	BEGIN 
		DELETE FROM khach_hang
		WHERE id=@id
	END
END
GO
/****** Object:  StoredProcedure [dbo].[P_login]    Script Date: 19/7/2023 5:34:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[P_login]
@users_name nvarchar(50),
@password nvarchar(255)
AS 
BEGIN 
		SELECT *
		From users
		Where users.users_name=@users_name AND users.password=@password
	
END
GO
/****** Object:  StoredProcedure [dbo].[P_lsp]    Script Date: 19/7/2023 5:34:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[P_lsp]
@id int,
@tenloai nvarchar(100),
@type nvarchar(50)
AS 
BEGIN 
IF (@type='getall')
	BEGIN 
	SELECT * FROM loai_sp
	END
ELSE IF(@type='getid')
	BEGIN 
		SELECT * FROM loai_sp
		WHERE id=@id
	END
ELSE IF(@type='insert')
	BEGIN 
		INSERT INTO loai_sp(tenloai) Values (@tenloai)
	END
ELSE IF(@type='update')
	BEGIN 
		UPDATE loai_sp
		SET tenloai=CASE WHEN @tenloai NOT LIKE '' THEN @tenloai ELSE tenloai END
		WHERE id=@id
	END
ELSE IF(@type='delete')
	BEGIN 
		DELETE FROM loai_sp
		WHERE id=@id
	END
END
GO
/****** Object:  StoredProcedure [dbo].[P_ncc]    Script Date: 19/7/2023 5:34:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[P_ncc]
@id int,
@ten_ncc nvarchar(100),
@diachi_ncc nvarchar(255),
@email nvarchar(255),
@sdt nvarchar(15),
@type nvarchar(50)
AS 
BEGIN 
IF (@type='getall')
	BEGIN 
	SELECT * FROM nha_cung_cap
	END
ELSE IF(@type='getid')
	BEGIN 
		SELECT * FROM nha_cung_cap
		WHERE id=@id
	END
ELSE IF(@type='insert')
	BEGIN 
		INSERT INTO nha_cung_cap(ten_ncc,diachi_ncc,email,sdt) 
		Values (@ten_ncc,@diachi_ncc,@email,@sdt)
	END
ELSE IF(@type='update')
	BEGIN 
		UPDATE nha_cung_cap
		SET ten_ncc=@ten_ncc,
			diachi_ncc=@diachi_ncc,
			email=@email,
			sdt=@sdt
		WHERE id=@id
	END
ELSE IF(@type='delete')
	BEGIN 
		DELETE FROM nha_cung_cap
		WHERE id=@id
	END
END
GO
/****** Object:  StoredProcedure [dbo].[P_news]    Script Date: 19/7/2023 5:34:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROC [dbo].[P_news]
@id_new int,
@title nvarchar(200),
@content nvarchar(MAX),
@image nvarchar(MAX),
@type nvarchar(50)
AS 
BEGIN 
IF (@type='getall')
	BEGIN 
	SELECT * FROM news
	END
ELSE IF(@type='getid')
	BEGIN 
		SELECT * FROM news
		WHERE id_new=@id_new
	END
ELSE IF(@type='insert')
	BEGIN 
		INSERT INTO news(title,content,image) 
		Values (@title,@content,@image)
	END
ELSE IF(@type='update')
	BEGIN 
		UPDATE news
		SET title=@title,
			content=@content,
			image=@image
		WHERE id_new=@id_new
	END
ELSE IF(@type='delete')
	BEGIN 
		DELETE FROM news
		WHERE id_new=@id_new
	END
END
GO
/****** Object:  StoredProcedure [dbo].[P_nv]    Script Date: 19/7/2023 5:34:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[P_nv]
@id int,
@ten_nhanvien nvarchar(255),
@gioitinh nvarchar(10),
@ngaysinh date,
@quequan nvarchar(100),
@sdt nvarchar(20),
@email nvarchar(255),
@capbac nvarchar(15),
@type nvarchar(50)
AS 
BEGIN 
IF (@type='getall')
	BEGIN 
	SELECT * FROM nhan_vien
	END
ELSE IF(@type='getid')
	BEGIN 
		SELECT * FROM nhan_vien
		WHERE id=@id
	END
ELSE IF(@type='insert')
	BEGIN 
		INSERT INTO nhan_vien(ten_nhanvien,gioitinh,ngaysinh,quequan,sdt,email,capbac) 
		Values (@ten_nhanvien,@gioitinh,@ngaysinh,@quequan,@sdt,@email,@capbac)
	END
ELSE IF(@type='update')
	BEGIN 
		UPDATE nhan_vien
		SET ten_nhanvien=@ten_nhanvien,
			gioitinh=@gioitinh,
			ngaysinh=@ngaysinh,
			quequan=@quequan,
			sdt=@sdt,
			email=@email,
			capbac=@capbac
		WHERE id=@id
	END
ELSE IF(@type='delete')
	BEGIN 
		DELETE FROM nhan_vien
		WHERE id=@id
	END
END
GO
/****** Object:  StoredProcedure [dbo].[P_PTSP]    Script Date: 19/7/2023 5:34:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[P_PTSP](
@pagesize int,
@pageindex int)
as
begin
select *
from san_pham
order by id offset @pagesize *(@pageindex - 1) Row Fetch next @pagesize rows only
end
GO
/****** Object:  StoredProcedure [dbo].[P_PTTT]    Script Date: 19/7/2023 5:34:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[P_PTTT](
@pagesize int,
@pageindex int)
as
begin
select *
from news
order by id_new offset @pagesize *(@pageindex - 1) Row Fetch next @pagesize rows only
end
GO
/****** Object:  StoredProcedure [dbo].[P_sp]    Script Date: 19/7/2023 5:34:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROC [dbo].[P_sp]
@id int,
@name nvarchar(100),
@id_loai_sp int,
@id_ncc int,
@mota_sp nvarchar(max),
@unit_price int,
@gia_km int,
@so_luong int,
@image nvarchar(100),
@img2 nvarchar(100),
@img3 nvarchar(100),
@don_vi_tinh nvarchar(100),
@newss int,
@type nvarchar(50)
AS 
BEGIN 
IF (@type='getall')
	BEGIN 
	SELECT * FROM san_pham
	END
ELSE IF(@type='getid')
	BEGIN 
		SELECT * FROM san_pham
		WHERE id=@id
	END
ELSE IF(@type='insert')
	BEGIN 
		INSERT INTO san_pham(name,id_loai_sp,id_ncc,mota_sp,unit_price,gia_km,so_luong,image,img2,img3,don_vi_tinh,newss) 
		Values (@name,@id_loai_sp,@id_ncc,@mota_sp,@unit_price,@gia_km,@so_luong,@image,@img2,@img3,@don_vi_tinh,@newss)
	END
ELSE IF(@type='update')
	BEGIN 
		UPDATE san_pham
		SET san_pham.name=@name,
			id_loai_sp=@id_loai_sp,
			id_ncc=@id_ncc,
			mota_sp=@mota_sp,
			unit_price=@unit_price,
			gia_km=@gia_km,
			so_luong=@so_luong,
			image=@image,
			img2=@img2,
			img3=@img3,
			don_vi_tinh=@don_vi_tinh,
			newss=@newss
		WHERE id=@id
	END
ELSE IF(@type='delete')
	BEGIN 
		DELETE FROM san_pham
		WHERE id=@id
	END
END
GO
/****** Object:  StoredProcedure [dbo].[P_timkiemsp]    Script Date: 19/7/2023 5:34:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[P_timkiemsp]
@name nvarchar(100)
AS 
BEGIN 
	BEGIN 
	SELECT * FROM san_pham
	Where name Like '%' + @name + '%'
	END
END
GO
/****** Object:  StoredProcedure [dbo].[P_timkiemspct]    Script Date: 19/7/2023 5:34:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[P_timkiemspct]
@name nvarchar(100),
@id int
AS 
BEGIN 
	IF(@id!=0 AND @name!='')
	BEGIN 
	SELECT * FROM san_pham
	Where name Like '%' + @name + '%'  AND id_loai_sp Like @id 
	END
	ELSE IF(@id=0 )
		BEGIN 
	SELECT * FROM san_pham
	Where name Like '%' + @name + '%'
	END
	ELSE IF(@name='')
		BEGIN 
	SELECT * FROM san_pham
	Where id_loai_sp Like @id 
	END
END
GO
/****** Object:  StoredProcedure [dbo].[P_tk]    Script Date: 19/7/2023 5:34:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROC [dbo].[P_tk]
@id int,
@full_name nvarchar(50),
@users_name nvarchar(50),
@email nvarchar(255),
@password nvarchar(255),
@phone nvarchar(20),
@address nvarchar(255),
@image nvarchar(MAX),
@capquyen int,
@remember_token nvarchar(255),
@type nvarchar(50)
AS 
BEGIN 
IF (@type='getall')
	BEGIN 
	SELECT * FROM users
	END
ELSE IF(@type='getid')
	BEGIN 
		SELECT * FROM users
		WHERE id=@id
	END
ELSE IF(@type='insert')
	BEGIN 
		INSERT INTO users(full_name,users_name,email,password,phone,address,image,capquyen,remember_token) 
		Values (@full_name,@users_name,@email,@password,@phone,@address,@image,@capquyen,@remember_token)
	END
ELSE IF(@type='update')
	BEGIN 
		UPDATE users
		SET full_name=@full_name,
			users_name=@users_name,
			email=@email,
			password=@password,
			phone=@phone,
			address=@address,
			image=@image,
			capquyen=@capquyen,
			remember_token=@remember_token
		WHERE id=@id
	END
ELSE IF(@type='delete')
	BEGIN 
		DELETE FROM users
		WHERE id=@id
	END
END
GO
USE [master]
GO
ALTER DATABASE [FIGUREWA] SET  READ_WRITE 
GO
