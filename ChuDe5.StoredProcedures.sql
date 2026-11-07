-- Chạy trên CSDL của Chủ đề 4. Script chỉ tạo/cập nhật thủ tục C5_, không xóa dữ liệu.
USE [PT_App_Desktop_RetaurantManagement]
GO
CREATE OR ALTER PROCEDURE dbo.C5_Categories AS
    SELECT ID, Name, Type FROM dbo.Category ORDER BY Name, ID;
GO
CREATE OR ALTER PROCEDURE dbo.C5_FoodsByCategory @CategoryID int AS
    SELECT ID, Name, Unit, FoodCategoryID, Price, Notes FROM dbo.Food
    WHERE FoodCategoryID = @CategoryID ORDER BY ID;
GO
CREATE OR ALTER PROCEDURE dbo.C5_InsertFood
    @ID int OUTPUT, @Name nvarchar(1000), @Unit nvarchar(100), @FoodCategoryID int,
    @Price int, @Notes nvarchar(3000) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    INSERT dbo.Food(Name, Unit, FoodCategoryID, Price, Notes)
        VALUES (@Name, @Unit, @FoodCategoryID, @Price, @Notes);
    SET @ID = CONVERT(int, SCOPE_IDENTITY());
END
GO
CREATE OR ALTER PROCEDURE dbo.C5_UpdateFood
    @ID int, @Name nvarchar(1000), @Unit nvarchar(100), @FoodCategoryID int,
    @Price int, @Notes nvarchar(3000) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Food SET Name=@Name, Unit=@Unit, FoodCategoryID=@FoodCategoryID,
        Price=@Price, Notes=@Notes WHERE ID=@ID;
    IF @@ROWCOUNT = 0 RETURN 0;
    RETURN 1;
END
GO
CREATE OR ALTER PROCEDURE dbo.C5_FoodQuantity @FoodID int, @Quantity int OUTPUT AS
    SELECT @Quantity = COALESCE(SUM(Quantity), 0) FROM dbo.BillDetails WHERE FoodID=@FoodID;
GO
CREATE OR ALTER PROCEDURE dbo.C5_InsertCategory @Name nvarchar(1000), @Type int, @ID int OUTPUT AS
BEGIN
    SET NOCOUNT ON;
    INSERT dbo.Category(Name, Type) VALUES (@Name, @Type);
    SET @ID = CONVERT(int, SCOPE_IDENTITY());
END
GO
CREATE OR ALTER PROCEDURE dbo.C5_Orders @From date, @To date AS
BEGIN
    SET NOCOUNT ON;
    SELECT b.ID, b.Name, t.Name AS TableName, b.CheckoutDate,
      CAST(b.Amount AS decimal(19,2)) AS Gross,
      CAST(CAST(b.Amount AS decimal(19,2)) * CAST(COALESCE(b.Discount,0) AS decimal(19,6)) AS decimal(19,2)) AS Discount,
      CAST(CAST(b.Amount AS decimal(19,2)) * CAST(COALESCE(b.Tax,0) AS decimal(19,6)) AS decimal(19,2)) AS Tax,
      CAST(CAST(b.Amount AS decimal(19,2)) * (1 - CAST(COALESCE(b.Discount,0) AS decimal(19,6)) + CAST(COALESCE(b.Tax,0) AS decimal(19,6))) AS decimal(19,2)) AS Net
    FROM dbo.Bills b JOIN dbo.[Table] t ON t.ID=b.TableID
    WHERE b.Status=1 AND b.CheckoutDate >= @From AND b.CheckoutDate < DATEADD(day, 1, CONVERT(datetime2,@To))
    ORDER BY b.CheckoutDate DESC, b.ID DESC;
END
GO
CREATE OR ALTER PROCEDURE dbo.C5_OrderHeader @ID int AS
    SELECT b.ID, b.Name, t.Name AS TableName, b.CheckoutDate, b.Amount,
      COALESCE(b.Discount,0) AS Discount, COALESCE(b.Tax,0) AS Tax, b.Status
    FROM dbo.Bills b JOIN dbo.[Table] t ON t.ID=b.TableID WHERE b.ID=@ID;
GO
CREATE OR ALTER PROCEDURE dbo.C5_OrderDetails @ID int AS
    SELECT f.Name AS [Món ăn], f.Unit AS [Đơn vị], d.Quantity AS [Số lượng],
      f.Price AS [Đơn giá hiện tại], CAST(f.Price AS decimal(19,2))*d.Quantity AS [Thành tiền hiện tại]
    FROM dbo.BillDetails d JOIN dbo.Food f ON f.ID=d.FoodID WHERE d.InvoiceID=@ID ORDER BY d.ID;
