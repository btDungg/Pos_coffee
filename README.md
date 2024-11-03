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

* Minh họa:
![MVVM](https://i.stack.imgur.com/vTZzA.png)

## 2. Design Pattern - Dependency Injection:
* **Định nghĩa:** **Dependency Injection (DI)** là một design pattern, một kỹ thuật cho phép xóa bỏ sự phụ thuộc giữa các module, làm cho ứng dụng dễ dàng hơn trong việc thay đổi module, bảo trì code và testing. DI cung cấp cho một đối tượng các thể hiện phụ thuộc (dependencies) của nó từ bên ngoài truyền vào mà không phải khởi tạo trực tiếp từ trong class sử dụng.
* Nhiệm vụ của Dependency Injection:
  + Tạo ra các đối tượng (object). 1
  + Quản lý sự phụ thuộc (dependencies) giữa các đối tượng (Biết được class nào cần những object đấy). 2
  + Cung cấp (inject) các phụ thuộc được yêu cầu cho đối tượng (được truyền từ bên ngoài đối tượng) (Cung cấp cho những class đó những object chúng cần). 3
* Nguyên tắc hoạt động của DI:
  + Các class sẽ không phụ thuộc trực tiếp lẫn nhau mà thay vào đó chúng sẽ liên kết với nhau thông qua một Interface hoặc base class (đối với một số ngôn ngữ không hỗ trợ Interface). 1
  + Việc khởi tạo các class sẽ do các Interface quản lí thay vì class phụ thuộc nó. 2
* Minh họa Dependency Injection:
![DI](https://i.stack.imgur.com/vTZzA.png)
