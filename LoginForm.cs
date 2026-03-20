using System;
using System.Windows.Forms;

namespace QLSinhVienVaLopHoc
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        // commit
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin đăng nhập
            if (txtUsername.Text == "quanTD" && txtPassword.Text == "0022568")
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide(); // Ẩn form đăng nhập

                // =========================================================
                // KHU VỰC THAY ĐỔI FORM CẦN CHẠY
                // Bật (xóa dấu //) ở dòng bạn muốn chạy và thêm // vào dòng còn lại
                // =========================================================

                // Chạy Quản lý Sinh viên
                //Form formToOpen = new MainForm();

                // Chạy Quản lý Lớp học
                Form formToOpen = new LopHocForm(); 

                // =========================================================

                formToOpen.ShowDialog(); // Hiển thị Form được chọn
                this.Close(); // Đóng hẳn ứng dụng sau khi tắt Form chính
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}