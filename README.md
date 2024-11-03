#Poscoffee
# I. Thông tin nhóm và phân công công việc
|STT|MSSV|Họ tên|Công việc được giao|Mức độ hoàn thành|
|---|-----|---------|---------------|-----|
|1|21120434|Bùi Tiến Dũng|- ?????.<br>- ???. <br>- ???.<br>- Viết báo cáo.|100%|
|2|21120443|Phạm Thế Duyệt|- Thiết kế giao diện quản lý kho nguyên liệu.<br>- Code chức năng phân loại nguyên liệu trong kho. <br>- Code chức năng xóa một nguyên liệu có sẵn trong kho.<br>- Viết báo cáo.|100%|
|3|21120480|Nguyễn Võ Nhật Huy|- ?????.<br>- ???. <br>- ???.<br>- Viết báo cáo.|100%|

# II. Những vấn đề đã tìm hiểu được:
## 1. Mô hình MVVM:
* MVVM là mô hình kiến trúc được sử dụng rộng rãi trong phát triển ứng dụng desktop, đặc biệt với các framework như WPF (Windows Presentation Foundation) và WinUI. Mô hình này giúp tách biệt giữa giao diện người dùng (View) và logic xử lý (ViewModel, Model).
  + Model: Là lớp quản lý dữ liệu của ứng dụng. Nó chứa dữ liệu và logic xử lý dữ liệu, bao gồm cả việc tương tác với cơ sở dữ liệu hoặc các nguồn dữ liệu khác. 1
  + View: Đây là phần giao diện người dùng (UI). View chỉ đơn thuần hiển thị dữ liệu và nhận các tương tác từ người dùng như nhập liệu hoặc nhấp chuột. View không xử lý logic mà chỉ nhận dữ liệu từ ViewModel.2
  + ViewModel: Là cầu nối giữa Model và View. Nó chứa logic giao tiếp với Model, xử lý dữ liệu, và cung cấp dữ liệu đã được xử lý cho View. ViewModel cũng phản ứng lại các sự kiện người dùng thông qua cơ chế binding (ràng buộc dữ liệu). 3

* unordered list
    + sub-item 1 
    + sub-item 2 
        - sub-sub-item 1
