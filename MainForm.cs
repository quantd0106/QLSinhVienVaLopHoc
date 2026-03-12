using System;
using System.Data;
using System.Data.SqlClient; // Thư viện để làm việc với SQL Server
using System.Windows.Forms;

namespace QLSinhVienVaLopHoc // Giữ nguyên namespace của bạn
{
    public partial class MainForm : Form
    {
        // 1. CHUỖI KẾT NỐI (Thay TEN_MAY_TINH_CUA_BAN bằng Server Name của bạn)
        string connectionString = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=QLSinhVienVaLopHocDB;Integrated Security=True";

        public MainForm()
        {
            InitializeComponent();

            // Gán sự kiện cho các nút bấm bằng code để bạn không phải kéo thả lại
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnTim.Click += btnTim_Click;
            dgvSinhVien.CellClick += dgvSinhVien_CellClick;

            // Load dữ liệu khi vừa mở Form
            LoadData();
        }

        // --- HÀM TẢI DỮ LIỆU TỪ SQL LÊN BẢNG ---
        private void LoadData(string query = "SELECT * FROM SinhVien")
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvSinhVien.AutoGenerateColumns = false; // Tắt tự động tạo cột

                    // Gán dữ liệu vào các cột đã tạo sẵn bên Designer
                    dgvSinhVien.Columns["colMaSV"].DataPropertyName = "MaSV";
                    dgvSinhVien.Columns["colHoTen"].DataPropertyName = "HoTen";
                    dgvSinhVien.Columns["colGioiTinh"].DataPropertyName = "GioiTinh";
                    dgvSinhVien.Columns["colNgaySinh"].DataPropertyName = "NgaySinh";
                    dgvSinhVien.Columns["colLop"].DataPropertyName = "Lop";

                    dgvSinhVien.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
                }
            }
        }

        // --- SỰ KIỆN: LÀM MỚI ---
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaSV.Clear();
            txtHoTen.Clear();
            cboGioiTinh.SelectedIndex = -1;
            dtpNgaySinh.Value = DateTime.Now;
            txtLop.Clear();
            txtTimKiem.Clear();
            txtMaSV.Focus(); // Đưa con trỏ chuột về ô Mã SV
            LoadData(); // Tải lại toàn bộ bảng
        }

        // --- SỰ KIỆN: THÊM SINH VIÊN ---
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSV.Text) || string.IsNullOrEmpty(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ Mã sinh viên và Họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "INSERT INTO SinhVien (MaSV, HoTen, GioiTinh, NgaySinh, Lop) VALUES (@MaSV, @HoTen, @GioiTinh, @NgaySinh, @Lop)";
            ExecuteQuery(query, "Thêm sinh viên thành công!");
        }

        // --- SỰ KIỆN: SỬA SINH VIÊN ---
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập Mã sinh viên cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "UPDATE SinhVien SET HoTen=@HoTen, GioiTinh=@GioiTinh, NgaySinh=@NgaySinh, Lop=@Lop WHERE MaSV=@MaSV";
            ExecuteQuery(query, "Cập nhật thông tin thành công!");
        }

        // --- SỰ KIỆN: XÓA SINH VIÊN ---
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                string query = "DELETE FROM SinhVien WHERE MaSV=@MaSV";
                ExecuteQuery(query, "Xóa sinh viên thành công!");
            }
        }

        // --- SỰ KIỆN: TÌM KIẾM ---
        private void btnTim_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            string query = $"SELECT * FROM SinhVien WHERE MaSV LIKE N'%{keyword}%' OR HoTen LIKE N'%{keyword}%' OR Lop LIKE N'%{keyword}%'";
            LoadData(query);
        }

        // --- SỰ KIỆN: BẤM VÀO BẢNG ĐỂ ĐIỀN THÔNG TIN SANG BÊN TRÁI ---
        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSinhVien.Rows[e.RowIndex];
                txtMaSV.Text = row.Cells["colMaSV"].Value?.ToString();
                txtHoTen.Text = row.Cells["colHoTen"].Value?.ToString();
                cboGioiTinh.Text = row.Cells["colGioiTinh"].Value?.ToString();

                if (row.Cells["colNgaySinh"].Value != null && row.Cells["colNgaySinh"].Value.ToString() != "")
                {
                    dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["colNgaySinh"].Value);
                }

                txtLop.Text = row.Cells["colLop"].Value?.ToString();
            }
        }

        // --- HÀM DÙNG CHUNG ĐỂ THỰC THI THÊM/SỬA/XÓA (Tránh lặp code) ---
        private void ExecuteQuery(string query, string successMessage)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSV", txtMaSV.Text);
                    cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                    cmd.Parameters.AddWithValue("@GioiTinh", cboGioiTinh.Text);
                    cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                    cmd.Parameters.AddWithValue("@Lop", txtLop.Text);

                    try
                    {
                        conn.Open();
                        int result = cmd.ExecuteNonQuery(); // Trả về số dòng bị ảnh hưởng
                        if (result > 0)
                        {
                            MessageBox.Show(successMessage, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData(); // Tải lại bảng sau khi thay đổi
                        }
                        else
                        {
                            MessageBox.Show("Mã sinh viên không tồn tại hoặc có lỗi xảy ra!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}