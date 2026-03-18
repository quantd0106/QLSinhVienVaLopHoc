using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLSinhVienVaLopHoc
{
    public partial class MainForm : Form
    {
        // ⚠️ THAY ĐỔI CHUỖI KẾT NỐI VÀ TÊN DATABASE CHO ĐÚNG VỚI MÁY CỦA BẠN
        string connectionString = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=QLSinhVienVaLopHocDB;Integrated Security=True";

        public MainForm()
        {
            InitializeComponent();

            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnTim.Click += btnTim_Click;
            dgvSinhVien.CellClick += dgvSinhVien_CellClick;

            LoadComboBoxLop(); // Tải danh sách lớp trước
            LoadData();        // Sau đó mới tải danh sách sinh viên
        }

        // --- HÀM TẢI DANH SÁCH LỚP TỪ SQL VÀO COMBOBOX ---
        private void LoadComboBoxLop()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT MaLop, TenLop FROM LopHoc";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboLop.DataSource = dt;
                    cboLop.DisplayMember = "Malop"; // Tên hiển thị ra ngoài
                    cboLop.ValueMember = "MaLop";    // Giá trị thực sự được lưu
                    cboLop.SelectedIndex = -1;       // Để trống ban đầu
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải danh sách lớp: " + ex.Message);
                }
            }
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

                    dgvSinhVien.AutoGenerateColumns = false;
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

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            txtMaSV.Clear();
            txtHoTen.Clear();
            cboGioiTinh.SelectedIndex = -1;
            dtpNgaySinh.Value = DateTime.Now;
            cboLop.SelectedIndex = -1; // Xóa chọn ComboBox
            txtTimKiem.Clear();
            txtMaSV.Focus();
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            if (string.IsNullOrEmpty(txtMaSV.Text) || string.IsNullOrEmpty(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ Mã sinh viên và Họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboLop.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn lớp học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "INSERT INTO SinhVien (MaSV, HoTen, GioiTinh, NgaySinh, Lop) VALUES (@MaSV, @HoTen, @GioiTinh, @NgaySinh, @Lop)";
            ExecuteQuery(query, "Thêm sinh viên thành công!");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            if (string.IsNullOrEmpty(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập Mã sinh viên cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboLop.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn lớp học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "UPDATE SinhVien SET HoTen=@HoTen, GioiTinh=@GioiTinh, NgaySinh=@NgaySinh, Lop=@Lop WHERE MaSV=@MaSV";
            ExecuteQuery(query, "Cập nhật thông tin thành công!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            if (string.IsNullOrEmpty(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string query = "DELETE FROM SinhVien WHERE MaSV=@MaSV";
                ExecuteQuery(query, "Xóa sinh viên thành công!");
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            string keyword = txtTimKiem.Text.Trim();
            string query = $"SELECT * FROM SinhVien WHERE MaSV LIKE N'%{keyword}%' OR HoTen LIKE N'%{keyword}%' OR Lop LIKE N'%{keyword}%'";
            LoadData(query);
        }

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

                // Cập nhật lại ComboBox Lớp theo sinh viên được chọn
                if (row.Cells["colLop"].Value != null && row.Cells["colLop"].Value.ToString() != "")
                {
                    cboLop.SelectedValue = row.Cells["colLop"].Value.ToString();
                }
                else
                {
                    cboLop.SelectedIndex = -1;
                }
            }
        }

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

                    // Lấy giá trị thực (Mã lớp) từ ComboBox để lưu vào SQL
                    cmd.Parameters.AddWithValue("@Lop", cboLop.SelectedValue?.ToString() ?? "");

                    try
                    {
                        conn.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show(successMessage, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
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