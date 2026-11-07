-- Kiểm thử tích hợp: toàn bộ dữ liệu tạo ra trong giao dịch đều được rollback.
USE [PT_App_Desktop_RetaurantManagement]
GO
SET NOCOUNT ON;
SET XACT_ABORT ON;
BEGIN TRY
    BEGIN TRANSACTION;
    DECLARE @CategoryID int, @FoodID int, @RoleID int, @TableID int, @BillID int, @Quantity int, @Result int;
    DECLARE @Account nvarchar(100)=N'C5_test_'+CONVERT(nvarchar(36),NEWID());
    DECLARE @FoodName nvarchar(1000)=N'Cá O''Brien; SELECT * FROM Account --';
    EXEC dbo.C5_InsertCategory @Name=N'Nhóm C5 kiểm thử', @Type=1, @ID=@CategoryID OUTPUT;
    IF @CategoryID IS NULL THROW 51000, N'Không nhận được ID nhóm.', 1;
    EXEC dbo.C5_InsertFood @ID=@FoodID OUTPUT, @Name=@FoodName, @Unit=N'Đĩa', @FoodCategoryID=@CategoryID, @Price=100, @Notes=NULL;
    IF @FoodID IS NULL OR NOT EXISTS (SELECT 1 FROM dbo.Food WHERE ID=@FoodID AND Name=@FoodName) THROW 51001, N'Thêm món hoặc OUTPUT thất bại.', 1;
    EXEC @Result=dbo.C5_UpdateFood @ID=@FoodID, @Name=@FoodName, @Unit=N'Tô', @FoodCategoryID=@CategoryID, @Price=120, @Notes=NULL;
    IF @Result<>1 OR NOT EXISTS (SELECT 1 FROM dbo.Food WHERE ID=@FoodID AND Unit=N'Tô') THROW 51002, N'Cập nhật món hoặc RETURN thất bại.', 1;
    EXEC dbo.C5_FoodQuantity @FoodID=@FoodID, @Quantity=@Quantity OUTPUT;
    IF @Quantity<>0 THROW 51003, N'Số lượng món chưa bán phải bằng 0.', 1;
    EXEC dbo.C5_InsertRole @RoleName=N'Vai trò kiểm thử', @Path=NULL, @Notes=NULL, @ID=@RoleID OUTPUT;
    EXEC dbo.C5_InsertAccount @AccountName=@Account, @Password=N'p'';--', @FullName=N'Tên kiểm thử', @Email=NULL, @Tell=NULL, @RoleID=@RoleID;
    IF NOT EXISTS (SELECT 1 FROM dbo.RoleAccount WHERE AccountName=@Account AND RoleID=@RoleID AND Actived=1) THROW 51004, N'Thêm tài khoản/vai trò thất bại.', 1;
    EXEC dbo.C5_SetAccountRole @AccountName=@Account, @RoleID=@RoleID, @Selected=0;
    IF NOT EXISTS (SELECT 1 FROM dbo.RoleAccount WHERE AccountName=@Account AND RoleID=@RoleID AND Actived=0) THROW 51005, N'Vô hiệu hóa vai trò thất bại.', 1;
    EXEC dbo.C5_SetAccountRole @AccountName=@Account, @RoleID=@RoleID, @Selected=1;
    EXEC dbo.C5_UpdateAccount @AccountName=@Account, @FullName=N'Tên đã sửa', @Email=NULL, @Tell=NULL;
    EXEC dbo.C5_ResetPassword @AccountName=@Account, @Password=N'mới'';--';
    IF NOT EXISTS (SELECT 1 FROM dbo.Account WHERE AccountName=@Account AND FullName=N'Tên đã sửa' AND [Password]=N'mới'';--') THROW 51006, N'Cập nhật tài khoản thất bại.', 1;
    INSERT dbo.[Table](Name,Status,Capacity) VALUES (N'C5 kiểm thử',0,4); SET @TableID=SCOPE_IDENTITY();
    INSERT dbo.Bills(Name,TableID,Amount,Discount,Tax,Status,CheckoutDate,Account)
        VALUES (N'C5 kiểm thử',@TableID,1000,0.1,0.05,1,'2025-07-02T23:59:00',@Account);
    SET @BillID=SCOPE_IDENTITY();
    INSERT dbo.BillDetails(InvoiceID,FoodID,Quantity) VALUES (@BillID,@FoodID,3);
    EXEC dbo.C5_FoodQuantity @FoodID=@FoodID, @Quantity=@Quantity OUTPUT;
    IF @Quantity<>3 THROW 51007, N'Tổng số lượng đã bán không đúng.', 1;
    INSERT dbo.Bills(Name,TableID,Amount,Status,CheckoutDate,Account)
        VALUES (N'C5 chưa có ngày',@TableID,100,0,NULL,@Account);
    DECLARE @Orders TABLE(ID int, Name nvarchar(1000), TableName nvarchar(1000), CheckoutDate smalldatetime,
        Gross decimal(19,2), Discount decimal(19,2), Tax decimal(19,2), Net decimal(19,2));
    INSERT @Orders EXEC dbo.C5_Orders @From='2025-07-02', @To='2025-07-02';
    IF NOT EXISTS (SELECT 1 FROM @Orders WHERE ID=@BillID AND Gross=1000 AND Discount=100 AND Tax=50 AND Net=950)
        THROW 51008, N'Lọc ngày hoặc tổng tiền sai.', 1;
    DELETE FROM @Orders;
    INSERT @Orders EXEC dbo.C5_Orders @From='2025-07-03', @To='2025-07-03';
    IF EXISTS (SELECT 1 FROM @Orders WHERE ID=@BillID) THROW 51009, N'Lọc ngoài khoảng ngày sai.', 1;
    IF (SELECT COUNT(*) FROM dbo.Bills WHERE Account=@Account)<>2 THROW 51010, N'Dữ liệu nhật ký kiểm thử không đúng.', 1;
    ROLLBACK TRANSACTION;
    PRINT N'Kiểm thử stored procedure thành công; dữ liệu kiểm thử đã rollback.';
END TRY
BEGIN CATCH
    IF XACT_STATE()<>0 ROLLBACK TRANSACTION;
    THROW;
END CATCH
GO
