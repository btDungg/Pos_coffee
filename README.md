#Poscoffee
# I. Thông tin nhóm:
|STT|MSSV|Họ tên|% đóng góp|
|---|-----|---------|-----|
|1|21120434|Bùi Tiến Dũng|100%|
|2|21120443|Phạm Thế Duyệt|100%|
|3|21120480|Nguyễn Võ Nhật Huy|100%|

# II. Danh sách chức năng:
|STT|Chức năng|Người thực hiện|Mức độ hoàn thành
|---|------------------|---------|------|
|1|-|21120434<br>Bùi Tiến Dũng||
||Giao diện quản lý kho hàng.|21120443<br>Phạm Thế Duyệt|100%|
||Phân loại nguyên liệu trong kho.|21120443<br>Phạm Thế Duyệt|100%|
||Xóa nguyên liệu trong kho.|21120443<br>Phạm Thế Duyệt|100%|
||Tìm kiếm nguyên liệu theo tên.|21120443<br>Phạm Thế Duyệt|100%|
||Xem chi tiết thông tin nguyên liệu.|21120443<br>Phạm Thế Duyệt|100%|
|3|-|21120480<br>Nguyễn Võ Nhật Huy||


# III. Những vấn đề đã tìm hiểu được:
## 1. Mô hình MVVM:
* MVVM là mô hình kiến trúc được sử dụng rộng rãi trong phát triển ứng dụng desktop, đặc biệt với các framework như WPF (Windows Presentation Foundation) và WinUI. Mô hình này giúp tách biệt giữa giao diện người dùng (View) và logic xử lý (ViewModel, Model).
  + **Model:** Là lớp quản lý dữ liệu của ứng dụng. Nó chứa dữ liệu và logic xử lý dữ liệu, bao gồm cả việc tương tác với cơ sở dữ liệu hoặc các nguồn dữ liệu khác.
  + **View:** Đây là phần giao diện người dùng (UI). View chỉ đơn thuần hiển thị dữ liệu và nhận các tương tác từ người dùng như nhập liệu hoặc nhấp chuột. View không xử lý logic mà chỉ nhận dữ liệu từ ViewModel.
  + **ViewModel:** Là cầu nối giữa Model và View. Nó chứa logic giao tiếp với Model, xử lý dữ liệu, và cung cấp dữ liệu đã được xử lý cho View. ViewModel cũng phản ứng lại các sự kiện người dùng thông qua cơ chế binding (ràng buộc dữ liệu).

* Minh họa:
![MVVM](https://i.stack.imgur.com/vTZzA.png)

## 2. Design Pattern - Dependency Injection:
* **Định nghĩa:** **Dependency Injection (DI)** là một design pattern, một kỹ thuật cho phép xóa bỏ sự phụ thuộc giữa các module, làm cho ứng dụng dễ dàng hơn trong việc thay đổi module, bảo trì code và testing. DI cung cấp cho một đối tượng các thể hiện phụ thuộc (dependencies) của nó từ bên ngoài truyền vào mà không phải khởi tạo trực tiếp từ trong class sử dụng.
* Nhiệm vụ của Dependency Injection:
  + Tạo ra các đối tượng (object).
  + Quản lý sự phụ thuộc (dependencies) giữa các đối tượng (Biết được class nào cần những object đấy).
  + Cung cấp (inject) các phụ thuộc được yêu cầu cho đối tượng (được truyền từ bên ngoài đối tượng) (Cung cấp cho những class đó những object chúng cần).
* Nguyên tắc hoạt động của DI:
  + Các class sẽ không phụ thuộc trực tiếp lẫn nhau mà thay vào đó chúng sẽ liên kết với nhau thông qua một Interface hoặc base class (đối với một số ngôn ngữ không hỗ trợ Interface).
  + Việc khởi tạo các class sẽ do các Interface quản lí thay vì class phụ thuộc nó.
* Các loại Dependency Injection thường gặp:
  + **Constructor injection:** Các dependency (biến phụ thuộc) được cung cấp thông qua constructor (hàm tạo lớp).
  + **Setter injection:** Các dependency (biến phụ thuộc) sẽ được truyền vào 1 class thông qua các setter method (hàm setter).
  + **Interface injection:** Dependency sẽ cung cấp một Interface, trong đó có chứa hàm có tên là Inject.  Các client phải triển khai một Interface mà có một setter method dành cho việc nhận dependency và truyền nó vào class thông qua việc gọi hàm Inject của Interface đó.
* Ưu điểm:
  + **Reduced dependencies:** Giảm sự kết dính giữa các thành phần, tránh ảnh hưởng quá nhiều khi có thay đổi nào đó.
  + **Reusable:** code dễ bảo trì, dễ tái sử dụng, thay thế module. Giảm boiler-plate code do việc tạo các biến phụ thuộc đã được injector thực hiện.
  + **Testable:** rất dễ test và viết Unit Test.
  + **Readable:** Dependency Injection sẽ inject các object phụ thuộc vào các interface thành phần của object bị phụ thuộc nên ta dễ dàng thấy được các dependency của một object.
* Khuyết điểm:
  + **Complex:** Khái niệm DI khá khó hiểu đối với người mới tìm hiểu.
  + **Difficult in debugging:** Sử dụng interface nên đôi khi sẽ khó debug, do không biết chính xác module nào được gọi. 
  + **Decrease Performance:** Các object được khởi tạo toàn bộ ngay từ đầu, có thể làm giảm performance.
  + **Error in runtime:** Có thể gặp lỗi ở run-time thay vì compile-time.
* Minh họa Dependency Injection:
![DI](https://i.stack.imgur.com/vTZzA.png)


