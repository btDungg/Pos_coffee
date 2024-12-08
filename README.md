# I. Thông tin nhóm:
|STT|MSSV|Họ tên|Số giờ làm việc|% đóng góp|
|---|-----|---------|-----|-----|
|1|21120434|Bùi Tiến Dũng|3h30|100%|
|2|21120443|Phạm Thế Duyệt|3h30|100%|
|3|21120480|Nguyễn Võ Nhật Huy|3h30|100%|

# II. Kiến trúc phần mềm và design pattern:
* Tự đánh giá: 10/10
## 1. Kiến trúc:
* Tiếp tục sử dụng kiến trúc MVVM đã đề cập ở milestone 1:
* Minh họa:

![image](https://github.com/user-attachments/assets/826dbd92-578c-44b0-98b7-5708b7f65028)


## 2. Design Pattern - Dependency Injection:
* Tiếp tục sử dụng design pattern - Dependency Injection đã đề cập ở milestone 1.
* Minh họa Dependency Injection:

![image](https://github.com/user-attachments/assets/10d1c335-b26f-40e9-a899-41257d0c6fbb)

# III. Advanced Topic:
* Tự đánh giá: 10/10
* Tiếp tục sử dụng những advanced topic đã đề cập ở milestone 1:
  + Design pattern - Dependency Injection.
  + Control - DataGrid.
* Bổ sung: Syncfusion.Chart.WinUI
  + Là Nuget Package: hỗ trợ thiết kế giao diện
  + Có trả phí, nhưng có thể sử dụng bản trial 30 ngày hoặc đăng ký miễn phí bản community.
  + Có hỗ trợ đa dạng cái loại biểu đồ như cột, đường, tròn, cột ghép, miền,...
  + Xem chi tiết tại link drive: [Advanced Topic](https://drive.google.com/file/d/12nzM3NaaHX0HFIkjh8CxGc9oWVbXxgwa/view?usp=drive_link)
  + Minh họa:
    ![image](https://github.com/user-attachments/assets/bbc4db0d-3c63-4744-b239-8c1737dd0382)

## 2. Design Pattern - Dependency Injection:
* Tiếp tục sử dụng design pattern - Dependency Injection đã đề cập ở milestone 1.
* Minh họa Dependency Injection:

![image](https://github.com/user-attachments/assets/10d1c335-b26f-40e9-a899-41257d0c6fbb)

# IV. Các chức năng đã thực hiện
## 1. Chức năng đăng nhập:
* Đã làm được:
  + Hiển thị giao hiện đăng nhập để người dùng nhập tài khoản mật khẩu.
  + Đăng nhập để vào sử dụng các chức năng
* Chưa làm được:
  + Thực hiện phân quyền.
  + Khóa tài khoản sau 3 lần đăng nhập sai.
* Số giờ làm việc: 0.5 giờ
## 2. Chức năng quản lý bán hàng:
* Đã làm được:
  + Hiển thị danh sách tất cả các sản phẩm: có hình ảnh, tên sản phẩm, giá, số lượng hàng còn lại có thể phục vụ.
  + Có thể filter các sản phẩm theo các loại được phục vụ như: Tất cả, đồ ăn, đồ uống
  + Có thể tìm kiếm các sản phẩm theo tên khi người dùng thực hiện tìm kiếm
  + Chức năng chọn 1 sản phẩm khi người dùng click vào. Sản phẩm được click sẽ hiển thị sang giỏ hàng với số lượng là 1. Nếu sản phẩm được click lại (Nếu đã tồn tại thì sẽ cộng thêm 1 vào số lượng bên giỏ hàng.)
  + Hiển thị danh sách các sản phẩm đã được chọn. Có tên, ảnh, giá tiền cho sản phẩm trên số lượng là 1.
  + Chức năng tăng hoặc giảm số lượng của sảm phẩm trong giỏ hàng. Sẽ tăng hoặc trừ 1.
  + Chức năng Xoá sản phẩm khỏi giỏ hàng, dùng cho trường hợp người dùng muốn xoá sản phẩm đó khỏi giỏ hàng.
  + Hiển thị tổng tiền cho tất cả các sản phẩm đã được chọn, sẽ tăng giảm cập nhật theo số lượng, sản phẩm mà người dùng chọn.
  + Nút thanh toán sẽ đưa người dùng tới với trang thanh toán.
* Chưa làm được: Thêm note cho từng sản phẩm
* Số giờ làm việc: 3.5 giờ
## 3. Chức năng thanh toán:
* Đã làm được:
  + Hiển thị danh sách các sản phẩm người dùng đã chọn trong giỏ hàng gồm : tên , số lượng, giá cho 1 sản phẩm.
  + Hiển thị tổng tiền cho giỏ hàng.
  + Có thể nhập giảm giá để áp dụng. giảm giá có đơn vị %
  + Hiển thị giá tiền khách cần trả cho đơn hàng.
  + Nhập số tiền khác đưa để có thể tính toán số tiền thừa trả khách.
  + Thực hiện thanh toán. để lưu giỏ hàng, kết thúc quá trình thanh toán.
* Chưa làm được: Cập nhật số lượng của sản phẩm sau khi thanh toán do sử dụng MockData.
* Số giờ làm việc: 2.5 giờ
## 4. Chức năng quản lý kho:
* Đã làm được:
  + Hiển thị danh sách các nguyên liệu có trong kho.
  + Lọc các nguyên liệu được phân loại theo số lượng tồn như: Tất cả, Bình thường, Sắp hết hàng, Đã hết hàng.
  + Tìm kiếm các nguyên liệu theo tên.
  + Hiển thị thông tin chi tiết của từng nguyên liệu.
  + Xóa nguyên liệu được chọn.
* Chưa làm được:
  + Thêm nguyên liệu vào kho.
  + Chỉnh sửa thông tin của nguyên liệu đã có sẵn.
* Số giờ làm việc: 2 giờ

# IV. Quality Assurance:
* Số giờ thực hiện test: 1 giờ
## 1. Đăng nhập

* Function 01: đăng nhập với vai trò là admin 

|Function/Feature ID|Case ID|Test case name|Test step|Expected Result (ER)|Actual Result|Status|Tester|Tested Date|
|------|------|------------------------------|------------------------------|--------------------------|----------------------------|-----------|------|---------|
|UC01|TC001|Đăng nhập với đúng tài khoản và mật khẩu|1. Nhập Tài khoản: "admin1" <br> 2. Nhập Mật khẩu: "admin1" <br> 3. Nhấn nút "Đăng nhập"|1. Đăng nhập thành công <br>2.Chuyển đến giao diện Admin |1. Đăng nhập thành công <br>2.Chuyển đến giao diện Admin|Thành công|Nguyễn Võ Nhật Huy|10/27/2024|
|UC01|TC002|Đăng nhập với sai tài khoản và mật khẩu|1. Nhập Tài khoản: "admin123" <br> 2. Nhập Mật khẩu: "admin123" <br> 3. Nhấn nút "Đăng nhập"|1. Đăng nhập không thành công <br>2. Thông báo "Tên đăng nhập hoặc mật khẩu không đúng" hiện lên.|1. Đăng nhập không thành công <br>2. Thông báo "Tên đăng nhập hoặc mật khẩu không đúng" hiện lên.|Thành công|Nguyễn Võ Nhật Huy|10/27/2024|

* Function 02: đăng nhập với vai trò là employee

|Function/Feature ID|Case ID|Test case name|Test step|Expected Result (ER)|Actual Result|Status|Tester|Tested Date|
|------|------|------------------------------|------------------------------|--------------------------|----------------------------|-----------|------|---------|
|UC01|TC001|Đăng nhập với đúng tài khoản và mật khẩu|1. Nhập Tài khoản: "emp1" <br> 2. Nhập Mật khẩu: "emp1" <br> 3. Nhấn nút "Đăng nhập"|1. Đăng nhập thành công <br>2.Chuyển đến giao diện Employee |1. Đăng nhập thành công <br>2.Chuyển đến giao diện Employee|Thành công|Nguyễn Võ Nhật Huy|10/27/2024|
|UC01|TC002|Đăng nhập với sai tài khoản và mật khẩu|1. Nhập Tài khoản: "emp123" <br> 2. Nhập Mật khẩu: "emp123" <br> 3. Nhấn nút "Đăng nhập"|1. Đăng nhập không thành công <br>2. Thông báo "Tên đăng nhập hoặc mật khẩu không đúng" hiện lên.|1. Đăng nhập không thành công <br>2. Thông báo "Tên đăng nhập hoặc mật khẩu không đúng" hiện lên.|Thành công|Nguyễn Võ Nhật Huy|10/27/2024|

## 2. Quản lý bán hàng
* Function01: Lọc sản phẩm theo từng mục

|Function/Feature ID|Case ID|Test case name|Test step|Expected Result (ER)|Actual Result|Status|Tester|Tested Date|
|------|------|------------------------------|------------------------------|--------------------------|----------------------------|-----------|------|---------|
|UC02| TC00| Lọc sản phẩm với phân loại là "tất cả"| 1. Chọn "Tất cả"| Giao diện hiển thị tất cả sản phẩm | Đã hiển thị tất cả các sản phẩm | Thành công | Bùi Tiến Dũng| 11/03/2024|
|UC02| TC00| Lọc sản phẩm với phân loại là "Đồ uống"| 1. Chọn "Đồ uống"| Giao diện hiển thị sản phẩm  với loại là đồ uống| Đã hiển  thị sản phẩm  với loại là đồ uống| Thành công | Bùi Tiến Dũng| 11/03/2024|
|UC02| TC00| Lọc sản phẩm với phân loại là "Đồ uống"| 1. Chọn "Đồ uống"| Giao diện hiển thị sản phẩm  với loại là đồ uống| Đã hiển  thị sản phẩm  với loại là đồ ăn |Thành công| Bùi Tiến Dũng| 11/03/2024|

* Function 02: Tìm kiếm sản phẩm theo tên

|Function/Feature ID|Case ID|Test case name|Test step|Expected Result (ER)|Actual Result|Status|Tester|Tested Date|
|------|------|------------------------------|------------------------------|--------------------------|----------------------------|-----------|------|---------|
|UC03|TC00|Tìm kiếm sản phẩm với tên là ""| 1. Không nhập giá trị vào ô tìm kiếm <br> 2. Nhấn nút tìm kiếm| hiển thị tất cả sản phẩm | Giao diện đã hiển thị tất cả sản phẩm| Thành công | Nguyễn Võ Nhật Huy |  11/03/2024 |
|UC03|TC00|Tìm kiếm sản phẩm với tên là "pepsi"| 1. Nhập vào ô tìm kiếm giá trị "pepsi" <br> 2. Nhấn nút tìm kiếm| hiển thị tất cả sản phẩm có tên pepsi | Giao diện đã hiển thị tất cả sản phẩm có tên pepsi | Thành công | Nguyễn Võ Nhật Huy |  11/03/2024 |

* Function 03: chọn sản phẩm, tăng  hoặc số lượng sản phẩm, xoá sản phẩm trong giỏ hàng

|Function/Feature ID|Case ID|Test case name|Test step|Expected Result (ER)|Actual Result|Status|Tester|Tested Date|
|------|------|------------------------------|------------------------------|--------------------------|----------------------------|-----------|------|---------|
|UC04| TC00| Chọn sảm phẩm để thêm vào giỏ hàng| Chọn 1 sản phẩm phất kì | Hiển thị sản phẩm bên giỏ hàng nếu sản phẩm chưa tồn tại thì số lượng là 1 nếu sản phẩm đã tồn tại thì công thêm 1 số lượng và cập nhật tổng tiền cho giỏ hàng với sản phẩm * số lượng tương ứng| Hiện thị sản phẩm với số lượng tương ứng và tổng tiền cho giỏ hàng tương ứng| Thành công | Bùi Tiến Dũng | 11/03/2024|
|UC04| TC00| Tăng số lượng bên giỏ hàng | 1. Nhận nút cộng số lượng sản phẩm| Hiển thị số lượng được cộng thêm và tổng tiền của giỏ hàng|Hiển thị số lượng được cộng thêm và tổng tiền của giỏ hàng| Thành công| Nguyễn Võ Nhật Huy |  11/03/2024|
|UC04| TC00| Giảm số lượng bên giỏ hàng | 1. Nhận nút trừ số lượng sản phẩm| Hiển thị số lượng được trừ đi và tổng tiền của giỏ hàng|Hiển thị số lượng được trừ đi và tổng tiền của giỏ hàng| Thành công| Nguyễn Võ Nhật Huy |  11/03/2024|
|UC04| TC00| Nhập số lượng bên giỏ hàng | 1. Nhập số lượng cho sản phẩm bên giỏ hàng| Hiển thị số lượng được nhập và tổng tiền của giỏ hàng|Hiển thị số lượng được nhập và tổng tiền của giỏ hàng chưa được cập nhật| Thất bại| Bùi Tiến Dũng |  11/03/2024|
|UC04| TC00 | Xoá sản phẩm bên giỏ hàng| 1. Chọn xoá sản phẩm| Hiển thị trang giỏ hàng đã được xoá sản phẩm cập nhật tổng tiền cho giỏ hàng| Hiển thị trang giỏ hàng đã được xoá sản phẩm cập nhật tổng tiền cho giỏ hàng | Thành công | Bùi Tiến Dũng|  11/03/2024|

## 3. Thanh toán:
* Function 01: Thanh toán

|Function/Feature ID|Case ID|Test case name|Test step|Expected Result (ER)|Actual Result|Status|Tester|Tested Date|
|------|------|------------------------------|------------------------------|--------------------------|----------------------------|-----------|------|---------|
|UC05|TC00|Thanh toán giỏ hàng với các sản phẩm bên trong với số tiền khách đưa >= số tiền khách phải trả| 1. Chọn nút thanh toán trong giỏ hàng <br> 2. Nhập % giảm giá cho đơn hàng <br> 3. Nhập giá tiền khách đưa. <br> 4. Thanh toán | Thanh toán thành công | Thanh toán thành công|Thành công| Nguyễn Võ Nhật Huy| 11/03/2024|
|UC05|TC00|Thanh toán giỏ hàng với các sản phẩm bên trong với số tiền khách đưa < số tiền khách phải trả| 1. Chọn nút thanh toán trong giỏ hàng <br> 2. Nhập % giảm giá cho đơn hàng <br> 3. Nhập giá tiền khách đưa nhỏ hơn số tiền khách trả. <br> 4. Thanh toán | Thanh toán thất bại với số tiền không thoả | Thanh toán thật bại với số tiền không thoả|Thành công| Nguyễn Võ Nhật Huy| 11/03/2024|


## 4. Quản lý kho:
* Function01: Lọc nguyên liệu trong kho theo số lượng tồn

|Function/Feature ID|Case ID|Test case name|Test step|Expected Result (ER)|Actual Result|Status|Tester|Tested Date|
|------|------|------------------------------|------------------------------|--------------------------|----------------------------|-----------|------|---------|
|UC04|TC00|Lọc nguyên liệu với phân loại là "Tất cả"|1. Chọn thẻ "Tất cả"|Giao diện hiển thị tất cả nguyên liệu có trong kho|Giao diện đã hiển thị tất cả nguyên liệu có trong kho|Thành công|Phạm Thế Duyệt|10/30/2024
|UC04|TC00|Lọc nguyên liệu với phân loại là "Bình thường"|1. Chọn thẻ "Bình thường"|Giao diện hiển thị tất cả nguyên liệu trong kho có số lượng tồn >= 20|Giao diện đã hiển thị tất cả nguyên liệu trong kho có số lượng tồn >= 20|Thành công|Phạm Thế Duyệt|10/30/2024
UC04|TC00|Lọc nguyên liệu với phân loại là "Tất cả"	1.|Chọn thẻ "Sắp hết hàng"|Giao diện hiển thị tất cả nguyên liệu trong kho có số lượng tồn < 20|Giao diện đã hiển thị tất cả nguyên liệu trong kho có số lượng tồn < 20|Thành công|Phạm Thế Duyệt|10/30/2024
UC04|TC00|Lọc nguyên liệu với phân loại là "Tất cả"	1.|Chọn thẻ "Đã hết hàng"|Giao diện hiển thị tất cả nguyên liệu trong kho có số lượng tồn = 0|Giao diện đã hiển thị tất cả nguyên liệu trong kho có số lượng tồn = 0	Thành công|Phạm Thế Duyệt|10/30/2024|

* Function02: Tìm kiếm nguyên liệu có trong kho

|Function/Feature ID|Case ID|Test case name|Test step|Expected Result (ER)|Actual Result|Status|Tester|Tested Date|
|------|------|------------------------------|------------------------------|--------------------------|----------------------------|-----------|------|---------|
|UC04|TC00|Tìm kiếm nguyên liệu khi nhập đúng tên nguyên liệu|1. Nhập "Cà phê" vào thanh tìm kiếm<br>2. Bấm "Search"|Giao diện hiển thị tất cả nguyên liệu có tên là "Cà phê" trong kho|Giao diện hiển thị tất cả nguyên liệu có tên là "Cà phê" trong kho|Thành công|Phạm Thế Duyệt|10/30/2024|
|UC05|TC00|Tìm kiếm nguyên liệu khi nhập đúng một phần tên nguyên liệu|1. Nhập "Sữa" vào thanh tìm kiếm<br>2. Bấm "Search"|Giao diện hiển thị tất cả nguyên liệu có tên là "Sữa tươi" và "Sữa đặc" trong kho|Giao diện hiển thị tất cả nguyên liệu có tên là "Sữa tươi" và "Sữa đặc" trong kho|Thành công|Phạm Thế Duyệt|10/30/2024|
|UC04|TC00|Tìm kiếm nguyên liệu khi nhập sai tên nguyên liệu|1. Nhập "Tra" vào thanh tìm kiếm<br>2. Bấm "Search"|Giao diện không hiển thị nguyên liệu nào|Giao diện không hiển thị nguyên liệu nào|Thành công|Phạm Thế Duyệt|10/30/2024|
|UC04|TC00|Tìm kiếm nguyên liệu mà không nhập tên|1. Bấm "Search"|Giao diện hiển thị tất cả nguyên liệu có trong kho|Giao diện hiển thị tất cả nguyên liệu có trong kho|Thành công|Phạm Thế Duyệt|10/30/2024|
|UC04|TC00|Tìm kiếm nguyên liệu mà không nhập tên sau khi đã tìm kiếm thành công một nguyên liệu|"Tiền điều kiện: đã tìm kiếm thành công nguyên liệu trước đó.<br>1. Xóa tên nguyên liệu đã nhập trước đó.<br>2. Bấm "Search"|Giao diện hiển thị tất cả nguyên liệu có trong kho|Giao diện hiển thị tất cả nguyên liệu có trong kho|Thành công|Phạm Thế Duyệt|10/30/2024|

* Function03: Hiển thị chi tiết thông tin nguyên liệu

|Function/Feature ID|Case ID|Test case name|Test step|Expected Result (ER)|Actual Result|Status|Tester|Tested Date|
|------|------|------------------------------|------------------------------|--------------------------|----------------------------|-----------|------|---------|
|UC04|TC00|Hiển thị chi tiết thông tin nguyên liệu khi mới load Page|1. Chọn thẻ "Quản lý kho"|Giao diện hiển thị chi tiết thông tin của nguyên liệu đầu tiên trong danh sách|Giao diện hiển thị chi tiết thông tin của nguyên liệu đầu tiên trong danh sách|Thành công|Phạm Thế Duyệt|11/02/2024|
|UC04|TC00|Hiển thị chi tiết thông tin nguyên liệu khi chọn một dòng|1. Chọn một dòng nguyên liệu (Ví dụ chọn nguyên liệu có mã là "2")|Giao diện hiển thị chi tiết thông tin của nguyên liệu có mã là "2"|Giao diện hiển thị chi tiết thông tin của nguyên liệu có mã là "2|Thành công|Phạm Thế Duyệt|11/02/2024|
|UC04|TC00|Hiển thị chi tiết thông tin nguyên liệu sau khi xóa nguyên liệu.|Tiền điều kiện: đã thực hiện xóa nguyên liệu đang được chọn|Giao diện hiển thị chi tiết thông tin của nguyên liệu nằm dưới nguyên liệu bị xóa trong danh sách|Giao diện hiển thị chi tiết thông tin của nguyên liệu nằm dưới nguyên liệu bị xóa trong danh sách	Thành công|Phạm Thế Duyệt|11/02/2024|
|UC04|TC00|Hiển thị chi tiết thông tin nguyên liệu sau khi xóa nguyên liệu cuối cùng trong danh sách|Tiền điều kiện: đã thực hiện xóa nguyên liệu cuối cùng trong danh sách|Giao diện hiển thị chi tiết thông tin của nguyên liệu nằm trên nguyên liệu bị xóa trong danh sách|Giao diện hiển thị chi tiết thông tin của nguyên liệu nằm trên nguyên liệu bị xóa trong danh sách	Thành công|Phạm Thế Duyệt|11/02/2024|
|UC04|TC00|Hiển thị chi tiết thông tin nguyên liệu sau khi chọn bộ lọc|Tiền điều kiện: đã chọn một nguyên liệu trước đó<br>1. Chọn thẻ "Bình thường"|Giao diện hiển thị chi tiết thông tin của nguyên liệu đầu tiên danh sách được lọc.|Giao diện hiển thị chi tiết thông tin của nguyên liệu được chọn trước đó|Thất bại|Phạm Thế Duyệt|11/02/2024|

* Function04: Xóa một nguyên liệu trong danh sách

|Function/Feature ID|Case ID|Test case name|Test step|Expected Result (ER)|Actual Result|Status|Tester|Tested Date|
|------|------|------------------------------|------------------------------|--------------------------|----------------------------|-----------|------|---------|
|UC04|TC00|Xóa một nguyên liệu được chọn trong danh sách|1. Chọn một dòng nguyên liệu (Ví dụ chọn nguyên liệu có mã là "2")<br>2. Bấm ""Xóa"""	"Giao diện hiển thị thông báo "Xóa thành công"|Nguyên liệu bị xóa không còn trong danh sách|Giao diện hiển thị thông báo "Xóa thành công"|Nguyên liệu bị xóa không còn trong danh sách"|Thành công|Phạm Thế Duyệt|11/02/2024|
|UC04|TC00|Xóa một nguyên liệu mà không chọn một dòng nguyên liệu nào|1. Chọn một dòng nguyên liệu (Ví dụ chọn nguyên liệu có mã là "2")<br>2. Bấm "Xóa"|Không có gì xảy ra|Không có gì xảy ra|Thành công|Phạm Thế Duyệt|11/02/2024|

# V. Tài liệu tham khảo:
- [Dependency Injection(DI) Design Pattern](https://www.geeksforgeeks.org/dependency-injectiondi-design-pattern/)
- [MVVM pattern](https://learn.microsoft.com/en-us/dotnet/architecture/maui/mvvm)
- [Using the Windows Community Toolkit DataGrid with WinUI 3 and Entity Framework Core](https://xamlbrewer.wordpress.com/2021/09/28/using-the-windows-community-toolkit-datagrid-with-winui-3-and-entity-framework-core/)
- [MVVM - Commands, RelayCommands and EventToCommand](https://learn.microsoft.com/en-us/archive/msdn-magazine/2013/may/mvvm-commands-relaycommands-and-eventtocommand)
