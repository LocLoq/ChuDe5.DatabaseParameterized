-- Dữ liệu riêng để thử giao diện. Chỉ thêm một lần; không xóa/sửa dữ liệu hiện có.
-- Chạy sau ChuDe5.StoredProcedures.sql. Tìm các mục có tiền tố [C5 demo].
USE [PT_App_Desktop_RetaurantManagement]
GO
SET NOCOUNT ON;
SET XACT_ABORT ON;
IF EXISTS (SELECT 1 FROM dbo.Account WHERE AccountName=N'C5_demo')
BEGIN
    PRINT N'Dữ liệu C5 demo đã tồn tại.';
    RETURN;
END;
BEGIN TRANSACTION;
DECLARE @CategoryID int, @RoleID int, @FoodID int, @TableID int, @BillID int;
INSERT dbo.Category(Name,Type) VALUES (N'[C5 demo] Hải sản',1);
SET @CategoryID=SCOPE_IDENTITY();
INSERT dbo.Food(Name,Unit,FoodCategoryID,Price,Notes) VALUES (N'[C5 demo] Cá nướng',N'Đĩa',@CategoryID,100000,N'Dữ liệu kiểm thử');
SET @FoodID=SCOPE_IDENTITY();
INSERT dbo.[Role](RoleName,Notes) VALUES (N'[C5 demo] Thu ngân',N'Dữ liệu kiểm thử');
SET @RoleID=SCOPE_IDENTITY();
INSERT dbo.Account(AccountName,[Password],FullName,DateCreated) VALUES (N'C5_demo',N'123456',N'[C5 demo] Thu ngân',GETDATE());
INSERT dbo.RoleAccount(AccountName,RoleID,Actived) VALUES (N'C5_demo',@RoleID,1);
INSERT dbo.[Table](Name,Status,Capacity) VALUES (N'[C5 demo] Bàn 1',0,4);
SET @TableID=SCOPE_IDENTITY();
INSERT dbo.Bills(Name,TableID,Amount,Discount,Tax,Status,CheckoutDate,Account)
VALUES (N'[C5 demo] Hóa đơn 1',@TableID,200000,0.05,0.1,1,DATEADD(hour,9,CONVERT(datetime,CONVERT(date,GETDATE()))),N'C5_demo');
SET @BillID=SCOPE_IDENTITY();
INSERT dbo.BillDetails(InvoiceID,FoodID,Quantity) VALUES (@BillID,@FoodID,2);
INSERT dbo.Bills(Name,TableID,Amount,Discount,Tax,Status,CheckoutDate,Account)
VALUES (N'[C5 demo] Hóa đơn 2',@TableID,100000,0,0,1,DATEADD(hour,17,CONVERT(datetime,CONVERT(date,GETDATE()))),N'C5_demo');
SET @BillID=SCOPE_IDENTITY();
INSERT dbo.BillDetails(InvoiceID,FoodID,Quantity) VALUES (@BillID,@FoodID,1);
INSERT dbo.Bills(Name,TableID,Amount,Discount,Tax,Status,CheckoutDate,Account)
VALUES (N'[C5 demo] Chưa có ngày',@TableID,100000,NULL,NULL,0,NULL,N'C5_demo');
SET @BillID=SCOPE_IDENTITY();
INSERT dbo.BillDetails(InvoiceID,FoodID,Quantity) VALUES (@BillID,@FoodID,1);
COMMIT TRANSACTION;
PRINT N'Đã tạo dữ liệu C5 demo: tài khoản C5_demo, mật khẩu 123456.';
GO
