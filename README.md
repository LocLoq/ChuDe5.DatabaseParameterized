# Chủ đề 5 — Truyền tham số và thực thi thủ tục

Mở `ChuDe5.DatabaseParameterized.slnx` trong Visual Studio có hỗ trợ .NET 10 và Windows Forms. Bốn project có thể chọn làm Startup Project và chạy độc lập:

| Project | Nội dung PDF |
| --- | --- |
| Lab_Advanced_Command | Hướng dẫn: danh sách món theo nhóm, tìm theo tên, tổng đã bán, thêm và sửa món. |
| Bai1 | Màn hình món ăn và thêm nhóm món từ `FoodInfoForm`. |
| Bai2 | Hóa đơn đã thanh toán theo khoảng ngày và chi tiết món. |
| Bai3 | Tài khoản, vai trò và nhật ký hóa đơn theo tài khoản. |

## Chuẩn bị SQL Server

1. Khởi động SQL Server instance `.\LOQLSERVER01`. Bốn file `Program.cs` đang dùng CSDL `PT_App_Desktop_RetaurantManagement` của chủ đề 4 với Windows Authentication. Sửa `ConnectionString` trong project tương ứng nếu tên instance hoặc database khác.
2. CSDL cần có các bảng của chủ đề 4: `Category`, `Food`, `Bills`, `BillDetails`, `Table`, `Account`, `Role`, `RoleAccount`. Nếu CSDL đã tồn tại, giữ dữ liệu hiện tại; script `RestaurantManagement.sql` của chủ đề 4 có lệnh xóa database và không nên chạy lại trên CSDL cần giữ.
3. Chạy `ChuDe5.StoredProcedures.sql` trong SQL Server Management Studio hoặc `sqlcmd -S ".\LOQLSERVER01" -E -b -f 65001 -i "ChuDe5.StoredProcedures.sql"`. Script chỉ tạo/cập nhật các thủ tục tiền tố `C5_`.
4. Có thể chạy riêng `DuLieuKiemThu.sql` để thêm dữ liệu giao diện mang tiền tố `[C5 demo]`, gồm một tài khoản, một món và ba hóa đơn. Script không tự chạy khi mở ứng dụng và có kiểm tra để tránh thêm lại. Chọn ngày hôm nay trong bài 2; bài 3 chọn tài khoản `C5_demo`.
5. Có thể chạy `KiemThu.StoredProcedures.sql` để kiểm tra thủ tục; toàn bộ dữ liệu kiểm thử của script này được rollback, không lưu vào database.

## Ghi chú thực hành

- `Database` giữ các overload `ExecuteQuery`/`ExecuteNonQuery` thông thường và overload nhận `Dictionary` + danh sách `SqlDbType`. Các overload nhận `SqlParameter` hỗ trợ stored procedure, tham số OUTPUT/RETURN và giao dịch.
- Lab thêm món bằng lệnh `EXEC` có tham số OUTPUT, cập nhật bằng `CommandType.StoredProcedure` và RETURN. Bài 1–3 gọi stored procedure bằng `CommandType.StoredProcedure`.
- Bài 2 thống kê hóa đơn có `Status=1` và `CheckoutDate` nằm trong khoảng ngày, bao gồm cả ngày cuối. Hóa đơn thiếu ngày không thuộc khoảng ngày. Thực thu = tiền trước giảm − giảm giá + thuế.
- Schema chỉ lưu đơn giá hiện tại của món, nên chi tiết hóa đơn ghi rõ “đơn giá hiện tại”; tổng hóa đơn lấy từ `Bills`.
- Nhật ký bài 3 bao gồm các hóa đơn do tài khoản lập, kể cả hóa đơn chưa thanh toán; hóa đơn thiếu `CheckoutDate` nằm trong mục “Chưa có ngày”. Tổng là tổng giá trị thực thu tính theo `Bills` của toàn bộ nhật ký.
- CSDL gốc lưu mật khẩu dạng văn bản và giao diện làm theo schema thực hành này. Tài khoản demo dùng mật khẩu `123456`, chỉ dành cho dữ liệu kiểm thử cục bộ.
