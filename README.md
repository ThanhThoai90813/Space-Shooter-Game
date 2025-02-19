https://docs.google.com/document/d/130AsIkWQbXLzsZb8K5WdP0RIMOPgtYddGotZTk3JbvM/edit?usp=sharing
Tài liệu Thiết kế Trò chơi: Space Explorer
1. Giới thiệu
Space Explorer là một trò chơi 2D được phát triển bằng Unity, nơi người chơi điều khiển một tàu vũ trụ khám phá không gian, tránh các tiểu hành tinh và thu thập ngôi sao để ghi điểm. Trò chơi bao gồm nhiều màn chơi khác nhau, bao gồm menu chính, màn chơi chính và màn hình kết thúc.
2. Các thành phần chính trong trò chơi
2.1 Tàu vũ trụ (Người chơi)
Mô tả:
Là đối tượng chính của trò chơi do người chơi điều khiển.
Có khả năng di chuyển theo tất cả các hướng.
Có thể bắn tia laser để tiêu diệt tiểu hành tinh.
Chức năng:
Di chuyển bằng các phím A, W, S, D.
Bắn tia laser bằng phím Space.
Nhặt ngôi sao để tăng điểm.
2.2 Tiểu hành tinh
Mô tả:
Các tiểu hành tinh trôi nổi trong không gian.
Chức năng:
Di chuyển ngẫu nhiên từ trên xuống.
Khi va chạm với tàu vũ trụ, trò chơi kết thúc.
2.3 Ngôi sao
Mô tả:
Xuất hiện ngẫu nhiên trong không gian.
Chức năng:
Khi người chơi thu thập ngôi sao, điểm số sẽ tăng lên.
3. Luồng trò chơi
3.1 Cảnh Menu Chính
Các nút chức năng:
Chơi: Bắt đầu trò chơi.
Hướng dẫn: Hiển thị cách chơi.
High Score: Hiển thị danh sách 10 người chơi có điểm cao nhất.
Thoát: Thoát trò chơi.
3.2 Cảnh Chơi
Người chơi điều khiển tàu vũ trụ để tránh các tiểu hành tinh và thu thập ngôi sao.
Càng về sau, tiểu hành tinh xuất hiện nhiều hơn và di chuyển nhanh hơn.
Trò chơi kết thúc khi tàu vũ trụ va chạm với một tiểu hành tinh.
Các yếu tố giao diện:
Hiển thị điểm số hiện tại.
Hiển thị hiệu ứng khi thu thập ngôi sao hoặc va chạm.
3.3 Cảnh Kết thúc Trò chơi
Hiển thị điểm số cuối cùng của người chơi.
Cung cấp các tùy chọn:
Quay lại Menu chính.
Thoát trò chơi.
4. Triển khai và Phát triển
4.1 Tạo Menu Chính
Thiết kế giao diện bằng Unity UI.
Cấu hình chuyển cảnh sang màn chơi chính và màn hình hướng dẫn.
4.2 Điều khiển Nhân vật
Sử dụng Input.GetAxis để di chuyển mượt mà.
Tạo hệ thống bắn đạn sử dụng Prefab và Rigidbody2D.
4.3 Sinh Tiểu Hành Tinh và Ngôi Sao
Tiểu hành tinh được sinh ngẫu nhiên và di chuyển xuống.
Ngôi sao xuất hiện ở các vị trí ngẫu nhiên và có thể thu thập.
4.4 Xử lý Va chạm và Tính điểm
Sử dụng OnTriggerEnter2D để phát hiện va chạm.
Khi người chơi thu thập ngôi sao, điểm số tăng lên.
Khi tàu vũ trụ va chạm với tiểu hành tinh, trò chơi kết thúc.
5. Công nghệ và Công cụ Sử dụng
5.1 Công cụ Phát triển
Unity: Công cụ chính để phát triển game.
Visual Studio / VS Code: IDE chính để lập trình C#.
Git & GitHub: Quản lý mã nguồn và theo dõi lịch sử phát triển.
5.2 Ngôn ngữ Lập trình
C#: Ngôn ngữ chính để lập trình gameplay và hệ thống.
5.3 Thiết kế và Đồ họa
Unity Asset Store: Sử dụng các asset 2D có sẵn.
Animations & Prefabs: Tạo các đối tượng động.
TextMesh Pro: Hiển thị văn bản sắc nét.
5.4 Âm thanh
Freesound.org: Tải hiệu ứng âm thanh miễn phí.
5.5 Giao diện Người dùng (UI/UX)
Unity UI: Xây dựng menu, HUD, thông báo nhiệm vụ.
6. Kết luận
Space Explorer là một trò chơi mang đến trải nghiệm học tập thú vị cho người mới bắt đầu với Unity. Dự án giúp người chơi thực hành các khái niệm cơ bản về lập trình game như quản lý vật lý, xử lý va chạm, hệ thống UI và quản lý cảnh. Đây là một nền tảng tuyệt vời để mở rộng và phát triển thêm các tính năng mới trong tương lai.