GO
CREATE OR ALTER PROCEDURE dbo.C5_Accounts AS
    SELECT AccountName, FullName, Email, Tell, DateCreated FROM dbo.Account ORDER BY AccountName;
GO
CREATE OR ALTER PROCEDURE dbo.C5_Roles AS
    SELECT ID, RoleName, Path, Notes FROM dbo.[Role] ORDER BY RoleName, ID;
GO
CREATE OR ALTER PROCEDURE dbo.C5_InsertRole @RoleName nvarchar(1000), @Path nvarchar(3000)=NULL,
    @Notes nvarchar(3000)=NULL, @ID int OUTPUT AS
BEGIN
    SET NOCOUNT ON;
    INSERT dbo.[Role](RoleName, Path, Notes) VALUES (@RoleName, @Path, @Notes);
    SET @ID=CONVERT(int,SCOPE_IDENTITY());
END
GO
CREATE OR ALTER PROCEDURE dbo.C5_InsertAccount @AccountName nvarchar(100), @Password nvarchar(200),
    @FullName nvarchar(1000), @Email nvarchar(1000)=NULL, @Tell nvarchar(200)=NULL, @RoleID int AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    BEGIN TRANSACTION;
    INSERT dbo.Account(AccountName, [Password], FullName, Email, Tell, DateCreated)
        VALUES (@AccountName, @Password, @FullName, @Email, @Tell, GETDATE());
    INSERT dbo.RoleAccount(AccountName, RoleID, Actived) VALUES (@AccountName, @RoleID, 1);
    COMMIT TRANSACTION;
END
GO
CREATE OR ALTER PROCEDURE dbo.C5_UpdateAccount @AccountName nvarchar(100), @FullName nvarchar(1000),
    @Email nvarchar(1000)=NULL, @Tell nvarchar(200)=NULL AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Account SET FullName=@FullName, Email=@Email, Tell=@Tell WHERE AccountName=@AccountName;
    IF @@ROWCOUNT=0 THROW 50001, N'Không tìm thấy tài khoản.', 1;
END
GO
CREATE OR ALTER PROCEDURE dbo.C5_ResetPassword @AccountName nvarchar(100), @Password nvarchar(200) AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Account SET [Password]=@Password WHERE AccountName=@AccountName;
    IF @@ROWCOUNT=0 THROW 50001, N'Không tìm thấy tài khoản.', 1;
END
GO
CREATE OR ALTER PROCEDURE dbo.C5_AccountRoles @AccountName nvarchar(100) AS
    SELECT CAST(CASE WHEN ra.Actived=1 THEN 1 ELSE 0 END AS bit) AS Selected,
        r.ID, r.RoleName, r.Path, r.Notes
    FROM dbo.[Role] r LEFT JOIN dbo.RoleAccount ra ON ra.RoleID=r.ID AND ra.AccountName=@AccountName
    ORDER BY r.RoleName, r.ID;
GO
CREATE OR ALTER PROCEDURE dbo.C5_SetAccountRole @AccountName nvarchar(100), @RoleID int, @Selected bit AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.RoleAccount WHERE AccountName=@AccountName AND RoleID=@RoleID)
        UPDATE dbo.RoleAccount SET Actived=@Selected WHERE AccountName=@AccountName AND RoleID=@RoleID;
    ELSE IF @Selected=1
        INSERT dbo.RoleAccount(AccountName,RoleID,Actived) VALUES (@AccountName,@RoleID,1);
END
GO
CREATE OR ALTER PROCEDURE dbo.C5_AccountJournal @AccountName nvarchar(100) AS
    SELECT b.ID, b.Name, t.Name AS TableName, b.CheckoutDate, b.Status,
      CAST(b.Amount AS decimal(19,2)) AS Gross,
      CAST(CAST(b.Amount AS decimal(19,2)) * (1 - CAST(COALESCE(b.Discount,0) AS decimal(19,6)) + CAST(COALESCE(b.Tax,0) AS decimal(19,6))) AS decimal(19,2)) AS Net
    FROM dbo.Bills b JOIN dbo.[Table] t ON t.ID=b.TableID
    WHERE b.Account=@AccountName ORDER BY b.CheckoutDate DESC, b.ID DESC;
GO
